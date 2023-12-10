using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing.Shapes
{
    internal class Box : Shape
    {
        public Vector3[] bounds = new Vector3[2];
        public Box(Vector3 pos, Material mat, Color col, Vector3 v1, Vector3 v2) 
            : base(pos, mat, col)
        {
            bounds[0] = pos + v1;
            bounds[1] = pos + v2;
        }
        public Box() : base()
        {
            bounds[0] = base.position + new Vector3(0, 0, 0);
            bounds[1] = base.position + new Vector3(1, 1, 1);
        }
        public override (double, double) Intersect(Ray ray)
        {
            double tmin = double.NegativeInfinity;
            double tmax = double.PositiveInfinity;

            for (int i = 0; i < 3; i++)
            {
                double invDirection = 1.0 / ray.direction[i];
                double t1 = (bounds[0][i] - ray.origin[i]) * invDirection;
                double t2 = (bounds[1][i] - ray.origin[i]) * invDirection;

                if (invDirection < 0.0)
                    (t1, t2) = (t2, t1);

                tmin = Math.Max(t1, tmin);
                tmax = Math.Min(t2, tmax);

                if (tmin > tmax)
                    return (double.PositiveInfinity, double.PositiveInfinity);
            }

            if (tmin > 0.0 && tmax > 0.0)
                return (tmin, tmax);

            return (double.PositiveInfinity, double.PositiveInfinity);
        }
        public override Vector3 GetNormal(Vector3 point)
        {
            Vector3 center = (bounds[0] + bounds[1]) / 2;
            Vector3 halfExtents = (bounds[1] - bounds[0]) / 2;

            Vector3 localPoint = (point - center) / halfExtents;

            double maxComponent = Math.Max(Math.Max(Math.Abs(localPoint.x), Math.Abs(localPoint.y)), Math.Abs(localPoint.z));

            if (Math.Abs(localPoint.x) == maxComponent)
            {
                return new Vector3(Math.Sign(localPoint.x), 0, 0);
            }
            else if (Math.Abs(localPoint.y) == maxComponent)
            {
                return new Vector3(0, Math.Sign(localPoint.y), 0);
            }
            else
            {
                return new Vector3(0, 0, Math.Sign(localPoint.z));
            }
        }
       
    }
}
