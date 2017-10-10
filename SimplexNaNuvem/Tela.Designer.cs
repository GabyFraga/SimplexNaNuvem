namespace SimplexNaNuvem
{
    partial class Tela
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.maxMin = new System.Windows.Forms.Label();
            this.radioMax = new System.Windows.Forms.RadioButton();
            this.radioMin = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btnProx = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // maxMin
            // 
            this.maxMin.AutoSize = true;
            this.maxMin.Location = new System.Drawing.Point(52, 20);
            this.maxMin.Name = "maxMin";
            this.maxMin.Size = new System.Drawing.Size(209, 39);
            this.maxMin.TabIndex = 0;
            this.maxMin.Text = "Selecione se o seu problema é de máximo \r\n(maximizar algo, como lucro, por exempl" +
    "o) \r\nou de mínimo (minimizar algo, como custo):";
            // 
            // radioMax
            // 
            this.radioMax.AutoSize = true;
            this.radioMax.Location = new System.Drawing.Point(55, 81);
            this.radioMax.Name = "radioMax";
            this.radioMax.Size = new System.Drawing.Size(61, 17);
            this.radioMax.TabIndex = 1;
            this.radioMax.TabStop = true;
            this.radioMax.Text = "Máximo";
            this.radioMax.UseVisualStyleBackColor = true;
            this.radioMax.CheckedChanged += new System.EventHandler(this.radioMax_CheckedChanged);
            // 
            // radioMin
            // 
            this.radioMin.AutoSize = true;
            this.radioMin.Location = new System.Drawing.Point(183, 81);
            this.radioMin.Name = "radioMin";
            this.radioMin.Size = new System.Drawing.Size(60, 17);
            this.radioMin.TabIndex = 2;
            this.radioMin.TabStop = true;
            this.radioMin.Text = "Mínimo";
            this.radioMin.UseVisualStyleBackColor = true;
            this.radioMin.CheckedChanged += new System.EventHandler(this.radioMin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantas restrições o seu problema apresenta?\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantas variáveis de decisão o seu problema apresenta?\r\n";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(85, 166);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(85, 254);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // btnProx
            // 
            this.btnProx.Location = new System.Drawing.Point(215, 326);
            this.btnProx.Name = "btnProx";
            this.btnProx.Size = new System.Drawing.Size(75, 23);
            this.btnProx.TabIndex = 7;
            this.btnProx.Text = "Próximo >";
            this.btnProx.UseVisualStyleBackColor = true;
            this.btnProx.Click += new System.EventHandler(this.btnProx_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(55, 326);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 8;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Tela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 361);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnProx);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioMin);
            this.Controls.Add(this.radioMax);
            this.Controls.Add(this.maxMin);
            this.Name = "Tela";
            this.Text = "Simplex";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label maxMin;
        private System.Windows.Forms.RadioButton radioMax;
        private System.Windows.Forms.RadioButton radioMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btnProx;
        private System.Windows.Forms.Button Cancelar;
    }
}

