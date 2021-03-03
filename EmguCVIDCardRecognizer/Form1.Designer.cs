namespace EmguCVIDCardRecognizer
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
            this.textRecognize = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.buttonBinarisation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupAdaptiveThreshold = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboAdaptiveThresholdType = new System.Windows.Forms.ComboBox();
            this.numericBlockSize = new System.Windows.Forms.NumericUpDown();
            this.comboThresholdType = new System.Windows.Forms.ComboBox();
            this.groupBinaryThreshold = new System.Windows.Forms.GroupBox();
            this.checkBinaryInv = new System.Windows.Forms.CheckBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.trackThresholdBinary = new System.Windows.Forms.TrackBar();
            this.labelSmooth = new System.Windows.Forms.Label();
            this.numericSmooth = new System.Windows.Forms.NumericUpDown();
            this.checkBinaryThreshold = new System.Windows.Forms.CheckBox();
            this.checkAdaptiveThreshold = new System.Windows.Forms.CheckBox();
            this.pictureDefault = new System.Windows.Forms.PictureBox();
            this.pictureBinarisation = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboDocument = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEngineMode = new System.Windows.Forms.ComboBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupAdaptiveThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBlockSize)).BeginInit();
            this.groupBinaryThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackThresholdBinary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBinarisation)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textRecognize
            // 
            this.textRecognize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRecognize.Location = new System.Drawing.Point(3, 445);
            this.textRecognize.Multiline = true;
            this.textRecognize.Name = "textRecognize";
            this.textRecognize.ReadOnly = true;
            this.textRecognize.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textRecognize.Size = new System.Drawing.Size(439, 232);
            this.textRecognize.TabIndex = 2;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(4, 303);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(125, 25);
            this.buttonOpenFile.TabIndex = 3;
            this.buttonOpenFile.Text = "OpenImage";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(83, 103);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(125, 25);
            this.buttonRecognize.TabIndex = 5;
            this.buttonRecognize.Text = "Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // buttonBinarisation
            // 
            this.buttonBinarisation.Location = new System.Drawing.Point(166, 303);
            this.buttonBinarisation.Name = "buttonBinarisation";
            this.buttonBinarisation.Size = new System.Drawing.Size(125, 25);
            this.buttonBinarisation.TabIndex = 6;
            this.buttonBinarisation.Text = "ConvertImage";
            this.buttonBinarisation.UseVisualStyleBackColor = true;
            this.buttonBinarisation.Click += new System.EventHandler(this.buttonBinarisation_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 301F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textRecognize, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureDefault, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBinarisation, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textResult, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1191, 680);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupAdaptiveThreshold);
            this.panel1.Controls.Add(this.groupBinaryThreshold);
            this.panel1.Controls.Add(this.checkBinaryThreshold);
            this.panel1.Controls.Add(this.checkAdaptiveThreshold);
            this.panel1.Controls.Add(this.buttonBinarisation);
            this.panel1.Controls.Add(this.buttonOpenFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(893, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 436);
            this.panel1.TabIndex = 8;
            // 
            // groupAdaptiveThreshold
            // 
            this.groupAdaptiveThreshold.Controls.Add(this.label6);
            this.groupAdaptiveThreshold.Controls.Add(this.label5);
            this.groupAdaptiveThreshold.Controls.Add(this.label4);
            this.groupAdaptiveThreshold.Controls.Add(this.comboAdaptiveThresholdType);
            this.groupAdaptiveThreshold.Controls.Add(this.numericBlockSize);
            this.groupAdaptiveThreshold.Controls.Add(this.comboThresholdType);
            this.groupAdaptiveThreshold.Location = new System.Drawing.Point(4, 32);
            this.groupAdaptiveThreshold.Name = "groupAdaptiveThreshold";
            this.groupAdaptiveThreshold.Size = new System.Drawing.Size(287, 102);
            this.groupAdaptiveThreshold.TabIndex = 16;
            this.groupAdaptiveThreshold.TabStop = false;
            this.groupAdaptiveThreshold.Text = "AdaptiveThreshold";
            this.groupAdaptiveThreshold.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "BlockSize";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "ThresholdType";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "AdaptiveThresholdType";
            // 
            // comboAdaptiveThresholdType
            // 
            this.comboAdaptiveThresholdType.FormattingEnabled = true;
            this.comboAdaptiveThresholdType.Location = new System.Drawing.Point(136, 19);
            this.comboAdaptiveThresholdType.Name = "comboAdaptiveThresholdType";
            this.comboAdaptiveThresholdType.Size = new System.Drawing.Size(121, 21);
            this.comboAdaptiveThresholdType.TabIndex = 13;
            this.comboAdaptiveThresholdType.SelectedIndexChanged += new System.EventHandler(this.comboAdaptiveThresholdType_SelectedIndexChanged);
            // 
            // numericBlockSize
            // 
            this.numericBlockSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericBlockSize.Location = new System.Drawing.Point(136, 73);
            this.numericBlockSize.Maximum = new decimal(new int[] {
            599,
            0,
            0,
            0});
            this.numericBlockSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBlockSize.Name = "numericBlockSize";
            this.numericBlockSize.Size = new System.Drawing.Size(54, 20);
            this.numericBlockSize.TabIndex = 15;
            this.numericBlockSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBlockSize.ValueChanged += new System.EventHandler(this.numericBlockSize_ValueChanged);
            // 
            // comboThresholdType
            // 
            this.comboThresholdType.FormattingEnabled = true;
            this.comboThresholdType.Location = new System.Drawing.Point(136, 46);
            this.comboThresholdType.Name = "comboThresholdType";
            this.comboThresholdType.Size = new System.Drawing.Size(121, 21);
            this.comboThresholdType.TabIndex = 14;
            this.comboThresholdType.SelectedIndexChanged += new System.EventHandler(this.comboThresholdType_SelectedIndexChanged);
            // 
            // groupBinaryThreshold
            // 
            this.groupBinaryThreshold.Controls.Add(this.checkBinaryInv);
            this.groupBinaryThreshold.Controls.Add(this.labelThreshold);
            this.groupBinaryThreshold.Controls.Add(this.trackThresholdBinary);
            this.groupBinaryThreshold.Controls.Add(this.labelSmooth);
            this.groupBinaryThreshold.Controls.Add(this.numericSmooth);
            this.groupBinaryThreshold.Location = new System.Drawing.Point(3, 163);
            this.groupBinaryThreshold.Name = "groupBinaryThreshold";
            this.groupBinaryThreshold.Size = new System.Drawing.Size(289, 134);
            this.groupBinaryThreshold.TabIndex = 18;
            this.groupBinaryThreshold.TabStop = false;
            this.groupBinaryThreshold.Text = "BinaryThreshold";
            this.groupBinaryThreshold.Visible = false;
            // 
            // checkBinaryInv
            // 
            this.checkBinaryInv.AutoSize = true;
            this.checkBinaryInv.Location = new System.Drawing.Point(137, 26);
            this.checkBinaryInv.Name = "checkBinaryInv";
            this.checkBinaryInv.Size = new System.Drawing.Size(70, 17);
            this.checkBinaryInv.TabIndex = 12;
            this.checkBinaryInv.Text = "BinaryInv";
            this.checkBinaryInv.UseVisualStyleBackColor = true;
            this.checkBinaryInv.CheckedChanged += new System.EventHandler(this.checkBinaryInv_CheckedChanged);
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(10, 27);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(54, 13);
            this.labelThreshold.TabIndex = 8;
            this.labelThreshold.Text = "Threshold";
            // 
            // trackThresholdBinary
            // 
            this.trackThresholdBinary.Location = new System.Drawing.Point(1, 50);
            this.trackThresholdBinary.Maximum = 255;
            this.trackThresholdBinary.Name = "trackThresholdBinary";
            this.trackThresholdBinary.Size = new System.Drawing.Size(287, 45);
            this.trackThresholdBinary.TabIndex = 7;
            this.trackThresholdBinary.Value = 90;
            this.trackThresholdBinary.Scroll += new System.EventHandler(this.trackThreshold_Scroll);
            // 
            // labelSmooth
            // 
            this.labelSmooth.AutoSize = true;
            this.labelSmooth.Location = new System.Drawing.Point(10, 103);
            this.labelSmooth.Name = "labelSmooth";
            this.labelSmooth.Size = new System.Drawing.Size(87, 13);
            this.labelSmooth.TabIndex = 10;
            this.labelSmooth.Text = "SmoothGaussian";
            // 
            // numericSmooth
            // 
            this.numericSmooth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericSmooth.Location = new System.Drawing.Point(137, 101);
            this.numericSmooth.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.numericSmooth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSmooth.Name = "numericSmooth";
            this.numericSmooth.Size = new System.Drawing.Size(54, 20);
            this.numericSmooth.TabIndex = 11;
            this.numericSmooth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSmooth.ValueChanged += new System.EventHandler(this.numericSmooth_ValueChanged);
            // 
            // checkBinaryThreshold
            // 
            this.checkBinaryThreshold.AutoSize = true;
            this.checkBinaryThreshold.Location = new System.Drawing.Point(9, 140);
            this.checkBinaryThreshold.Name = "checkBinaryThreshold";
            this.checkBinaryThreshold.Size = new System.Drawing.Size(102, 17);
            this.checkBinaryThreshold.TabIndex = 17;
            this.checkBinaryThreshold.Text = "BinaryThreshold";
            this.checkBinaryThreshold.UseVisualStyleBackColor = true;
            this.checkBinaryThreshold.CheckedChanged += new System.EventHandler(this.checkBinaryThreshold_CheckedChanged);
            // 
            // checkAdaptiveThreshold
            // 
            this.checkAdaptiveThreshold.AutoSize = true;
            this.checkAdaptiveThreshold.Location = new System.Drawing.Point(9, 9);
            this.checkAdaptiveThreshold.Name = "checkAdaptiveThreshold";
            this.checkAdaptiveThreshold.Size = new System.Drawing.Size(115, 17);
            this.checkAdaptiveThreshold.TabIndex = 12;
            this.checkAdaptiveThreshold.Text = "AdaptiveThreshold";
            this.checkAdaptiveThreshold.UseVisualStyleBackColor = true;
            this.checkAdaptiveThreshold.CheckedChanged += new System.EventHandler(this.checkAdaptiveThreshold_CheckedChanged);
            // 
            // pictureDefault
            // 
            this.pictureDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureDefault.Image = global::EmguCVIDCardRecognizer.Properties.Resources.idcard_ukraine;
            this.pictureDefault.Location = new System.Drawing.Point(3, 3);
            this.pictureDefault.Name = "pictureDefault";
            this.pictureDefault.Size = new System.Drawing.Size(439, 436);
            this.pictureDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDefault.TabIndex = 0;
            this.pictureDefault.TabStop = false;
            // 
            // pictureBinarisation
            // 
            this.pictureBinarisation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBinarisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBinarisation.Location = new System.Drawing.Point(448, 3);
            this.pictureBinarisation.Name = "pictureBinarisation";
            this.pictureBinarisation.Size = new System.Drawing.Size(439, 436);
            this.pictureBinarisation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBinarisation.TabIndex = 1;
            this.pictureBinarisation.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonRecognize);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboDocument);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboLanguage);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboEngineMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(893, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 232);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "TypeDocument";
            // 
            // comboDocument
            // 
            this.comboDocument.FormattingEnabled = true;
            this.comboDocument.Location = new System.Drawing.Point(116, 67);
            this.comboDocument.Name = "comboDocument";
            this.comboDocument.Size = new System.Drawing.Size(166, 21);
            this.comboDocument.TabIndex = 11;
            this.comboDocument.SelectedIndexChanged += new System.EventHandler(this.comboDocument_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "EngineMode";
            // 
            // comboLanguage
            // 
            this.comboLanguage.FormattingEnabled = true;
            this.comboLanguage.Items.AddRange(new object[] {
            "English",
            "Latina",
            "Ukrainian"});
            this.comboLanguage.Location = new System.Drawing.Point(116, 13);
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(166, 21);
            this.comboLanguage.TabIndex = 7;
            this.comboLanguage.SelectedIndexChanged += new System.EventHandler(this.comboLanguages_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Language";
            // 
            // comboEngineMode
            // 
            this.comboEngineMode.FormattingEnabled = true;
            this.comboEngineMode.Location = new System.Drawing.Point(116, 40);
            this.comboEngineMode.Name = "comboEngineMode";
            this.comboEngineMode.Size = new System.Drawing.Size(166, 21);
            this.comboEngineMode.TabIndex = 9;
            this.comboEngineMode.SelectedIndexChanged += new System.EventHandler(this.comboEngineMode_SelectedIndexChanged);
            // 
            // textResult
            // 
            this.textResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResult.Location = new System.Drawing.Point(448, 445);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textResult.Size = new System.Drawing.Size(439, 232);
            this.textResult.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Name = "Form1";
            this.Text = "IDCardReader";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupAdaptiveThreshold.ResumeLayout(false);
            this.groupAdaptiveThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBlockSize)).EndInit();
            this.groupBinaryThreshold.ResumeLayout(false);
            this.groupBinaryThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackThresholdBinary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBinarisation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureDefault;
        private System.Windows.Forms.PictureBox pictureBinarisation;
        private System.Windows.Forms.TextBox textRecognize;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonRecognize;
        private System.Windows.Forms.Button buttonBinarisation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEngineMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.TrackBar trackThresholdBinary;
        private System.Windows.Forms.Label labelSmooth;
        private System.Windows.Forms.NumericUpDown numericSmooth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboDocument;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.CheckBox checkAdaptiveThreshold;
        private System.Windows.Forms.GroupBox groupAdaptiveThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboAdaptiveThresholdType;
        private System.Windows.Forms.NumericUpDown numericBlockSize;
        private System.Windows.Forms.ComboBox comboThresholdType;
        private System.Windows.Forms.CheckBox checkBinaryThreshold;
        private System.Windows.Forms.GroupBox groupBinaryThreshold;
        private System.Windows.Forms.CheckBox checkBinaryInv;
        private System.Windows.Forms.ComboBox comboLanguage;
    }
}

