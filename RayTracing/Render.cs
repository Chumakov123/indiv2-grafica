using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmaps;

namespace RayTracing
{
    public partial class Render : Form
    {
        private Scene scene;
        private Bitmap bitmap;
        private Graphics graphics;
        private Vector3 camera_pos = new Vector3(0,0,-3.9);

        private double projection_plane_z = 1;
        private double viewport_size = 2;

        public Render()
        {
            InitializeComponent();
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            canvas.Image = bitmap;
            scene = new Scene();
            UpdateUI();
        }

        public void RenderScene()
        {
            using (var fastBitmap = new FastBitmap(bitmap))
            {
                for (int x = -canvas.Width / 2; x < canvas.Width / 2; x++)
                    for (int y = -canvas.Height / 2; y < canvas.Height / 2; y++)
                    {
                        Vector3 rayDirection = CalculateRayDirection(x, y);
                        Ray ray = new Ray(camera_pos, rayDirection.Normalize());

                        Color pixelColor = TraceRay(ray, 5);
                        fastBitmap[x + canvas.Width / 2, canvas.Height / 2 - y - 1] = pixelColor;
                    }
            }
            canvas.Image = bitmap;
            canvas.Invalidate();
        }
        private Vector3 CalculateRayDirection(int x, int y)
        {
            return new Vector3(x * (viewport_size / canvas.Width), y * (viewport_size / canvas.Height), projection_plane_z);
        }

        private Color TraceRay(Ray ray, int depth)
        {
            if (depth <= 0)
            {
                return Color.Black;
            }

            Shape closestShape = null;
            double closestT = double.MaxValue;

            foreach (var shape in scene.objects.Values)
            {
                var cur_t = shape.Intersect(ray);
                if (cur_t.Item1 < closestT)
                {
                    closestT = cur_t.Item1;
                    closestShape = shape;
                }
                if (cur_t.Item2 < closestT)
                {
                    closestT = cur_t.Item2;
                    closestShape = shape;
                }
            }

            if (closestShape != null)
            {
                Vector3 intersectionPoint = ray.PointAt(closestT);
                Vector3 normal = closestShape.GetNormal(intersectionPoint);
                Material material = closestShape.material;

                Color color = CalculateShading(intersectionPoint, normal, closestShape);

                // Отражение
                if (material.reflection > 0)
                {
                    Ray reflectedRay = CalculateReflectedRay(ray, intersectionPoint, normal);
                    Color reflectionColor = TraceRay(reflectedRay, depth - 1);
                    color = CombineColors(color, reflectionColor, material.reflection);
                }

                //// Прозрачность
                //if (material.transparent > 0)
                //{
                //    Ray refractedRay = CalculateRefractedRay(ray, intersectionPoint, normal, material.transparent);
                //    Color refractionColor = TraceRay(refractedRay, depth - 1);
                //    color = CombineColors(color, refractionColor, material.transparent);
                //}

                return color;
            }

            return Color.Black;
        }
        private Color CalculateShading(Vector3 point, Vector3 normal, Shape shape)
        {
            Color color = Color.Black;

            foreach (var light in scene.lights.Values)
            {
                if (!light.isEnabled) 
                    continue;
                if (light.type == LightSource.Type.AMBIENT)
                {
                    color = CombineColors(color, shape.color, light.intensity);
                }
                else
                {
                    Vector3 lightDirection = light.origin - point;
                    double distanceToLight = Vector3.Magnitude(lightDirection);
                    lightDirection = lightDirection.Normalize();

                    Ray shadowRay = new Ray(point + 0.001 * normal, lightDirection);
                    bool isShadowed = CheckShadow(shadowRay, distanceToLight);

                    if (!isShadowed)
                    {
                        double diffuseIntensity = Math.Max(0, Vector3.Dot(normal, lightDirection));
                        double attenuation = 1.0 / (1.0 + 0.1 * distanceToLight + 0.01 * distanceToLight * distanceToLight);

                        if (light.type == LightSource.Type.POINT)
                        {
                            color = CombineColors(color, shape.color, diffuseIntensity * attenuation * light.intensity);
                        }
                    }
                }
            }

            return color;
        }

