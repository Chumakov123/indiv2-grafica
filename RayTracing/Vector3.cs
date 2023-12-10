using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(Vector3 other)
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        public Vector3()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 Normalize(Vector3 v)
        {
            double len = Magnitude(v);
            return new Vector3(v.x / len, v.y / len, v.z / len);
        }
        public Vector3 Normalize()
        {
            if (Length() == 0) return this;

            return this * (1.0 / Length());
        }
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Vector3 operator -(Vector3 lhs)
        {
            return new Vector3(-lhs.x, -lhs.y, -lhs.z);
        }
        public static double Dot(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z);
        }
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public static Vector3 operator *(Vector3 lhs, double rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator *(double lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector3 operator /(Vector3 lhs, double rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static Vector3 operator /(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        }

        public static double Magnitude(Vector3 v)
        {
            return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }
        public double LengthSquared()
        {
            return x * x + y * y + z * z;
        }
        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        private Vector3 Clamp()
        {
            return new Vector3(Math.Min(255, Math.Max(0, (int)x)),
                Math.Min(255, Math.Max(0, (int)y)),
                Math.Min(255, Math.Max(0, (int)z)));
        }
        public Color ToColor()
        {
            Vector3 v = this.Clamp();
            return Color.FromArgb((int)v.x, (int)v.y, (int)v.z);
        }
        public static Vector3 MixColor(Color color, double h)
        {
            return new Vector3(color.R * h, color.G * h, color.B * h);
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default:
                        throw new IndexOutOfRangeException("Index should be in the range [0, 3].");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default:
                        throw new IndexOutOfRangeException("Index should be in the range [0, 3].");
                }
            }
        }
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
}
