using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPoints.Clases
{
    public class Punto
    {
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }


        public int CompareXTo(Punto other) => X.CompareTo(other.X);
        public int CompareYTo(Punto other) => Y.CompareTo(other.Y);

        public static double Distance(Punto p1, Punto p2) =>
            Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) +
                 (p1.Y - p2.Y) * (p1.Y - p2.Y));


        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
