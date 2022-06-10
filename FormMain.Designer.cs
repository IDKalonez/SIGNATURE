namespace Signature
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.panelDragDrop = new System.Windows.Forms.Panel();
            this.labelDragDrop = new System.Windows.Forms.Label();
            this.buttonSigned = new System.Windows.Forms.Button();
            this.buttonCheckSigned = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteSignature = new System.Windows.Forms.Button();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.textBoxInitials = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panelDragDrop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxFilePath);
            this.groupBox1.Controls.Add(this.panelDragDrop);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(47, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Путь:";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFilePath.Location = new System.Drawing.Point(50, 157);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(422, 26);
            this.textBoxFilePath.TabIndex = 2;
            this.textBoxFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFilePath.DoubleClick += new System.EventHandler(this.textBoxFilePath_DoubleClick);
            // 
            // panelDragDrop
            // 
            this.panelDragDrop.AllowDrop = true;
            this.panelDragDrop.BackColor = System.Drawing.SystemColors.Control;
            this.panelDragDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDragDrop.Controls.Add(this.labelDragDrop);
            this.panelDragDrop.Location = new System.Drawing.Point(103, 20);
            this.panelDragDrop.Name = "panelDragDrop";
            this.panelDragDrop.Size = new System.Drawing.Size(311, 106);
            this.panelDragDrop.TabIndex = 0;
            this.panelDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDragDrop_DragDrop);
            this.panelDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDragDrop_DragEnter);
            this.panelDragDrop.DragLeave += new System.EventHandler(this.panelDragDrop_DragLeave);
            // 
            // labelDragDrop
            // 
            this.labelDragDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDragDrop.Location = new System.Drawing.Point(28, 33);
            this.labelDragDrop.Name = "labelDragDrop";
            this.labelDragDrop.Size = new System.Drawing.Size(252, 34);
            this.labelDragDrop.TabIndex = 0;
            this.labelDragDrop.Text = "Перетащите файл сюда";
            this.labelDragDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSigned
            // 
            this.buttonSigned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSigned.Location = new System.Drawing.Point(12, 351);
            this.buttonSigned.Name = "buttonSigned";
            this.buttonSigned.Size = new System.Drawing.Size(238, 50);
            this.buttonSigned.TabIndex = 2;
            this.buttonSigned.Text = "Подписать";
            this.buttonSigned.UseVisualStyleBackColor = true;
            this.buttonSigned.Click += new System.EventHandler(this.buttonSigned_Click);
            // 
            // buttonCheckSigned
            // 
            this.buttonCheckSigned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckSigned.Location = new System.Drawing.Point(282, 351);
            this.buttonCheckSigned.Name = "buttonCheckSigned";
            this.buttonCheckSigned.Size = new System.Drawing.Size(238, 50);
            this.buttonCheckSigned.TabIndex = 3;
            this.buttonCheckSigned.Text = "Проверить подпись";
            this.buttonCheckSigned.UseVisualStyleBackColor = true;
            this.buttonCheckSigned.Click += new System.EventHandler(this.buttonCheckSigned_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonDeleteSignature);
            this.panel1.Controls.Add(this.buttonCreateUser);
            this.panel1.Controls.Add(this.textBoxInitials);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 98);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteSignature
            // 
            this.buttonDeleteSignature.Enabled = false;
            this.buttonDeleteSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteSignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteSignature.Location = new System.Drawing.Point(420, 19);
            this.buttonDeleteSignature.Name = "buttonDeleteSignature";
            this.buttonDeleteSignature.Size = new System.Drawing.Size(27, 21);
            this.buttonDeleteSignature.TabIndex = 2;
            this.buttonDeleteSignature.Text = "X";
            this.buttonDeleteSignature.UseVisualStyleBackColor = true;
            this.buttonDeleteSignature.Click += new System.EventHandler(this.buttonDeleteSignature_Click);
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateUser.Location = new System.Drawing.Point(102, 52);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(311, 37);
            this.buttonCreateUser.TabIndex = 1;
            this.buttonCreateUser.Text = "Создать нового пользователя";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // textBoxInitials
            // 
            this.textBoxInitials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxInitials.FormattingEnabled = true;
            this.textBoxInitials.Location = new System.Drawing.Point(102, 19);
            this.textBoxInitials.Name = "textBoxInitials";
            this.textBoxInitials.Size = new System.Drawing.Size(311, 21);
            this.textBoxInitials.TabIndex = 0;
            this.textBoxInitials.SelectedIndexChanged += new System.EventHandler(this.textBoxInitials_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 421);
            this.Controls.Add(this.buttonCheckSigned);
            this.Controls.Add(this.buttonSigned);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.Text = "Signature";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelDragDrop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelDragDrop;
        private System.Windows.Forms.Label labelDragDrop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonSigned;
        private System.Windows.Forms.Button buttonCheckSigned;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.ComboBox textBoxInitials;
        private System.Windows.Forms.Button buttonDeleteSignature;
    }
}

