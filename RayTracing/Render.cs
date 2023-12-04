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
        private bool sphere_mirror = false;
        private bool sphere_transparent = false;
        private bool box_mirror = false;
        private bool box_transparent = false;
        private bool forward_wall_mirror = false;
        private bool backward_wall_mirror = false;
        private bool left_wall_mirror = false;
        private bool right_wall_mirror = false;
        private bool top_wall_mirror = false;
        private bool bottom_wall_mirror = false;
        private bool second_light = false;

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

                        Color pixelColor = TraceRay(ray, 5); // 5 - максимальная глубина трассировки
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
                return Color.Black; // Stop recursion if depth is zero
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

                // Reflection
                if (material.reflection > 0)
                {
                    Ray reflectedRay = CalculateReflectedRay(ray, intersectionPoint, normal);
                    Color reflectionColor = TraceRay(reflectedRay, depth - 1);
                    color = CombineColors(color, reflectionColor, material.reflection);
                }

                // Refraction
                if (material.transparent > 0)
                {
                    Ray refractedRay = CalculateRefractedRay(ray, intersectionPoint, normal, material.transparent);
                    Color refractionColor = TraceRay(refractedRay, depth - 1);
                    color = CombineColors(color, refractionColor, material.transparent);
                }

                return color;
            }

            return Color.Black; // No intersection
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
                    // Для окружающего света не рассчитываем тени
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
                    return true; // The point is in shadow
                }
                if (cur_t.Item2 > 0 && cur_t.Item2 < maxDistance)
                {
                    return true; // The point is in shadow
                }
            }

            return false; // The point is not in shadow
        }
        private Ray CalculateReflectedRay(Ray incidentRay, Vector3 point, Vector3 normal)
        {
            Vector3 reflectionDirection = incidentRay.direction - 2 * Vector3.Dot(normal, incidentRay.direction) * normal;
            Vector3 reflectionOrigin = point + 0.001 * reflectionDirection; // Avoid self-intersection
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
            cb_sphere_mirror.Checked = sphere_mirror;
            cb_sphere_transparent.Checked = sphere_transparent;
            cb_box_mirror.Checked = box_mirror;
            cb_box_transparent.Checked = box_transparent;
            cb_forward_mirror.Checked = forward_wall_mirror;
            cb_backward_mirror.Checked = backward_wall_mirror;
            cb_left_mirror.Checked = left_wall_mirror;
            cb_right_mirror.Checked = right_wall_mirror;
            cb_top_mirror.Checked = top_wall_mirror;
            cb_bottom_mirror.Checked = bottom_wall_mirror;
            cb_second_light.Checked = second_light;
        }

        private void bt_run_Click(object sender, EventArgs e)
        {
            RenderScene();
        }
        private void cb_sphere_transparent_CheckedChanged(object sender, EventArgs e)
        {
            sphere_transparent = cb_sphere_transparent.Checked;
            if (sphere_transparent)
                scene.objects["sphere_transparent"].material = scene.materials["transparent"];
            else
                scene.objects["sphere_transparent"].material = scene.materials["default"];
        }
        private void cb_sphere_mirror_CheckedChanged(object sender, EventArgs e)
        {
            sphere_mirror = cb_sphere_mirror.Checked;
            if (sphere_mirror)
                scene.objects["sphere_mirror"].material = scene.materials["mirror"];
            else
                scene.objects["sphere_mirror"].material = scene.materials["default"];
        }
        private void cb_box_transparent_CheckedChanged(object sender, EventArgs e)
        {
            box_transparent = cb_box_transparent.Checked;
            if (box_transparent)
                scene.objects["box_transparent"].material = scene.materials["transparent"];
            else
                scene.objects["box_transparent"].material = scene.materials["default"];
        }
        private void cb_box_mirror_CheckedChanged(object sender, EventArgs e)
        {
            box_mirror = cb_box_mirror.Checked;
            if (box_mirror)
                scene.objects["box_mirror"].material = scene.materials["mirror"];
            else
                scene.objects["box_mirror"].material = scene.materials["default"];
        }
        private void cb_forward_mirror_CheckedChanged(object sender, EventArgs e)
        {
            forward_wall_mirror = cb_forward_mirror.Checked;
            if (forward_wall_mirror)
                scene.objects["forward"].material = scene.materials["mirror"];
            else
                scene.objects["forward"].material = scene.materials["default"];
        }
        private void cb_backward_mirror_CheckedChanged(object sender, EventArgs e)
        {
            backward_wall_mirror = cb_backward_mirror.Checked;
            if (backward_wall_mirror)
                scene.objects["backward"].material = scene.materials["mirror"];
            else
                scene.objects["backward"].material = scene.materials["default"];
        }
        private void cb_left_mirror_CheckedChanged(object sender, EventArgs e)
        {
            left_wall_mirror = cb_left_mirror.Checked;
            if (left_wall_mirror)
                scene.objects["left"].material = scene.materials["mirror"];
            else
                scene.objects["left"].material = scene.materials["default"];
        }
        private void cb_right_mirror_CheckedChanged(object sender, EventArgs e)
        {
            right_wall_mirror = cb_right_mirror.Checked;
            if (right_wall_mirror)
                scene.objects["right"].material = scene.materials["mirror"];
            else
                scene.objects["right"].material = scene.materials["default"];
        }
        private void cb_top_mirror_CheckedChanged(object sender, EventArgs e)
        {
            top_wall_mirror = cb_top_mirror.Checked;
            if (top_wall_mirror)
                scene.objects["top"].material = scene.materials["mirror"];
            else
                scene.objects["top"].material = scene.materials["default"];
        }
        private void cb_bottom_mirror_CheckedChanged(object sender, EventArgs e)
        {
            bottom_wall_mirror = cb_bottom_mirror.Checked;
            if (top_wall_mirror)
                scene.objects["bottom"].material = scene.materials["mirror"];
            else
                scene.objects["bottom"].material = scene.materials["default"];
        }
        private void cb_second_light_CheckedChanged(object sender, EventArgs e)
        {
            second_light = cb_second_light.Checked;
            scene.lights["point2"].isEnabled = second_light;
        }

        private void cam_x_ValueChanged(object sender, EventArgs e)
        {
            camera_pos.x = (int)cam_x.Value;
            RenderScene();
        }

        private void cam_y_ValueChanged(object sender, EventArgs e)
        {
            camera_pos.y = (int)cam_y.Value;
            RenderScene();
        }

        private void cam_z_ValueChanged(object sender, EventArgs e)
        {
            camera_pos.z = (double)cam_z.Value/10;
            RenderScene();
        }
    }
}
