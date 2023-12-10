using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracing.Shapes;

namespace RayTracing
{
    internal class Scene
    {
        public Dictionary<string, Shape> objects;
        public Dictionary<string, LightSource> lights;
        public Dictionary<string, Material> materials = new Dictionary<string, Material>
        {
            { "default", new Material(0,0,0)},
            { "transparent", new Material(0,0,0.8)},
            { "mirror", new Material(0,0.8,0)},
        };
        public Scene()
        {

            objects = new Dictionary<string, Shape>();

            double roomSize = 4;

            objects.Add("forward", new Plane(new Vector3(0, 0, roomSize), materials["default"], Color.DarkGray, new Vector3(0, 0, -1)));
            objects.Add("backward", new Plane(new Vector3(0, 0, -roomSize), materials["default"], Color.Purple, new Vector3(0, 0, 1)));
            objects.Add("left", new Plane(new Vector3(roomSize, 0, 0), materials["default"], Color.Red, new Vector3(-1, 0, 0)));
            objects.Add("right", new Plane(new Vector3(-roomSize, 0, 0), materials["default"], Color.Green, new Vector3(1, 0, 0)));
            objects.Add("bottom", new Plane(new Vector3(0, -roomSize, 0), materials["default"], Color.Gray, new Vector3(0, 1, 0)));
            objects.Add("top", new Plane(new Vector3(0, roomSize, 0), materials["default"], Color.DarkGray, new Vector3(0, -1, 0)));

            objects.Add("sphere_transparent", new Sphere(new Vector3(0,2,0), materials["default"], Color.DarkGreen, 0.5));
            objects.Add("sphere_mirror", new Sphere(new Vector3(-2,-2,0), materials["default"], Color.DarkMagenta, 0.75));

            objects.Add("box_transparent",new Box(new Vector3(-1, -2, -1), materials["default"], Color.DarkCyan, new Vector3(0, 0, 0), new Vector3(1, 1, 1)));
            objects.Add("box_mirror", new Box(new Vector3(1, -2, 1), materials["default"], Color.DarkGoldenrod, new Vector3(0, 0, 0), new Vector3(1, 2.25, 1)));

            lights = new Dictionary<string, LightSource>();

            lights.Add("ambient", new LightSource(LightSource.Type.AMBIENT, 0.125));
            lights.Add("point1", new LightSource(LightSource.Type.POINT, new Vector3(0, 0, -1), 0.8));
            lights.Add("point2", new LightSource(LightSource.Type.POINT, new Vector3(0, 0, 0), 0.8, false));
        }
    }
}
