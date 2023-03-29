using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



//nedenstående skal normalt ikke stå øverst !!
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    constraints: new { id = new IntRouteConstraint() }
);
app.MapControllerRoute(
    name: "Shop",
    pattern: "KoebInd/{id}/{kategori}",
    defaults: new { controller = "Shop", action = "Book" },
    constraints: new { id = new IntRouteConstraint() }
);
//Passer ikke specielt godt med signatur på action, så den skal nok ændres
//Prøv at lave navnet på anden parameter om

// eller lav det med en mere avanceret constraint:
//app.MapControllerRoute(
//    name: "Shop",
//    pattern: "KoebInd/{id}/{kategori}",
//    defaults: new { controller = "Shop", action = "Book" },
//    constraints: new { id = new RangeRouteConstraint(10, 100) }
//);
app.MapControllerRoute(
    name: "ShopNoCategory",
    pattern: "KoebInd/{id?}",
    defaults: new { controller = "Shop", action = "Book"},
    constraints: new { id = new IntRouteConstraint() }
);
app.MapControllerRoute(
    name: "ShopIndex",
    pattern: "KoebInd/{action}",  //hvad laver action her?
    defaults: new { controller = "Shop", action = "Index" },
    constraints: new { id = new IntRouteConstraint() }
);
app.MapControllerRoute(
    name: "Koebindgenerisk",
    pattern: "koebind/{controller}/{kategori?}/{title?}",
    defaults: new { action = "Index" }
);


//Lav evt. omvendt default
app.Run();
