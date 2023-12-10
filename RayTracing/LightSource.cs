using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class LightSource
    {
        public enum Type
        {
            AMBIENT,
            POINT,
        }

        public Type type;
        public double intensity;
        public Vector3 origin;
        public bool isEnabled;
        public LightSource(Type type, Vector3 origin, double intensity = 1, bool isEnabled = true)
        {
            this.type = type;
            this.intensity = intensity;
            this.origin = origin;
            this.isEnabled = isEnabled;
        }
        public LightSource(Type type, double intensity = 1, bool isEnabled = true)
        {
            this.type = type;
            this.intensity = intensity;
            this.origin = new Vector3();
            this.isEnabled = isEnabled;
        }
        public LightSource() { }
    }
}
