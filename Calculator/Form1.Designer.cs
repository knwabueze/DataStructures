namespace Calculator
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
            this.main_label = new System.Windows.Forms.Label();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button_plus = new System.Windows.Forms.Button();
            this.button_equals = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button_divided = new System.Windows.Forms.Button();
            this.button_times = new System.Windows.Forms.Button();
            this.button_minus = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.equation_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // main_label
            // 
            this.main_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.main_label.AutoSize = true;
            this.main_label.BackColor = System.Drawing.Color.Transparent;
            this.main_label.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.main_label.Location = new System.Drawing.Point(12, 34);
            this.main_label.Name = "main_label";
            this.main_label.Size = new System.Drawing.Size(35, 38);
            this.main_label.TabIndex = 0;
            this.main_label.Text = "0";
            this.main_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button0
            // 
            this.button0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button0.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button0.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button0.Location = new System.Drawing.Point(-7, 109);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(151, 85);
            this.button0.TabIndex = 1;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(141, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 85);
            this.button1.TabIndex = 2;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(285, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 85);
            this.button2.TabIndex = 3;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(285, 190);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 85);
            this.button5.TabIndex = 6;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(141, 190);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 85);
            this.button4.TabIndex = 5;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(-7, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 85);
            this.button3.TabIndex = 4;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button8.Location = new System.Drawing.Point(285, 271);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(151, 85);
            this.button8.TabIndex = 9;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.Location = new System.Drawing.Point(141, 271);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(151, 85);
            this.button7.TabIndex = 8;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Location = new System.Drawing.Point(-7, 271);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(151, 85);
            this.button6.TabIndex = 7;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button_plus
            // 
            this.button_plus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_plus.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button_plus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_plus.Location = new System.Drawing.Point(285, 353);
            this.button_plus.Name = "button_plus";
            this.button_plus.Size = new System.Drawing.Size(151, 85);
            this.button_plus.TabIndex = 12;
            this.button_plus.Tag = "plus";
            this.button_plus.Text = "+";
            this.button_plus.UseVisualStyleBackColor = true;
            this.button_plus.Click += new System.EventHandler(this.OperationProccessing);
            // 
            // button_equals
            // 
            this.button_equals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_equals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_equals.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_equals.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_equals.Location = new System.Drawing.Point(141, 353);
            this.button_equals.Name = "button_equals";
            this.button_equals.Size = new System.Drawing.Size(151, 85);
            this.button_equals.TabIndex = 11;
            this.button_equals.Tag = "equals";
            this.button_equals.Text = "=";
            this.button_equals.UseVisualStyleBackColor = true;
            this.button_equals.Click += new System.EventHandler(this.OperationProccessing);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button9.Location = new System.Drawing.Point(-7, 353);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(151, 85);
            this.button9.TabIndex = 10;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.NumberProccessing);
            // 
            // button_divided
            // 
            this.button_divided.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_divided.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_divided.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button_divided.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_divided.Location = new System.Drawing.Point(285, 433);
            this.button_divided.Name = "button_divided";
            this.button_divided.Size = new System.Drawing.Size(151, 85);
            this.button_divided.TabIndex = 15;
            this.button_divided.Tag = "divide";
            this.button_divided.Text = "/";
            this.button_divided.UseVisualStyleBackColor = true;
            this.button_divided.Click += new System.EventHandler(this.OperationProccessing);
            // 
            // button_times
            // 
            this.button_times.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_times.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_times.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button_times.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_times.Location = new System.Drawing.Point(141, 433);
            this.button_times.Name = "button_times";
            this.button_times.Size = new System.Drawing.Size(151, 85);
            this.button_times.TabIndex = 14;
            this.button_times.Tag = "times";
            this.button_times.Text = "*";
            this.button_times.UseVisualStyleBackColor = true;
            this.button_times.Click += new System.EventHandler(this.OperationProccessing);
            // 
            // button_minus
            // 
            this.button_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minus.Font = new System.Drawing.Font("Arial", 13.8F);
            this.button_minus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_minus.Location = new System.Drawing.Point(-7, 433);
            this.button_minus.Name = "button_minus";
            this.button_minus.Size = new System.Drawing.Size(151, 85);
            this.button_minus.TabIndex = 13;
            this.button_minus.Tag = "minus";
            this.button_minus.Text = "-";
            this.button_minus.UseVisualStyleBackColor = true;
            this.button_minus.Click += new System.EventHandler(this.OperationProccessing);
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_clear.Location = new System.Drawing.Point(286, 78);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(150, 34);
            this.button_clear.TabIndex = 16;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.ClearButtonClicked);
            // 
            // equation_label
            // 
            this.equation_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.equation_label.AutoSize = true;
            this.equation_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.equation_label.Location = new System.Drawing.Point(13, 13);
            this.equation_label.Name = "equation_label";
            this.equation_label.Size = new System.Drawing.Size(16, 17);
            this.equation_label.TabIndex = 17;
            this.equation_label.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(435, 516);
            this.Controls.Add(this.equation_label);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_divided);
            this.Controls.Add(this.button_times);
            this.Controls.Add(this.button_minus);
            this.Controls.Add(this.button_plus);
            this.Controls.Add(this.button_equals);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.main_label);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label main_label;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button_plus;
        private System.Windows.Forms.Button button_equals;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button_divided;
        private System.Windows.Forms.Button button_times;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label equation_label;
    }
}

