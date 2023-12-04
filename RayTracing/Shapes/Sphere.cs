using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing.Shapes
{
    internal class Sphere : Shape
    {
        public double radius;
        public Sphere(Vector3 pos, Material mat, Color col, double radius = 1) : base(pos, mat, col)
        {
            this.radius = radius;
        }
        public override (double, double) Intersect(Ray ray)
        {
            Vector3 oc = ray.origin - position;

            double a = Vector3.Dot(ray.direction, ray.direction);
            double b = 2 * Vector3.Dot(oc, ray.direction);
            double c = Vector3.Dot(oc, oc) - radius * radius;

            double disc = b * b - 4 * a * c;

            const double infinity = double.PositiveInfinity;

            if (disc < 0) return (infinity, infinity);

            double sqrtDisc = Math.Sqrt(disc);
            double denom = 1 / (2 * a);

            return ((-b + sqrtDisc) * denom, (-b - sqrtDisc) * denom);
        }
        public override Vector3 GetNormal(Vector3 p)
        {
            return (p - position).Normalize();
        }
    }
}
