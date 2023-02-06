using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._0
{
    public class Circle: Shapes
    {
        private double radius;
        
        public Circle(double x, double y, double radius): base(x, y)
        {
            this.radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set { radius= value; }
        }

        public override double Area()
        {
            return (radius * radius) * Math.PI;
        }

        public override string ToString()
        {
            return base.ToString() + " Radius:" + this.radius + " Areal:" + Area();
        }




    }
}
