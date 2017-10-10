//using backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexNaNuvem
{
    public partial class Tela : Form
    {
        public int quantRest;
        public int quantDec;

        int minMax = -1;

        public Tela()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Radio button que seta a variavel global para 1 se o problema for selecionado como de máximo.
        /// </summary>
        private void radioMax_CheckedChanged(object sender, EventArgs e)
        {
            //MAX
            minMax = 1;

        }

        /// <summary>
        /// Radio button que seta a variavel global para 1 se o problema for selecionado como de mínimo.
        /// </summary>
        private void radioMin_CheckedChanged(object sender, EventArgs e)
        {
            //MIN
            minMax = 0;
        }

        private void btnProx_Click(object sender, EventArgs e)
        {
            if (minMax == -1)
            {

                MessageBox.Show("Selecione se seu problema é de máximo ou mínimo antes de continuar.");

            }
            else
            {
                
                DadosSimplex dadosSimplex = new DadosSimplex(quantRest, quantDec, this, minMax);
                this.Hide();
                dadosSimplex.Show();


            }
        }


        /// <summary>
        /// Cancela a execução da tela.
        /// </summary>
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Pega o valor do numericupdown para restrição e salva a quantidade selecionada na variavel que
        /// guarda a quantidade de restricoes do meu problema.
        /// </summary>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            quantRest = (int)numericUpDown1.Value;
        }

        /// <summary>
        /// Pega o valor do numericupdown para variaveis de decisao e salva a quantidade selecionada 
        /// na variavel que guarda a quantidade de variaveis de decisao do meu problema.
        /// </summary>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            quantDec = (int)numericUpDown2.Value;
        }
    }
}
