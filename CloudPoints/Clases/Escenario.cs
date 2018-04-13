using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPoints.Clases
{
    public class Escenario
    {

        public int NumPoints { get; set; }

        public Punto[] Puntos { get; set; }

        private double Width { get; set; }
        private double Height { get; set; }

        public Escenario(int numPoints, double width, double height)
        {
            this.NumPoints = numPoints;
            Puntos = new Punto[this.NumPoints];

            Width = width;
            Height = height;

            InitializePoints();

        }

        private void InitializePoints()
        {
            Random rnd = new Random();

            int iWidth = Convert.ToInt32(Width);
            int iHeight = Convert.ToInt32(Height);

            for (int i = 0; i < NumPoints; i++)
            {
                Punto pTemp = new Punto();

                //Para evitar que se repitan
                do
                {
                    pTemp.ID = i;
                    pTemp.X = rnd.Next(0, iWidth);
                    pTemp.Y = rnd.Next(0, iHeight);
                } while (i > 0 && Puntos.Where(s => s != null && s.X == pTemp.X && s.Y == pTemp.Y).Count() > 0);

                Puntos[i] = pTemp;
            }
        }

        internal Punto[] getNxN()
        {
            double minDist = double.MaxValue;
            Punto[] result = new Punto[2];

            foreach (var p1 in Puntos)
            {
                foreach (var p2 in Puntos)
                {
                    if (p1.ID != p2.ID)
                    {
                        double dist = distancia(p1, p2);
                        if (minDist > dist)
                        {
                            minDist = dist;
                            result[0] = p1;
                            result[1] = p2;
                        }
                    }
                }
            }

            Console.WriteLine(result[0].ToString());
            Console.WriteLine(result[1].ToString());

            return result;

        }


        private double distancia(Punto p1, Punto p2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
        }

    }
}
