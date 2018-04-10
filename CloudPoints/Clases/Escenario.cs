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
                Puntos[i] = new Punto
                {
                    X = rnd.Next(0, iWidth),
                    Y = rnd.Next(0, iHeight)
                };
            }
        }
    }
}
