namespace RayTracing
{
    partial class Render
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_run = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.gb_spheres = new System.Windows.Forms.GroupBox();
            this.cb_sphere_mirror = new System.Windows.Forms.CheckBox();
            this.cb_sphere_transparent = new System.Windows.Forms.CheckBox();
            this.gb_boxes = new System.Windows.Forms.GroupBox();
            this.cb_box_mirror = new System.Windows.Forms.CheckBox();
            this.cb_box_transparent = new System.Windows.Forms.CheckBox();
            this.gb_walls = new System.Windows.Forms.GroupBox();
            this.cb_bottom_mirror = new System.Windows.Forms.CheckBox();
            this.cb_top_mirror = new System.Windows.Forms.CheckBox();
            this.cb_right_mirror = new System.Windows.Forms.CheckBox();
            this.cb_left_mirror = new System.Windows.Forms.CheckBox();
            this.cb_backward_mirror = new System.Windows.Forms.CheckBox();
            this.cb_forward_mirror = new System.Windows.Forms.CheckBox();
            this.gb_lighting = new System.Windows.Forms.GroupBox();
            this.cb_second_light = new System.Windows.Forms.CheckBox();
            this.cam_x = new System.Windows.Forms.NumericUpDown();
            this.cam_y = new System.Windows.Forms.NumericUpDown();
            this.cam_z = new System.Windows.Forms.NumericUpDown();
            this.gb_camera = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.gb_spheres.SuspendLayout();
            this.gb_boxes.SuspendLayout();
            this.gb_walls.SuspendLayout();
            this.gb_lighting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cam_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cam_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cam_z)).BeginInit();
            this.gb_camera.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_run
            // 
            this.bt_run.Location = new System.Drawing.Point(12, 12);
            this.bt_run.Name = "bt_run";
            this.bt_run.Size = new System.Drawing.Size(130, 23);
            this.bt_run.TabIndex = 0;
            this.bt_run.Text = "Отрисовка";
            this.bt_run.UseVisualStyleBackColor = true;
            this.bt_run.Click += new System.EventHandler(this.bt_run_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(148, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(640, 480);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // gb_spheres
            // 
            this.gb_spheres.Controls.Add(this.cb_sphere_mirror);
            this.gb_spheres.Controls.Add(this.cb_sphere_transparent);
            this.gb_spheres.Location = new System.Drawing.Point(12, 42);
            this.gb_spheres.Name = "gb_spheres";
            this.gb_spheres.Size = new System.Drawing.Size(130, 68);
            this.gb_spheres.TabIndex = 2;
            this.gb_spheres.TabStop = false;
            this.gb_spheres.Text = "Сферы";
            // 
            // cb_sphere_mirror
            // 
            this.cb_sphere_mirror.AutoSize = true;
            this.cb_sphere_mirror.Location = new System.Drawing.Point(6, 42);
            this.cb_sphere_mirror.Name = "cb_sphere_mirror";
            this.cb_sphere_mirror.Size = new System.Drawing.Size(98, 17);
            this.cb_sphere_mirror.TabIndex = 1;
            this.cb_sphere_mirror.Text = "Зеркальность";
            this.cb_sphere_mirror.UseVisualStyleBackColor = true;
            this.cb_sphere_mirror.CheckedChanged += new System.EventHandler(this.cb_sphere_mirror_CheckedChanged);
            // 
            // cb_sphere_transparent
            // 
            this.cb_sphere_transparent.AutoSize = true;
            this.cb_sphere_transparent.Location = new System.Drawing.Point(6, 19);
            this.cb_sphere_transparent.Name = "cb_sphere_transparent";
            this.cb_sphere_transparent.Size = new System.Drawing.Size(98, 17);
            this.cb_sphere_transparent.TabIndex = 0;
            this.cb_sphere_transparent.Text = "Прозрачность";
            this.cb_sphere_transparent.UseVisualStyleBackColor = true;
            this.cb_sphere_transparent.CheckedChanged += new System.EventHandler(this.cb_sphere_transparent_CheckedChanged);
            // 
            // gb_boxes
            // 
            this.gb_boxes.Controls.Add(this.cb_box_mirror);
            this.gb_boxes.Controls.Add(this.cb_box_transparent);
            this.gb_boxes.Location = new System.Drawing.Point(12, 116);
            this.gb_boxes.Name = "gb_boxes";
            this.gb_boxes.Size = new System.Drawing.Size(130, 68);
            this.gb_boxes.TabIndex = 3;
            this.gb_boxes.TabStop = false;
            this.gb_boxes.Text = "Шестигранники";
            // 
            // cb_box_mirror
            // 
            this.cb_box_mirror.AutoSize = true;
            this.cb_box_mirror.Location = new System.Drawing.Point(6, 42);
            this.cb_box_mirror.Name = "cb_box_mirror";
            this.cb_box_mirror.Size = new System.Drawing.Size(98, 17);
            this.cb_box_mirror.TabIndex = 2;
            this.cb_box_mirror.Text = "Зеркальность";
            this.cb_box_mirror.UseVisualStyleBackColor = true;
            this.cb_box_mirror.CheckedChanged += new System.EventHandler(this.cb_box_mirror_CheckedChanged);
            // 
            // cb_box_transparent
            // 
            this.cb_box_transparent.AutoSize = true;
            this.cb_box_transparent.Location = new System.Drawing.Point(6, 19);
            this.cb_box_transparent.Name = "cb_box_transparent";
            this.cb_box_transparent.Size = new System.Drawing.Size(98, 17);
            this.cb_box_transparent.TabIndex = 2;
            this.cb_box_transparent.Text = "Прозрачность";
            this.cb_box_transparent.UseVisualStyleBackColor = true;
            this.cb_box_transparent.CheckedChanged += new System.EventHandler(this.cb_box_transparent_CheckedChanged);
            // 
            // gb_walls
            // 
            this.gb_walls.Controls.Add(this.cb_bottom_mirror);
            this.gb_walls.Controls.Add(this.cb_top_mirror);
            this.gb_walls.Controls.Add(this.cb_right_mirror);
            this.gb_walls.Controls.Add(this.cb_left_mirror);
            this.gb_walls.Controls.Add(this.cb_backward_mirror);
            this.gb_walls.Controls.Add(this.cb_forward_mirror);
            this.gb_walls.Location = new System.Drawing.Point(12, 190);
            this.gb_walls.Name = "gb_walls";
            this.gb_walls.Size = new System.Drawing.Size(130, 159);
            this.gb_walls.TabIndex = 4;
            this.gb_walls.TabStop = false;
            this.gb_walls.Text = "Стены комнаты";
            // 
            // cb_bottom_mirror
            // 
            this.cb_bottom_mirror.AutoSize = true;
            this.cb_bottom_mirror.Location = new System.Drawing.Point(6, 134);
            this.cb_bottom_mirror.Name = "cb_bottom_mirror";
            this.cb_bottom_mirror.Size = new System.Drawing.Size(101, 17);
            this.cb_bottom_mirror.TabIndex = 8;
            this.cb_bottom_mirror.Text = "Зеркало снизу";
            this.cb_bottom_mirror.UseVisualStyleBackColor = true;
            this.cb_bottom_mirror.CheckedChanged += new System.EventHandler(this.cb_bottom_mirror_CheckedChanged);
            // 
            // cb_top_mirror
            // 
            this.cb_top_mirror.AutoSize = true;
            this.cb_top_mirror.Location = new System.Drawing.Point(6, 111);
            this.cb_top_mirror.Name = "cb_top_mirror";
            this.cb_top_mirror.Size = new System.Drawing.Size(106, 17);
            this.cb_top_mirror.TabIndex = 7;
            this.cb_top_mirror.Text = "Зеркало сверху";
            this.cb_top_mirror.UseVisualStyleBackColor = true;
            this.cb_top_mirror.CheckedChanged += new System.EventHandler(this.cb_top_mirror_CheckedChanged);
            // 
            // cb_right_mirror
            // 
            this.cb_right_mirror.AutoSize = true;
            this.cb_right_mirror.Location = new System.Drawing.Point(6, 88);
            this.cb_right_mirror.Name = "cb_right_mirror";
            this.cb_right_mirror.Size = new System.Drawing.Size(108, 17);
            this.cb_right_mirror.TabIndex = 6;
            this.cb_right_mirror.Text = "Зеркало справа";
            this.cb_right_mirror.UseVisualStyleBackColor = true;
            this.cb_right_mirror.CheckedChanged += new System.EventHandler(this.cb_right_mirror_CheckedChanged);
            // 
            // cb_left_mirror
            // 
            this.cb_left_mirror.AutoSize = true;
            this.cb_left_mirror.Location = new System.Drawing.Point(6, 65);
            this.cb_left_mirror.Name = "cb_left_mirror";
            this.cb_left_mirror.Size = new System.Drawing.Size(102, 17);
            this.cb_left_mirror.TabIndex = 5;
            this.cb_left_mirror.Text = "Зеркало слева";
            this.cb_left_mirror.UseVisualStyleBackColor = true;
            this.cb_left_mirror.CheckedChanged += new System.EventHandler(this.cb_left_mirror_CheckedChanged);
            // 
            // cb_backward_mirror
            // 
            this.cb_backward_mirror.AutoSize = true;
            this.cb_backward_mirror.Location = new System.Drawing.Point(6, 42);
            this.cb_backward_mirror.Name = "cb_backward_mirror";
            this.cb_backward_mirror.Size = new System.Drawing.Size(102, 17);
            this.cb_backward_mirror.TabIndex = 4;
            this.cb_backward_mirror.Text = "Зеркало сзади";
            this.cb_backward_mirror.UseVisualStyleBackColor = true;
            this.cb_backward_mirror.CheckedChanged += new System.EventHandler(this.cb_backward_mirror_CheckedChanged);
            // 
            // cb_forward_mirror
            // 
            this.cb_forward_mirror.AutoSize = true;
            this.cb_forward_mirror.Location = new System.Drawing.Point(6, 19);
            this.cb_forward_mirror.Name = "cb_forward_mirror";
            this.cb_forward_mirror.Size = new System.Drawing.Size(114, 17);
            this.cb_forward_mirror.TabIndex = 3;
            this.cb_forward_mirror.Text = "Зеркало спереди";
            this.cb_forward_mirror.UseVisualStyleBackColor = true;
            this.cb_forward_mirror.CheckedChanged += new System.EventHandler(this.cb_forward_mirror_CheckedChanged);
            // 
            // gb_lighting
            // 
            this.gb_lighting.Controls.Add(this.cb_second_light);
            this.gb_lighting.Location = new System.Drawing.Point(12, 355);
            this.gb_lighting.Name = "gb_lighting";
            this.gb_lighting.Size = new System.Drawing.Size(130, 47);
            this.gb_lighting.TabIndex = 3;
            this.gb_lighting.TabStop = false;
            this.gb_lighting.Text = "Освещение";
            // 
            // cb_second_light
            // 
            this.cb_second_light.AutoSize = true;
            this.cb_second_light.Location = new System.Drawing.Point(6, 19);
            this.cb_second_light.Name = "cb_second_light";
            this.cb_second_light.Size = new System.Drawing.Size(111, 17);
            this.cb_second_light.TabIndex = 3;
            this.cb_second_light.Text = "Второй источник";
            this.cb_second_light.UseVisualStyleBackColor = true;
            this.cb_second_light.CheckedChanged += new System.EventHandler(this.cb_second_light_CheckedChanged);
            // 
            // cam_x
            // 
            this.cam_x.Location = new System.Drawing.Point(6, 36);
            this.cam_x.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.cam_x.Name = "cam_x";
            this.cam_x.Size = new System.Drawing.Size(37, 20);
            this.cam_x.TabIndex = 5;
            this.cam_x.ValueChanged += new System.EventHandler(this.cam_x_ValueChanged);
            // 
            // cam_y
            // 
            this.cam_y.Location = new System.Drawing.Point(49, 36);
            this.cam_y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.cam_y.Name = "cam_y";
            this.cam_y.Size = new System.Drawing.Size(37, 20);
            this.cam_y.TabIndex = 6;
            this.cam_y.ValueChanged += new System.EventHandler(this.cam_y_ValueChanged);
            // 
            // cam_z
            // 
            this.cam_z.Location = new System.Drawing.Point(92, 36);
            this.cam_z.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.cam_z.Name = "cam_z";
            this.cam_z.Size = new System.Drawing.Size(37, 20);
            this.cam_z.TabIndex = 7;
            this.cam_z.ValueChanged += new System.EventHandler(this.cam_z_ValueChanged);
            // 
            // gb_camera
            // 
            this.gb_camera.Controls.Add(this.label3);
            this.gb_camera.Controls.Add(this.label2);
            this.gb_camera.Controls.Add(this.label1);
            this.gb_camera.Controls.Add(this.cam_x);
            this.gb_camera.Controls.Add(this.cam_z);
            this.gb_camera.Controls.Add(this.cam_y);
            this.gb_camera.Location = new System.Drawing.Point(12, 408);
            this.gb_camera.Name = "gb_camera";
            this.gb_camera.Size = new System.Drawing.Size(130, 73);
            this.gb_camera.TabIndex = 8;
            this.gb_camera.TabStop = false;
            this.gb_camera.Text = "Камера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // Render
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.gb_camera);
            this.Controls.Add(this.gb_lighting);
            this.Controls.Add(this.gb_walls);
            this.Controls.Add(this.gb_boxes);
            this.Controls.Add(this.gb_spheres);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.bt_run);
            this.Name = "Render";
            this.Text = "Трассировка лучей";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.gb_spheres.ResumeLayout(false);
            this.gb_spheres.PerformLayout();
            this.gb_boxes.ResumeLayout(false);
            this.gb_boxes.PerformLayout();
            this.gb_walls.ResumeLayout(false);
            this.gb_walls.PerformLayout();
            this.gb_lighting.ResumeLayout(false);
            this.gb_lighting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cam_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cam_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cam_z)).EndInit();
            this.gb_camera.ResumeLayout(false);
            this.gb_camera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_run;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox gb_spheres;
        private System.Windows.Forms.GroupBox gb_boxes;
        private System.Windows.Forms.GroupBox gb_walls;
        private System.Windows.Forms.CheckBox cb_sphere_mirror;
        private System.Windows.Forms.CheckBox cb_sphere_transparent;
        private System.Windows.Forms.CheckBox cb_box_mirror;
        private System.Windows.Forms.CheckBox cb_box_transparent;
        private System.Windows.Forms.CheckBox cb_bottom_mirror;
        private System.Windows.Forms.CheckBox cb_top_mirror;
        private System.Windows.Forms.CheckBox cb_right_mirror;
        private System.Windows.Forms.CheckBox cb_left_mirror;
        private System.Windows.Forms.CheckBox cb_backward_mirror;
        private System.Windows.Forms.CheckBox cb_forward_mirror;
        private System.Windows.Forms.GroupBox gb_lighting;
        private System.Windows.Forms.CheckBox cb_second_light;
        private System.Windows.Forms.NumericUpDown cam_x;
        private System.Windows.Forms.NumericUpDown cam_y;
        private System.Windows.Forms.NumericUpDown cam_z;
        private System.Windows.Forms.GroupBox gb_camera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

