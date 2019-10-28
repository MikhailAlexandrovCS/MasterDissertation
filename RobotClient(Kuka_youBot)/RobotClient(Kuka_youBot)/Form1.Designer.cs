namespace RobotClient_Kuka_youBot_
{
    partial class Form1
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
            this.btnGetPointCloud = new System.Windows.Forms.Button();
            this.btnGetPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetPointCloud
            // 
            this.btnGetPointCloud.Location = new System.Drawing.Point(12, 12);
            this.btnGetPointCloud.Name = "btnGetPointCloud";
            this.btnGetPointCloud.Size = new System.Drawing.Size(240, 52);
            this.btnGetPointCloud.TabIndex = 0;
            this.btnGetPointCloud.Text = "Получение облака точек из файла .pcd";
            this.btnGetPointCloud.UseVisualStyleBackColor = true;
            this.btnGetPointCloud.Click += new System.EventHandler(this.btnGetPointCloud_Click);
            // 
            // btnGetPath
            // 
            this.btnGetPath.Location = new System.Drawing.Point(12, 70);
            this.btnGetPath.Name = "btnGetPath";
            this.btnGetPath.Size = new System.Drawing.Size(240, 49);
            this.btnGetPath.TabIndex = 1;
            this.btnGetPath.Text = "Построить траекторию движения";
            this.btnGetPath.UseVisualStyleBackColor = true;
            this.btnGetPath.Click += new System.EventHandler(this.btnGetPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetPath);
            this.Controls.Add(this.btnGetPointCloud);
            this.Name = "Form1";
            this.Text = "Robot Client (Kuka youBot)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetPointCloud;
        private System.Windows.Forms.Button btnGetPath;
    }
}

