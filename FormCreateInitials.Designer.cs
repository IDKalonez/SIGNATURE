namespace Signature
{
    partial class FormCreateInitials
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
            this.buttonCreateInitials = new System.Windows.Forms.Button();
            this.textBoxInitials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // buttonCreateInitials
            // 
            this.buttonCreateInitials.Location = new System.Drawing.Point(12, 71);
            this.buttonCreateInitials.Name = "buttonCreateInitials";
            this.buttonCreateInitials.Size = new System.Drawing.Size(307, 66);
            this.buttonCreateInitials.TabIndex = 0;
            this.buttonCreateInitials.Text = "Создать";
            this.buttonCreateInitials.UseVisualStyleBackColor = true;
            this.buttonCreateInitials.Click += new System.EventHandler(this.buttonCreateInitials_Click);
            // 
            // textBoxInitials
            // 
            this.textBoxInitials.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInitials.Location = new System.Drawing.Point(12, 30);
            this.textBoxInitials.Name = "textBoxInitials";
            this.textBoxInitials.Size = new System.Drawing.Size(307, 26);
            this.textBoxInitials.TabIndex = 1;
            this.textBoxInitials.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Инициалы:";
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Location = new System.Drawing.Point(12, 144);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(307, 23);
            this.progressBarLoad.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoad.TabIndex = 3;
            // 
            // FormCreateInitials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 179);
            this.Controls.Add(this.progressBarLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInitials);
            this.Controls.Add(this.buttonCreateInitials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCreateInitials";
            this.Text = "Create Initials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateInitials;
        private System.Windows.Forms.TextBox textBoxInitials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarLoad;
    }
}