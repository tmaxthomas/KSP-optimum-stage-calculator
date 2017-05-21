namespace KSP_optimum_stage_calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.v_mass_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.p_mass_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.min_accel_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comp_button = new System.Windows.Forms.Button();
            this.output_box = new System.Windows.Forms.RichTextBox();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // v_mass_box
            // 
            this.v_mass_box.Location = new System.Drawing.Point(145, 8);
            this.v_mass_box.Name = "v_mass_box";
            this.v_mass_box.Size = new System.Drawing.Size(100, 20);
            this.v_mass_box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vessel mass (t)";
            // 
            // p_mass_box
            // 
            this.p_mass_box.Location = new System.Drawing.Point(145, 34);
            this.p_mass_box.Name = "p_mass_box";
            this.p_mass_box.Size = new System.Drawing.Size(100, 20);
            this.p_mass_box.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Payload mass (t)";
            // 
            // min_accel_box
            // 
            this.min_accel_box.Location = new System.Drawing.Point(145, 60);
            this.min_accel_box.Name = "min_accel_box";
            this.min_accel_box.Size = new System.Drawing.Size(100, 20);
            this.min_accel_box.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Minimum acceleration (m/s)";
            // 
            // comp_button
            // 
            this.comp_button.Location = new System.Drawing.Point(109, 86);
            this.comp_button.Name = "comp_button";
            this.comp_button.Size = new System.Drawing.Size(75, 23);
            this.comp_button.TabIndex = 6;
            this.comp_button.Text = "Compute";
            this.comp_button.UseVisualStyleBackColor = true;
            this.comp_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // output_box
            // 
            this.output_box.Location = new System.Drawing.Point(43, 144);
            this.output_box.Name = "output_box";
            this.output_box.Size = new System.Drawing.Size(202, 242);
            this.output_box.TabIndex = 8;
            this.output_box.Text = "";
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(43, 115);
            this.progress_bar.Maximum = 60;
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(202, 23);
            this.progress_bar.Step = 1;
            this.progress_bar.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 398);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.output_box);
            this.Controls.Add(this.comp_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.min_accel_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.p_mass_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.v_mass_box);
            this.Name = "Form1";
            this.Text = "KSP optimum stage calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox v_mass_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox p_mass_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox min_accel_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button comp_button;
        private System.Windows.Forms.RichTextBox output_box;
        private System.Windows.Forms.ProgressBar progress_bar;
    }
}

