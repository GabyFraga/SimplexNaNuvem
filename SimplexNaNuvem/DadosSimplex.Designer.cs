namespace SimplexNaNuvem
{
    partial class DadosSimplex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DadosSimplex));
            this.Executar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valRestricao = new System.Windows.Forms.TextBox();
            this.Armazenar1 = new System.Windows.Forms.Button();
            this.maiorIgual = new System.Windows.Forms.RadioButton();
            this.menorIgual = new System.Windows.Forms.RadioButton();
            this.variaveisDecisao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.armazenar3 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.tag = new System.Windows.Forms.TextBox();
            this.Armazenar4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Executar
            // 
            this.Executar.Enabled = false;
            this.Executar.Location = new System.Drawing.Point(282, 329);
            this.Executar.Name = "Executar";
            this.Executar.Size = new System.Drawing.Size(75, 23);
            this.Executar.TabIndex = 1;
            this.Executar.Text = "Executar";
            this.Executar.UseVisualStyleBackColor = true;
            this.Executar.Click += new System.EventHandler(this.Executar_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 104);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // valRestricao
            // 
            this.valRestricao.Location = new System.Drawing.Point(18, 291);
            this.valRestricao.Name = "valRestricao";
            this.valRestricao.Size = new System.Drawing.Size(100, 20);
            this.valRestricao.TabIndex = 4;
            // 
            // Armazenar1
            // 
            this.Armazenar1.Location = new System.Drawing.Point(141, 288);
            this.Armazenar1.Name = "Armazenar1";
            this.Armazenar1.Size = new System.Drawing.Size(75, 23);
            this.Armazenar1.TabIndex = 5;
            this.Armazenar1.Text = "Armazenar";
            this.Armazenar1.UseVisualStyleBackColor = true;
            this.Armazenar1.Click += new System.EventHandler(this.Armazenar1_Click);
            // 
            // maiorIgual
            // 
            this.maiorIgual.AutoSize = true;
            this.maiorIgual.Checked = true;
            this.maiorIgual.Location = new System.Drawing.Point(242, 277);
            this.maiorIgual.Name = "maiorIgual";
            this.maiorIgual.Size = new System.Drawing.Size(31, 17);
            this.maiorIgual.TabIndex = 11;
            this.maiorIgual.TabStop = true;
            this.maiorIgual.Text = "≥";
            this.maiorIgual.UseVisualStyleBackColor = true;
            this.maiorIgual.CheckedChanged += new System.EventHandler(this.maiorIgual_CheckedChanged);
            // 
            // menorIgual
            // 
            this.menorIgual.AutoSize = true;
            this.menorIgual.Location = new System.Drawing.Point(242, 308);
            this.menorIgual.Name = "menorIgual";
            this.menorIgual.Size = new System.Drawing.Size(31, 17);
            this.menorIgual.TabIndex = 12;
            this.menorIgual.Text = "≤";
            this.menorIgual.UseVisualStyleBackColor = true;
            this.menorIgual.CheckedChanged += new System.EventHandler(this.menorIgual_CheckedChanged);
            // 
            // variaveisDecisao
            // 
            this.variaveisDecisao.Location = new System.Drawing.Point(18, 36);
            this.variaveisDecisao.Name = "variaveisDecisao";
            this.variaveisDecisao.Size = new System.Drawing.Size(100, 20);
            this.variaveisDecisao.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Digite um a um os nomes das variáveis de decisão.\r\n";
            // 
            // armazenar3
            // 
            this.armazenar3.Location = new System.Drawing.Point(141, 36);
            this.armazenar3.Name = "armazenar3";
            this.armazenar3.Size = new System.Drawing.Size(75, 23);
            this.armazenar3.TabIndex = 16;
            this.armazenar3.Text = "Armazenar";
            this.armazenar3.UseVisualStyleBackColor = true;
            this.armazenar3.Click += new System.EventHandler(this.armazenar3_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(390, 36);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(414, 302);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 52);
            this.label5.TabIndex = 18;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // tag
            // 
            this.tag.Location = new System.Drawing.Point(18, 130);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(100, 20);
            this.tag.TabIndex = 19;
            // 
            // Armazenar4
            // 
            this.Armazenar4.Location = new System.Drawing.Point(141, 130);
            this.Armazenar4.Name = "Armazenar4";
            this.Armazenar4.Size = new System.Drawing.Size(75, 23);
            this.Armazenar4.TabIndex = 20;
            this.Armazenar4.Text = "Armazenar";
            this.Armazenar4.UseVisualStyleBackColor = true;
            this.Armazenar4.Click += new System.EventHandler(this.Armazenar4_Click);
            // 
            // DadosSimplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 367);
            this.Controls.Add(this.Armazenar4);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.armazenar3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.variaveisDecisao);
            this.Controls.Add(this.menorIgual);
            this.Controls.Add(this.maiorIgual);
            this.Controls.Add(this.Armazenar1);
            this.Controls.Add(this.valRestricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Executar);
            this.Name = "DadosSimplex";
            this.Text = "DadosSimplex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Executar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox valRestricao;
        private System.Windows.Forms.Button Armazenar1;
        private System.Windows.Forms.RadioButton maiorIgual;
        private System.Windows.Forms.RadioButton menorIgual;
        private System.Windows.Forms.TextBox variaveisDecisao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button armazenar3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tag;
        private System.Windows.Forms.Button Armazenar4;
    }
}