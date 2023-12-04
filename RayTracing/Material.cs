using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Material
    {
        public double refraction; 
        public double reflection;
        public double transparent;
        public Material(double refr = 0, double refl = 0, double transp = 0)
        {
            reflection = refl;
            refraction = refr;
            transparent = transp;
        }
        public Material(Material m)
        {
            reflection = m.reflection;
            refraction = m.refraction;
            transparent = m.transparent;
        }
    }
}
