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
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reproducirButton = new System.Windows.Forms.Button();
            this.pausarButton = new System.Windows.Forms.Button();
            this.conectarButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "PizarroLovers V2.0 - Music Player";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.conectarButton);
            this.panel1.Controls.Add(this.statusTextBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 331);
            this.panel1.TabIndex = 2;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(44, 273);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(314, 21);
            this.statusTextBox.TabIndex = 3;
            this.statusTextBox.Text = "No se está reproduciendo nada por el momento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pausarButton);
            this.groupBox1.Controls.Add(this.reproducirButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(44, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nokia";
            // 
            // reproducirButton
            // 
            this.reproducirButton.Location = new System.Drawing.Point(17, 27);
            this.reproducirButton.Name = "reproducirButton";
            this.reproducirButton.Size = new System.Drawing.Size(129, 37);
            this.reproducirButton.TabIndex = 1;
            this.reproducirButton.Text = "Reproducir";
            this.reproducirButton.UseVisualStyleBackColor = true;
            this.reproducirButton.Click += new System.EventHandler(this.reproducirButton_Click);
            // 
            // pausarButton
            // 
            this.pausarButton.Location = new System.Drawing.Point(178, 27);
            this.pausarButton.Name = "pausarButton";
            this.pausarButton.Size = new System.Drawing.Size(129, 37);
            this.pausarButton.TabIndex = 2;
            this.pausarButton.Text = "Pausar";
            this.pausarButton.UseVisualStyleBackColor = true;
            this.pausarButton.Click += new System.EventHandler(this.pausarButton_Click);
            // 
            // conectarButton
            // 
            this.conectarButton.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectarButton.Location = new System.Drawing.Point(120, 230);
            this.conectarButton.Name = "conectarButton";
            this.conectarButton.Size = new System.Drawing.Size(152, 37);
            this.conectarButton.TabIndex = 3;
            this.conectarButton.Text = "Conectar arduino";
            this.conectarButton.UseVisualStyleBackColor = true;
            this.conectarButton.Click += new System.EventHandler(this.conectarButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 356);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "PizarroLovers V2.0 - Music Player";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button reproducirButton;
        private System.Windows.Forms.Button pausarButton;
        private System.Windows.Forms.Button conectarButton;
    }
}

