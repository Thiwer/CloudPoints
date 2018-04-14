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

        private Punto p1;
        private Punto p2;

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

            return result;

        }




        internal Punto[] getNxlogN()
        {
            //Closest(Puntos);
            Segment result = MyClosestDivide(Puntos.ToList());
            return new Punto[] { result.P1, result.P2 };
        }

        public static Segment MyClosestDivide(List<Punto> points)
        {
            return MyClosestRec(points.OrderBy(p => p.X).ToList());
        }

        private static Segment MyClosestRec(List<Punto> pointsByX)
        {
            int count = pointsByX.Count;
            if (count <= 4)
                return Closest_BruteForce(pointsByX);

            // left and right lists sorted by X, as order retained from full list
            var leftByX = pointsByX.Take(count / 2).ToList();
            var leftResult = MyClosestRec(leftByX);

            var rightByX = pointsByX.Skip(count / 2).ToList();
            var rightResult = MyClosestRec(rightByX);

            var result = rightResult.Length() < leftResult.Length() ? rightResult : leftResult;

            // There may be a shorter distance that crosses the divider
            // Thus, extract all the points within result.Length either side
            var midX = leftByX.Last().X;
            var bandWidth = result.Length();
            var inBandByX = pointsByX.Where(p => Math.Abs(midX - p.X) <= bandWidth);

            // Sort by Y, so we can efficiently check for closer pairs
            var inBandByY = inBandByX.OrderBy(p => p.Y).ToArray();

            int iLast = inBandByY.Length - 1;
            for (int i = 0; i < iLast; i++)
            {
                var pLower = inBandByY[i];

                for (int j = i + 1; j <= iLast; j++)
                {
                    var pUpper = inBandByY[j];

                    // Comparing each point to successivly increasing Y values
                    // Thus, can terminate as soon as deltaY is greater than best result
                    if ((pUpper.Y - pLower.Y) >= result.Length())
                        break;

                    if (new Segment(pLower, pUpper).Length() < result.Length())
                        result = new Segment(pLower, pUpper);
                }
            }

            return result;
        }


        private static Segment Closest_BruteForce(List<Punto> points)
        {
            int n = points.Count;
            var result = Enumerable.Range(0, n - 1)
                .SelectMany(i => Enumerable.Range(i + 1, n - (i + 1))
                   .Select(j => new Segment(points[i], points[j])))
                    .OrderBy(seg => seg.LengthSquared())
                    .First();

            return result;
        }


        //public double Closest(Punto[] points)
        //{
        //    QuickSort3.Sort(points, 0, points.Length - 1, (p1, p2) => p1.CompareXTo(p2));

        //    return ClosestRect(points);
        //}

        //private double ClosestRect(Punto[] p)
        //{
        //    const int threshold = 2048;
        //    if (p.Length <= 3) return BruteForce(p);

        //    Punto[] pxLeft = new Punto[p.Length / 2];
        //    Array.Copy(p, pxLeft, p.Length / 2);

        //    Punto[] pxRight = new Punto[p.Length - (p.Length / 2)];
        //    Array.Copy(p, p.Length / 2, pxRight, 0, p.Length - (p.Length / 2));

        //    double distL = 0;
        //    double distR = 0;

        //    if (p.Length / 2 > threshold)
        //    {
        //        Parallel.Invoke(
        //            () => distL = ClosestRect(pxLeft),
        //            () => distR = ClosestRect(pxRight)
        //            );
        //    }
        //    else
        //    {
        //        distL = ClosestRect(pxLeft);
        //        distR = ClosestRect(pxRight);
        //    }

        //    double dist = Math.Min(distL, distR);

        //    Punto[] strip = new Punto[p.Length];
        //    Punto mid = pxLeft[(p.Length / 2) - 1];
        //    int size = 0;
        //    for (int i = 0; i < p.Length; i++)
        //    {
        //        if (Math.Abs(mid.X - p[i].X) <= dist)
        //        {
        //            strip[size++] = p[i];
        //        }
        //    }

        //    QuickSort3.Sort(strip, 0, size - 1, (p1, p2) => p1.CompareYTo(p2));

        //    for (int i = 0; i < size - 1; i++)
        //    {
        //        Punto lower = strip[i];
        //        for (int j = i + 1; j < size; j++)
        //        {
        //            Punto upper = strip[j];

        //            if (upper.Y - lower.Y >= dist) break;

        //            double luDist = Punto.Distance(lower, upper);
        //            if (luDist < dist)
        //            {
        //                dist = luDist;
        //                p1 = upper;
        //                p2 = lower;
        //            }
        //        }
        //    }

        //    return dist;
        //}

        //private static double StripClosest(Punto[] strip, int size, double distance)
        //{
        //    double min = distance;

        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = i + 1; j < size && (strip[j].Y - strip[i].Y) < min; j++)
        //        {
        //            double dist = Punto.Distance(strip[i], strip[j]);
        //            if (dist < min)
        //            {
        //                min = dist;
        //            }
        //        }
        //    }

        //    return min;
        //}



        public static double distancia(Punto p1, Punto p2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
        }

    }
}
