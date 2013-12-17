using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Curves;

namespace Amimat_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> ptList = new List<double>();
            ptList.Add(0);
            ptList.Add(0);
            ptList.Add(100);
            ptList.Add(100);
            ptList.Add(0);
            ptList.Add(50);
            ptList.Add(100);
            ptList.Add(50);
            int POINTS_ON_CURVE = 20;
            BezierCurve bc = new BezierCurve();
            double[] ptind = new double[ptList.Count];
            double[] p = new double[POINTS_ON_CURVE];
            ptList.CopyTo(ptind, 0);
            bc.Bezier2D(ptind, (POINTS_ON_CURVE) / 2, p);
            for (int i = 0; i < POINTS_ON_CURVE; i += 2)
            {
                Console.WriteLine("({0},{1})", (int)p[i], (int)p[i + 1]);
            }
            Console.Read();
        }
    }
}
