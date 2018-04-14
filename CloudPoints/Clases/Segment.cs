using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPoints.Clases
{
    public class Segment
    {
        public Segment(Punto p1, Punto p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public readonly Punto P1;
        public readonly Punto P2;

        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return (P1.X - P2.X) * (P1.X - P2.X)
                + (P1.Y - P2.Y) * (P1.Y - P2.Y);
        }
    }
}
