namespace RobotClient_Kuka_youBot_
{
    partial class GetPointCloudByPCDfile
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
            this.tbPCDfilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenPCDFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCoordsFile = new System.Windows.Forms.TextBox();
            this.btnConvertToCoordsPCDFileInformation = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPCDfilePath
            // 
            this.tbPCDfilePath.Location = new System.Drawing.Point(12, 26);
            this.tbPCDfilePath.Name = "tbPCDfilePath";
            this.tbPCDfilePath.Size = new System.Drawing.Size(233, 20);
            this.tbPCDfilePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Путь к файлу:";
            // 
            // btnOpenPCDFile
            // 
            this.btnOpenPCDFile.Location = new System.Drawing.Point(252, 22);
            this.btnOpenPCDFile.Name = "btnOpenPCDFile";
            this.btnOpenPCDFile.Size = new System.Drawing.Size(130, 23);
            this.btnOpenPCDFile.TabIndex = 2;
            this.btnOpenPCDFile.Text = "Открыть PCD файл";
            this.btnOpenPCDFile.UseVisualStyleBackColor = true;
            this.btnOpenPCDFile.Click += new System.EventHandler(this.btnOpenPCDFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // tbCoordsFile
            // 
            this.tbCoordsFile.Location = new System.Drawing.Point(12, 89);
            this.tbCoordsFile.Name = "tbCoordsFile";
            this.tbCoordsFile.Size = new System.Drawing.Size(233, 20);
            this.tbCoordsFile.TabIndex = 5;
            // 
            // btnConvertToCoordsPCDFileInformation
            // 
            this.btnConvertToCoordsPCDFileInformation.Location = new System.Drawing.Point(252, 60);
            this.btnConvertToCoordsPCDFileInformation.Name = "btnConvertToCoordsPCDFileInformation";
            this.btnConvertToCoordsPCDFileInformation.Size = new System.Drawing.Size(130, 49);
            this.btnConvertToCoordsPCDFileInformation.TabIndex = 6;
            this.btnConvertToCoordsPCDFileInformation.Text = "Конвертация информацию из файла в координаты";
            this.btnConvertToCoordsPCDFileInformation.UseVisualStyleBackColor = true;
            this.btnConvertToCoordsPCDFileInformation.Click += new System.EventHandler(this.btnConvertToCoordsPCDFileInformation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коэффициент увеличения:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(156, 132);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Путь к файлу с координатами:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(207, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 160);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(362, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 11;
            // 
            // GetPointCloudByPCDfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 195);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConvertToCoordsPCDFileInformation);
            this.Controls.Add(this.tbCoordsFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenPCDFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPCDfilePath);
            this.Name = "GetPointCloudByPCDfile";
            this.Text = "Получение координат облака точек";
            this.Load += new System.EventHandler(this.GetPointCloudByPCDfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPCDfilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenPCDFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCoordsFile;
        private System.Windows.Forms.Button btnConvertToCoordsPCDFileInformation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}