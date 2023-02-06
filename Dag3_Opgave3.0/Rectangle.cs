using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._0
{
    public class Rectangle : Shapes
    {
        private double length;
        private double width;

        public Rectangle(double x, double y, double length, double width) : base(x, y)
        {
            this.length = length;   
            this.width = width;
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public override double Area()
        {
            return length * width;
        }

        public override string ToString()
        {
            return base.ToString() + " Width:" + this.width + " Length:" + this.length + " Areal:" + Area();
        }


    }
}
