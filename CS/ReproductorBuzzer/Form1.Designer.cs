namespace ReproductorBuzzer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.reproducirButton = new System.Windows.Forms.Button();
            this.pausarButton = new System.Windows.Forms.Button();
            this.conectarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.localMusicButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.songSelectorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.musicComboBox = new System.Windows.Forms.ComboBox();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "PizarroLovers V2.0";
            // 
            // reproducirButton
            // 
            this.reproducirButton.BackColor = System.Drawing.Color.Lime;
            this.reproducirButton.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reproducirButton.Location = new System.Drawing.Point(15, 344);
            this.reproducirButton.Name = "reproducirButton";
            this.reproducirButton.Size = new System.Drawing.Size(48, 33);
            this.reproducirButton.TabIndex = 1;
            this.reproducirButton.Text = "Play";
            this.reproducirButton.UseVisualStyleBackColor = false;
            this.reproducirButton.Click += new System.EventHandler(this.reproducirButton_Click);
            // 
            // pausarButton
            // 
            this.pausarButton.BackColor = System.Drawing.Color.Red;
            this.pausarButton.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pausarButton.Location = new System.Drawing.Point(161, 344);
            this.pausarButton.Name = "pausarButton";
            this.pausarButton.Size = new System.Drawing.Size(57, 33);
            this.pausarButton.TabIndex = 2;
            this.pausarButton.Text = "Pause";
            this.pausarButton.UseVisualStyleBackColor = false;
            this.pausarButton.Click += new System.EventHandler(this.pausarButton_Click);
            // 
            // conectarButton
            // 
            this.conectarButton.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectarButton.Location = new System.Drawing.Point(64, 344);
            this.conectarButton.Name = "conectarButton";
            this.conectarButton.Size = new System.Drawing.Size(96, 33);
            this.conectarButton.TabIndex = 3;
            this.conectarButton.Text = "Connect";
            this.conectarButton.UseVisualStyleBackColor = true;
            this.conectarButton.Click += new System.EventHandler(this.conectarButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 631);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nokia";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Controls.Add(this.okButton);
            this.flowLayoutPanel1.Controls.Add(this.button0);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 478);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(235, 119);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(79, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(157, 32);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(69, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 61);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(79, 61);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(157, 61);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(69, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(3, 90);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(70, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(79, 90);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(72, 23);
            this.button0.TabIndex = 11;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(157, 90);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(70, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.localMusicButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.reproducirButton);
            this.panel1.Controls.Add(this.pausarButton);
            this.panel1.Controls.Add(this.conectarButton);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 426);
            this.panel1.TabIndex = 0;
            // 
            // localMusicButton
            // 
            this.localMusicButton.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localMusicButton.Location = new System.Drawing.Point(15, 383);
            this.localMusicButton.Name = "localMusicButton";
            this.localMusicButton.Size = new System.Drawing.Size(203, 33);
            this.localMusicButton.TabIndex = 4;
            this.localMusicButton.Text = "Use local music";
            this.localMusicButton.UseVisualStyleBackColor = true;
            this.localMusicButton.Click += new System.EventHandler(this.localMusicButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.songSelectorTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.musicComboBox);
            this.panel2.Controls.Add(this.statusTextBox);
            this.panel2.Location = new System.Drawing.Point(15, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 290);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Canción elegida:";
            // 
            // songSelectorTextBox
            // 
            this.songSelectorTextBox.Location = new System.Drawing.Point(146, 218);
            this.songSelectorTextBox.Name = "songSelectorTextBox";
            this.songSelectorTextBox.Size = new System.Drawing.Size(41, 21);
            this.songSelectorTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Música";
            // 
            // musicComboBox
            // 
            this.musicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.musicComboBox.FormattingEnabled = true;
            this.musicComboBox.Location = new System.Drawing.Point(17, 252);
            this.musicComboBox.Name = "musicComboBox";
            this.musicComboBox.Size = new System.Drawing.Size(170, 22);
            this.musicComboBox.TabIndex = 1;
            this.musicComboBox.SelectedIndexChanged += new System.EventHandler(this.musicComboBox_SelectedIndexChanged);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(17, 15);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(170, 167);
            this.statusTextBox.TabIndex = 0;
            this.statusTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(272, 655);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "PizarroLovers V2.0 - Music Player";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reproducirButton;
        private System.Windows.Forms.Button pausarButton;
        private System.Windows.Forms.Button conectarButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox statusTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button localMusicButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox musicComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox songSelectorTextBox;
    }
}

