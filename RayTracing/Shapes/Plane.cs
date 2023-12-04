using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing.Shapes
{
    internal class Plane : Shape
    {
        Vector3 point;
        Vector3 normal;
        public Plane(Vector3 p, Material mat, Color col, Vector3 normal)
             : base(p, mat, col)
        {
            this.point = p;
            this.normal = normal;
        }
        public override Vector3 GetNormal(Vector3 p)
        {
            return normal;
        }
        public override  (double, double) Intersect(Ray ray)
        {
            var d = Vector3.Dot(point, -normal);
            var t = -(d + Vector3.Dot(ray.origin, normal)) / Vector3.Dot(ray.direction, normal);
            if (t <= 1e-4) return (double.PositiveInfinity, double.PositiveInfinity);
            else return (t, t);
        }
    }
}
