namespace RobotClient_Kuka_youBot_
{
    partial class GetPath
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
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAutomatic = new System.Windows.Forms.RadioButton();
            this.lbPointCloudVertexCount = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lbmaxZ = new System.Windows.Forms.Label();
            this.lbminZ = new System.Windows.Forms.Label();
            this.lbmaxY = new System.Windows.Forms.Label();
            this.lbminY = new System.Windows.Forms.Label();
            this.lbmaxX = new System.Windows.Forms.Label();
            this.lbminX = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudPercentagePointCloud = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudHeightObject = new System.Windows.Forms.NumericUpDown();
            this.nudLengthObject = new System.Windows.Forms.NumericUpDown();
            this.nudWidthObject = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDistanceBetweenVertexes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudIterationCount = new System.Windows.Forms.NumericUpDown();
            this.lbInterationCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudEndZVertex = new System.Windows.Forms.NumericUpDown();
            this.nudEndYVertex = new System.Windows.Forms.NumericUpDown();
            this.nudEndXVertex = new System.Windows.Forms.NumericUpDown();
            this.lbEndZ = new System.Windows.Forms.Label();
            this.lbEndY = new System.Windows.Forms.Label();
            this.lbEndX = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudStartZVertex = new System.Windows.Forms.NumericUpDown();
            this.nudStartYVertex = new System.Windows.Forms.NumericUpDown();
            this.lbStartZ = new System.Windows.Forms.Label();
            this.lbStartY = new System.Windows.Forms.Label();
            this.lbStartX = new System.Windows.Forms.Label();
            this.nudStartXVertex = new System.Windows.Forms.NumericUpDown();
            this.gbChange = new System.Windows.Forms.GroupBox();
            this.rbLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartAlgoritm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.gbInfo.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentagePointCloud)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistanceBetweenVertexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterationCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndZVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndYVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndXVertex)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartZVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartYVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartXVertex)).BeginInit();
            this.gbChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbManual.Location = new System.Drawing.Point(6, 19);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(116, 17);
            this.rbManual.TabIndex = 0;
            this.rbManual.TabStop = true;
            this.rbManual.Text = "Ручная настройка";
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // rbAutomatic
            // 
            this.rbAutomatic.AutoSize = true;
            this.rbAutomatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbAutomatic.Location = new System.Drawing.Point(6, 42);
            this.rbAutomatic.Name = "rbAutomatic";
            this.rbAutomatic.Size = new System.Drawing.Size(165, 17);
            this.rbAutomatic.TabIndex = 1;
            this.rbAutomatic.TabStop = true;
            this.rbAutomatic.Text = "Автоматическая настройка";
            this.rbAutomatic.UseVisualStyleBackColor = true;
            this.rbAutomatic.CheckedChanged += new System.EventHandler(this.rbAutomatic_CheckedChanged);
            // 
            // lbPointCloudVertexCount
            // 
            this.lbPointCloudVertexCount.AutoSize = true;
            this.lbPointCloudVertexCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPointCloudVertexCount.Location = new System.Drawing.Point(9, 26);
            this.lbPointCloudVertexCount.Name = "lbPointCloudVertexCount";
            this.lbPointCloudVertexCount.Size = new System.Drawing.Size(103, 13);
            this.lbPointCloudVertexCount.TabIndex = 2;
            this.lbPointCloudVertexCount.Text = "Количество точек: ";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lbmaxZ);
            this.gbInfo.Controls.Add(this.lbminZ);
            this.gbInfo.Controls.Add(this.lbmaxY);
            this.gbInfo.Controls.Add(this.lbminY);
            this.gbInfo.Controls.Add(this.lbmaxX);
            this.gbInfo.Controls.Add(this.lbminX);
            this.gbInfo.Controls.Add(this.lbPointCloudVertexCount);
            this.gbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbInfo.Location = new System.Drawing.Point(310, 9);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(193, 136);
            this.gbInfo.TabIndex = 3;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация об облаке точек";
            // 
            // lbmaxZ
            // 
            this.lbmaxZ.AutoSize = true;
            this.lbmaxZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbmaxZ.Location = new System.Drawing.Point(9, 113);
            this.lbmaxZ.Name = "lbmaxZ";
            this.lbmaxZ.Size = new System.Drawing.Size(159, 13);
            this.lbmaxZ.TabIndex = 8;
            this.lbmaxZ.Text = "Максимальная координата Z:";
            // 
            // lbminZ
            // 
            this.lbminZ.AutoSize = true;
            this.lbminZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbminZ.Location = new System.Drawing.Point(9, 100);
            this.lbminZ.Name = "lbminZ";
            this.lbminZ.Size = new System.Drawing.Size(156, 13);
            this.lbminZ.TabIndex = 7;
            this.lbminZ.Text = "Минимальная координата Z: ";
            // 
            // lbmaxY
            // 
            this.lbmaxY.AutoSize = true;
            this.lbmaxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbmaxY.Location = new System.Drawing.Point(9, 87);
            this.lbmaxY.Name = "lbmaxY";
            this.lbmaxY.Size = new System.Drawing.Size(162, 13);
            this.lbmaxY.TabIndex = 6;
            this.lbmaxY.Text = "Максимальная координата Y: ";
            // 
            // lbminY
            // 
            this.lbminY.AutoSize = true;
            this.lbminY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbminY.Location = new System.Drawing.Point(9, 74);
            this.lbminY.Name = "lbminY";
            this.lbminY.Size = new System.Drawing.Size(156, 13);
            this.lbminY.TabIndex = 5;
            this.lbminY.Text = "Минимальная координата Y: ";
            // 
            // lbmaxX
            // 
            this.lbmaxX.AutoSize = true;
            this.lbmaxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbmaxX.Location = new System.Drawing.Point(9, 61);
            this.lbmaxX.Name = "lbmaxX";
            this.lbmaxX.Size = new System.Drawing.Size(162, 13);
            this.lbmaxX.TabIndex = 4;
            this.lbmaxX.Text = "Максимальная координата Х: ";
            // 
            // lbminX
            // 
            this.lbminX.AutoSize = true;
            this.lbminX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbminX.Location = new System.Drawing.Point(9, 48);
            this.lbminX.Name = "lbminX";
            this.lbminX.Size = new System.Drawing.Size(156, 13);
            this.lbminX.TabIndex = 3;
            this.lbminX.Text = "Минимальная координата X: ";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.groupBox4);
            this.gbSettings.Controls.Add(this.groupBox3);
            this.gbSettings.Controls.Add(this.nudDistanceBetweenVertexes);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.nudIterationCount);
            this.gbSettings.Controls.Add(this.lbInterationCount);
            this.gbSettings.Controls.Add(this.groupBox2);
            this.gbSettings.Controls.Add(this.groupBox1);
            this.gbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbSettings.Location = new System.Drawing.Point(13, 9);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(291, 338);
            this.gbSettings.TabIndex = 4;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Настройка поиска";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudPercentagePointCloud);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(7, 266);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 65);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дополнительные параметры:";
            // 
            // nudPercentagePointCloud
            // 
            this.nudPercentagePointCloud.Location = new System.Drawing.Point(197, 37);
            this.nudPercentagePointCloud.Name = "nudPercentagePointCloud";
            this.nudPercentagePointCloud.Size = new System.Drawing.Size(74, 20);
            this.nudPercentagePointCloud.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Процент соответвия облако точек:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Необходимо при выборке решения из базы данных";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudHeightObject);
            this.groupBox3.Controls.Add(this.nudLengthObject);
            this.groupBox3.Controls.Add(this.nudWidthObject);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(7, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 93);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Размеры передвигаемого объекта:";
            // 
            // nudHeightObject
            // 
            this.nudHeightObject.Location = new System.Drawing.Point(59, 65);
            this.nudHeightObject.Name = "nudHeightObject";
            this.nudHeightObject.Size = new System.Drawing.Size(120, 20);
            this.nudHeightObject.TabIndex = 5;
            // 
            // nudLengthObject
            // 
            this.nudLengthObject.Location = new System.Drawing.Point(59, 41);
            this.nudLengthObject.Name = "nudLengthObject";
            this.nudLengthObject.Size = new System.Drawing.Size(120, 20);
            this.nudLengthObject.TabIndex = 4;
            // 
            // nudWidthObject
            // 
            this.nudWidthObject.Location = new System.Drawing.Point(59, 18);
            this.nudWidthObject.Name = "nudWidthObject";
            this.nudWidthObject.Size = new System.Drawing.Size(120, 20);
            this.nudWidthObject.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Высота: ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(10, 42);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Длина: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ширина: ";
            // 
            // nudDistanceBetweenVertexes
            // 
            this.nudDistanceBetweenVertexes.Location = new System.Drawing.Point(179, 140);
            this.nudDistanceBetweenVertexes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDistanceBetweenVertexes.Name = "nudDistanceBetweenVertexes";
            this.nudDistanceBetweenVertexes.Size = new System.Drawing.Size(73, 20);
            this.nudDistanceBetweenVertexes.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Расстояние между вершинами:";
            // 
            // nudIterationCount
            // 
            this.nudIterationCount.Location = new System.Drawing.Point(179, 118);
            this.nudIterationCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIterationCount.Name = "nudIterationCount";
            this.nudIterationCount.Size = new System.Drawing.Size(73, 20);
            this.nudIterationCount.TabIndex = 3;
            // 
            // lbInterationCount
            // 
            this.lbInterationCount.AutoSize = true;
            this.lbInterationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInterationCount.Location = new System.Drawing.Point(6, 120);
            this.lbInterationCount.Name = "lbInterationCount";
            this.lbInterationCount.Size = new System.Drawing.Size(119, 13);
            this.lbInterationCount.TabIndex = 2;
            this.lbInterationCount.Text = "Количество итераций:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudEndZVertex);
            this.groupBox2.Controls.Add(this.nudEndYVertex);
            this.groupBox2.Controls.Add(this.nudEndXVertex);
            this.groupBox2.Controls.Add(this.lbEndZ);
            this.groupBox2.Controls.Add(this.lbEndY);
            this.groupBox2.Controls.Add(this.lbEndX);
            this.groupBox2.Location = new System.Drawing.Point(159, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Конечная точка:*";
            // 
            // nudEndZVertex
            // 
            this.nudEndZVertex.Location = new System.Drawing.Point(30, 66);
            this.nudEndZVertex.Name = "nudEndZVertex";
            this.nudEndZVertex.Size = new System.Drawing.Size(63, 20);
            this.nudEndZVertex.TabIndex = 3;
            // 
            // nudEndYVertex
            // 
            this.nudEndYVertex.Location = new System.Drawing.Point(30, 43);
            this.nudEndYVertex.Name = "nudEndYVertex";
            this.nudEndYVertex.Size = new System.Drawing.Size(63, 20);
            this.nudEndYVertex.TabIndex = 4;
            // 
            // nudEndXVertex
            // 
            this.nudEndXVertex.Location = new System.Drawing.Point(30, 18);
            this.nudEndXVertex.Name = "nudEndXVertex";
            this.nudEndXVertex.Size = new System.Drawing.Size(63, 20);
            this.nudEndXVertex.TabIndex = 5;
            // 
            // lbEndZ
            // 
            this.lbEndZ.AutoSize = true;
            this.lbEndZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEndZ.Location = new System.Drawing.Point(7, 68);
            this.lbEndZ.Name = "lbEndZ";
            this.lbEndZ.Size = new System.Drawing.Size(17, 13);
            this.lbEndZ.TabIndex = 5;
            this.lbEndZ.Text = "Z:";
            // 
            // lbEndY
            // 
            this.lbEndY.AutoSize = true;
            this.lbEndY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEndY.Location = new System.Drawing.Point(6, 43);
            this.lbEndY.Name = "lbEndY";
            this.lbEndY.Size = new System.Drawing.Size(17, 13);
            this.lbEndY.TabIndex = 4;
            this.lbEndY.Text = "Y:";
            // 
            // lbEndX
            // 
            this.lbEndX.AutoSize = true;
            this.lbEndX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEndX.Location = new System.Drawing.Point(7, 20);
            this.lbEndX.Name = "lbEndX";
            this.lbEndX.Size = new System.Drawing.Size(17, 13);
            this.lbEndX.TabIndex = 3;
            this.lbEndX.Text = "X:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudStartZVertex);
            this.groupBox1.Controls.Add(this.nudStartYVertex);
            this.groupBox1.Controls.Add(this.lbStartZ);
            this.groupBox1.Controls.Add(this.lbStartY);
            this.groupBox1.Controls.Add(this.lbStartX);
            this.groupBox1.Controls.Add(this.nudStartXVertex);
            this.groupBox1.Location = new System.Drawing.Point(7, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Стартовая точка:*";
            // 
            // nudStartZVertex
            // 
            this.nudStartZVertex.Location = new System.Drawing.Point(30, 66);
            this.nudStartZVertex.Name = "nudStartZVertex";
            this.nudStartZVertex.Size = new System.Drawing.Size(63, 20);
            this.nudStartZVertex.TabIndex = 6;
            // 
            // nudStartYVertex
            // 
            this.nudStartYVertex.Location = new System.Drawing.Point(30, 43);
            this.nudStartYVertex.Name = "nudStartYVertex";
            this.nudStartYVertex.Size = new System.Drawing.Size(63, 20);
            this.nudStartYVertex.TabIndex = 7;
            // 
            // lbStartZ
            // 
            this.lbStartZ.AutoSize = true;
            this.lbStartZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStartZ.Location = new System.Drawing.Point(7, 68);
            this.lbStartZ.Name = "lbStartZ";
            this.lbStartZ.Size = new System.Drawing.Size(17, 13);
            this.lbStartZ.TabIndex = 2;
            this.lbStartZ.Text = "Z:";
            // 
            // lbStartY
            // 
            this.lbStartY.AutoSize = true;
            this.lbStartY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStartY.Location = new System.Drawing.Point(6, 43);
            this.lbStartY.Name = "lbStartY";
            this.lbStartY.Size = new System.Drawing.Size(17, 13);
            this.lbStartY.TabIndex = 1;
            this.lbStartY.Text = "Y:";
            // 
            // lbStartX
            // 
            this.lbStartX.AutoSize = true;
            this.lbStartX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStartX.Location = new System.Drawing.Point(7, 20);
            this.lbStartX.Name = "lbStartX";
            this.lbStartX.Size = new System.Drawing.Size(17, 13);
            this.lbStartX.TabIndex = 0;
            this.lbStartX.Text = "X:";
            // 
            // nudStartXVertex
            // 
            this.nudStartXVertex.Location = new System.Drawing.Point(30, 18);
            this.nudStartXVertex.Name = "nudStartXVertex";
            this.nudStartXVertex.Size = new System.Drawing.Size(63, 20);
            this.nudStartXVertex.TabIndex = 2;
            // 
            // gbChange
            // 
            this.gbChange.Controls.Add(this.rbManual);
            this.gbChange.Controls.Add(this.rbAutomatic);
            this.gbChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbChange.Location = new System.Drawing.Point(310, 151);
            this.gbChange.Name = "gbChange";
            this.gbChange.Size = new System.Drawing.Size(193, 66);
            this.gbChange.TabIndex = 5;
            this.gbChange.TabStop = false;
            this.gbChange.Text = "Выбор режима";
            // 
            // rbLog
            // 
            this.rbLog.Location = new System.Drawing.Point(311, 237);
            this.rbLog.Name = "rbLog";
            this.rbLog.Size = new System.Drawing.Size(192, 162);
            this.rbLog.TabIndex = 6;
            this.rbLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(311, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Логгирование:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "* Координаты центра передвигаемоего объекта";
            // 
            // btnStartAlgoritm
            // 
            this.btnStartAlgoritm.Location = new System.Drawing.Point(13, 354);
            this.btnStartAlgoritm.Name = "btnStartAlgoritm";
            this.btnStartAlgoritm.Size = new System.Drawing.Size(134, 101);
            this.btnStartAlgoritm.TabIndex = 9;
            this.btnStartAlgoritm.Text = "Начать поиск пути";
            this.btnStartAlgoritm.UseVisualStyleBackColor = true;
            this.btnStartAlgoritm.Click += new System.EventHandler(this.btnStartAlgoritm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Просмотреть результат 2D";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 405);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 11;
            this.button2.Text = "Просмотреть результат 3D";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(311, 406);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(190, 49);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "Предварительный просмотр";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // GetPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 480);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStartAlgoritm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbLog);
            this.Controls.Add(this.gbChange);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbInfo);
            this.Name = "GetPath";
            this.Text = "Поиск пути";
            this.Load += new System.EventHandler(this.GetPath_Load);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentagePointCloud)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistanceBetweenVertexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterationCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndZVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndYVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndXVertex)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartZVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartYVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartXVertex)).EndInit();
            this.gbChange.ResumeLayout(false);
            this.gbChange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAutomatic;
        private System.Windows.Forms.Label lbPointCloudVertexCount;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lbmaxZ;
        private System.Windows.Forms.Label lbminZ;
        private System.Windows.Forms.Label lbmaxY;
        private System.Windows.Forms.Label lbminY;
        private System.Windows.Forms.Label lbmaxX;
        private System.Windows.Forms.Label lbminX;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.NumericUpDown nudIterationCount;
        private System.Windows.Forms.Label lbInterationCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudEndZVertex;
        private System.Windows.Forms.NumericUpDown nudEndYVertex;
        private System.Windows.Forms.NumericUpDown nudEndXVertex;
        private System.Windows.Forms.Label lbEndZ;
        private System.Windows.Forms.Label lbEndY;
        private System.Windows.Forms.Label lbEndX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudStartZVertex;
        private System.Windows.Forms.NumericUpDown nudStartYVertex;
        private System.Windows.Forms.Label lbStartZ;
        private System.Windows.Forms.Label lbStartY;
        private System.Windows.Forms.Label lbStartX;
        private System.Windows.Forms.NumericUpDown nudStartXVertex;
        private System.Windows.Forms.GroupBox gbChange;
        private System.Windows.Forms.RichTextBox rbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudPercentagePointCloud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudHeightObject;
        private System.Windows.Forms.NumericUpDown nudLengthObject;
        private System.Windows.Forms.NumericUpDown nudWidthObject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudDistanceBetweenVertexes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartAlgoritm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPreview;
    }
}