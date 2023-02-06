using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._0
{
     public abstract class Shapes
    {
        private double x, y;
        public Shapes (double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Shapes()
        {
            this.x = 1;
            this.y = 1;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return "X:" + this.x + " Y:" + this.y;
        }

        public abstract double Area();

    }
}
