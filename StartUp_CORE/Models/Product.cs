using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Product
{
    private string name; // field
    public string Name // property
    {
        //Detter er en read only. 
        get { return name; }
    }

    private double price; // field
    public double Price // property
    {
        // 
        set {
            if (value <= 0)
            {
                throw new Exception("Price is not accepted");
            }
            else {
                price = value;
            }
        }
        get { return price; }
    }


    
    public string ImageUrl { get; set; } // field /propert
                                         


    private string manufacturer; //field. 
    public string Manufacturer //Proberty. 
    {
        get { return manufacturer; } 
        set { manufacturer = value; }
    }


    // constructor 1
    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    // constructor 2
    public Product(string name, double price, string imageUrl,string manufacturer)
    {
        this.name = name;
        this.price = price;
        ImageUrl = imageUrl;
        this.manufacturer = manufacturer;
    }
}