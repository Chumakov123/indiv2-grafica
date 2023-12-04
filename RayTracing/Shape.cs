using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Shape
    {
        public Vector3 position;
        public Material material;
        public Color color;

        public Shape(Vector3 pos, Material mat, Color color)
        {
            position = pos;
            material = mat;
            this.color = color;
        }
        public Shape()
        {
            position = new Vector3();
            material = new Material();
            color = Color.White;
        }
        public virtual Vector3 GetNormal(Vector3 p)
        {
            throw new NotImplementedException();
        }
        public virtual (double, double) Intersect(Ray ray)
        {
            throw new NotImplementedException();
        }
    }
}