        private bool CheckShadow(Ray shadowRay, double maxDistance)
        {
            foreach (var shape in scene.objects.Values)
            {
                var cur_t = shape.Intersect(shadowRay);
                if (cur_t.Item1 > 0 && cur_t.Item1 < maxDistance)
                {
                    return true;
                }
                if (cur_t.Item2 > 0 && cur_t.Item2 < maxDistance)
                {
                    return true;
                }
            }

            return false;
        }
        private Ray CalculateReflectedRay(Ray incidentRay, Vector3 point, Vector3 normal)
        {
            Vector3 reflectionDirection = incidentRay.direction - 2 * Vector3.Dot(normal, incidentRay.direction) * normal;
            Vector3 reflectionOrigin = point + 0.001 * reflectionDirection;
            return new Ray(reflectionOrigin, reflectionDirection);
        }
        private Ray CalculateRefractedRay(Ray incidentRay, Vector3 point, Vector3 normal, double transparency)
        {
            double eta = 1.0 / transparency;
            double cosI = -Vector3.Dot(normal, incidentRay.direction);
            double sinT2 = eta * eta * (1.0 - cosI * cosI);

            if (sinT2 > 1.0)
            {
                // Total internal reflection
                return CalculateReflectedRay(incidentRay, point, normal);
            }

            double cosT = Math.Sqrt(1.0 - sinT2);
            Vector3 refractedDirection = eta * incidentRay.direction + (eta * cosI - cosT) * normal;
            Vector3 refractedOrigin = point - 0.001 * refractedDirection; // Avoid self-intersection
            return new Ray(refractedOrigin, refractedDirection);
        }
        private Color CombineColors(Color baseColor, Color additiveColor, double factor)
        {
            int newRed = (int)(baseColor.R * (1 - factor) + additiveColor.R * factor);
            int newGreen = (int)(baseColor.G * (1 - factor) + additiveColor.G * factor);
            int newBlue = (int)(baseColor.B * (1 - factor) + additiveColor.B * factor);

            newRed = Math.Max(0, Math.Min(255, newRed));
            newGreen = Math.Max(0, Math.Min(255, newGreen));
            newBlue = Math.Max(0, Math.Min(255, newBlue));

            return Color.FromArgb(newRed, newGreen, newBlue);
        }

        public void UpdateUI()
        {
            cam_x.Value = (Decimal)camera_pos.x;
            cam_y.Value = (Decimal)camera_pos.y;
            cam_z.Value = (Decimal)camera_pos.z;

            light_x.Value = (Decimal)scene.lights["point2"].origin.x;
            light_y.Value = (Decimal)scene.lights["point2"].origin.y;
            light_z.Value = (Decimal)scene.lights["point2"].origin.z;
        }

        private void bt_run_Click(object sender, EventArgs e)
        {
            RenderScene();
        }
        private void cb_sphere_transparent_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sphere_transparent.Checked)
                scene.objects["sphere_transparent"].material = scene.materials["transparent"];
            else
                scene.objects["sphere_transparent"].material = scene.materials["default"];
        }
        private void cb_sphere_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sphere_mirror.Checked)
                scene.objects["sphere_mirror"].material = scene.materials["mirror"];
            else
                scene.objects["sphere_mirror"].material = scene.materials["default"];
        }
        private void cb_box_transparent_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_box_transparent.Checked)
                scene.objects["box_transparent"].material = scene.materials["transparent"];
            else
                scene.objects["box_transparent"].material = scene.materials["default"];
        }
        private void cb_box_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_box_mirror.Checked)
                scene.objects["box_mirror"].material = scene.materials["mirror"];
            else
                scene.objects["box_mirror"].material = scene.materials["default"];
        }
        private void cb_forward_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_forward_mirror.Checked)
                scene.objects["forward"].material = scene.materials["mirror"];
            else
                scene.objects["forward"].material = scene.materials["default"];
        }
        private void cb_backward_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_backward_mirror.Checked)
                scene.objects["backward"].material = scene.materials["mirror"];
            else
                scene.objects["backward"].material = scene.materials["default"];
        }
        private void cb_left_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_left_mirror.Checked)
                scene.objects["left"].material = scene.materials["mirror"];
            else
                scene.objects["left"].material = scene.materials["default"];
        }
        private void cb_right_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_right_mirror.Checked)
                scene.objects["right"].material = scene.materials["mirror"];
            else
                scene.objects["right"].material = scene.materials["default"];
        }
        private void cb_top_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_top_mirror.Checked)
                scene.objects["top"].material = scene.materials["mirror"];
            else
                scene.objects["top"].material = scene.materials["default"];
        }
        private void cb_bottom_mirror_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_bottom_mirror.Checked)
                scene.objects["bottom"].material = scene.materials["mirror"];
            else
                scene.objects["bottom"].material = scene.materials["default"];
        }
        private void cb_second_light_CheckedChanged(object sender, EventArgs e)
        {
            scene.lights["point2"].isEnabled = cb_second_light.Checked;
        }
        private void cam_x_ValueChanged(object sender, EventArgs e)
        {
            camera_pos.x = (int)cam_x.Value;
        }
        private void cam_y_ValueChanged(object sender, EventArgs e)
        {
            camera_pos.y = (int)cam_y.Value;
        }
        private void cam_z_ValueChanged(object sender, EventArgs e)
        {
            camera_pos.z = (double)cam_z.Value;
        }
        private void light_x_ValueChanged(object sender, EventArgs e)
        {
            scene.lights["point2"].origin.x = (int)light_x.Value;
        }
        private void light_y_ValueChanged(object sender, EventArgs e)
        {
            scene.lights["point2"].origin.y = (int)light_y.Value;
        }
        private void light_z_ValueChanged(object sender, EventArgs e)
        {
            scene.lights["point2"].origin.z = (int)light_z.Value;
        }
    }
}
