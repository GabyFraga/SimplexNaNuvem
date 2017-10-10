//using backend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexNaNuvem
{
    public partial class DadosSimplex : Form
    {
        public static int quantR;
        public static int quantD;
        public static int contR;
        public static int contD;
        public static string [,] conteudo;
        public static int contadorV = 1;
        public static int contadorV2 = 1;
        public static int inteiro = 0;
        public static Tela tela1;
        public static int quantCliques = 1;
        public static int minMax;
        public static int numLinha = 2;

        int maiorMenor = -1;

        /// <summary>
        /// Construtor da tela Dados Simplex. Recebe dados da tela anterior como parametro
        /// </summary>
        /// <param name="quantRest">Quantidade de restrições selecionadas pelo usuario</param>
        /// <param name="quantDec">Quantidade de variáveis de decisão selecionadas pelo usuário</param>
        /// <param name="tela">Instância da tela anterior</param>
        /// <param name="minMax1">Variávei inteira que traz da tela anterior "0" se o problema for
        /// de min e "1" se for de max</param>
        public DadosSimplex(int quantRest, int quantDec, Tela tela, int minMax1)
        {
            

            InitializeComponent();
            tela1 = tela;
            quantR = quantRest;
            quantD = quantDec;
            minMax = minMax1;

            conteudo = new string[(quantR + 2), (quantD + 3)];


            contD = quantD;  
        }

        /// <summary>
        /// Chama o método para rodar na nuvem. Chamado pelo click no botão executar.
        /// </summary>
        private void Executar_ClickAsync(object sender, EventArgs e)
        {
            
            requisicaoAsync();

        }

        /// <summary>
        /// Consome o webservice. Chama no webservice o calculo do simplex e retorna o resultado.
        /// </summary>
        /// <returns></returns>
        public async Task requisicaoAsync() {
            Input i = new Input() { conteudo = conteudo, quantD = quantD, quantR = quantR};

            var s = JsonConvert.SerializeObject(i);

            using (HttpClient client = new HttpClient())
            {
               client.BaseAddress = new Uri("http://simplexpatgaby.azurewebsites.net/");

               MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string stringData = JsonConvert.SerializeObject(i);


                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/api/Simplex/Solver/", contentData);

                var str = await response.Content.ReadAsStringAsync();
                Console.WriteLine(str);
                str = str.Replace("|", "\n");
                MessageBox.Show(str);
            }
        }

        /// <summary>
        /// Salva na matriz de string os dados referentes ao botão que adiciona as linhas das restricoes
        /// na tabela inicial. Será adicionado uma label para a restrição, depois os valores um a um
        /// e no fim da linha aparece uma tag indicando se a restrição é maior igual ou menor igual.
        /// O método usa um if para testar se o valor inserido é válido, e depois coloca as strings em
        /// um objeto de list. Esse objeto é adicionado ao listview e o listview é atualizado com todos os
        /// valores já inseridos na tabela.
        /// </summary>
        private void Armazenar1_Click(object sender, EventArgs e)
        {
            conteudo[0, quantD + 1] = "Disponibilidade";

            if (minMax == 0)
            {
                conteudo[1, quantD + 2] = "min";
            }
            else
            {
                conteudo[1, quantD + 2] = "max";
            }

            if (maiorMenor == 0)
            {
                conteudo[numLinha, quantD + 2] = "<=";
            }
            else
            {
                conteudo[numLinha, quantD + 2] = ">=";
            }

            contR = quantR * (quantD + 2);

            double n;
            bool eNumero = double.TryParse(valRestricao.Text, out n);

            
            if (contadorV2 <= contR)
            {
                if (valRestricao.Text.Equals(""))
                {
                    MessageBox.Show("Por favor digite o nome da Restrição.");
                }
                else if (!eNumero && ((contadorV % (quantD + 3)) != 0))
                {
                    MessageBox.Show("O valor digitado não corresponde a um numero. Por favor tente novamente! " + contadorV + " " + quantD + " " + contadorV % (quantD + 3));
                }
                else
                {
                    conteudo[numLinha, contadorV] = valRestricao.Text;
                    contadorV++;
                    contadorV2++;
                    valRestricao.Clear();



                    if (contadorV2 == contR + 1)
                    {
                        Armazenar1.Enabled = false;
                        contadorV = 0;
                    }

                }

            }

            else
            {
                Armazenar1.Enabled = false;
                contadorV = 0;
            }
            
            inteiro = 1;

            listView1.Clear();

            for (int j = 0; j < quantR + 2; j++)
            {
                var list = new List<string>();
                for (int i = 0; i < quantD + 3; i++)
                {
                    list.Add(string.Format(" {0,20}",conteudo[j, i]));

                }

                string str = "";

                foreach (string x in list)
                {
                    str = str + x + " ";
                }
                

                ListViewItem item = new ListViewItem();
                item.Text = str;
                listView1.Items.Add(item);

            }
            

            if (contadorV == quantD + 2) {
                numLinha++;
                contadorV = 0;
            }

            listView1.Show();
            quantCliques++;

            for (int i = 0; i < quantR + 2; i++)
            {

                for (int j = 0; j < quantD + 3; j++)
                {

                    Console.Write(conteudo[i, j] + " ");

                }

                Console.WriteLine();

            }

            if (Armazenar1.Enabled == false && armazenar3.Enabled == false && Armazenar4.Enabled == false)
            {
                Executar.Enabled = true;
            }

        }

        
        /// <summary>
        /// Marca a tag para 1 se o radiobutton de maior igual estiver selecionado.
        /// </summary>
        private void maiorIgual_CheckedChanged(object sender, EventArgs e)
        {
            maiorMenor = 1;
        }

        /// <summary>
        /// Marca a tag para 0 se o radiobutton de menor igual estiver selecionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menorIgual_CheckedChanged(object sender, EventArgs e)
        {
            maiorMenor = 0;
        }

        /// <summary>
        /// Salva na matriz de string os dados referentes ao botão que adiciona as labels das variaveis
        /// de decisão na tabela inicial. Será adicionada uma label para cada variável
        /// O método usa um if para testar se o valor inserido é válido, e depois coloca as strings em
        /// um objeto de list. Esse objeto é adicionado ao listview e o listview é atualizado com todos os
        /// valores já inseridos na tabela.
        /// </summary>
        private void armazenar3_Click(object sender, EventArgs e)
        {
            
            conteudo[0, 0] = "_____";
            conteudo[0, quantD + 1] = "Disponibilidade";

            if (contadorV <= quantD)
            {
                if (variaveisDecisao.Text.Equals("")) {
                    MessageBox.Show("Por favor digite o nome da variável de decisão.");
                }
                else
                {
                    conteudo[0, contadorV] = variaveisDecisao.Text;
                    contadorV++;
                    variaveisDecisao.Clear();

                    if (contadorV == quantD + 1) {
                        armazenar3.Enabled = false;
                        contadorV = 0;
                    }

                }
               
            }
            
            else {
                armazenar3.Enabled = false;
                contadorV = 0;
            }

            inteiro = 1;

            listView1.Clear();

            if (inteiro == 1)
            {
                var list = new List<string>();
                for (int i = 0; i < quantD + 3; i++)
                {
                    list.Add(string.Format(" {0,20}", conteudo[0,i]));

                }

                string str = "";

                foreach (string x in list)
                {
                    str = str + x + " ";
                }

                ListViewItem item = new ListViewItem();
                item.Text = str;
                listView1.Items.Add(item);
            }
            listView1.Show();


            
        }

        /// <summary>
        /// Salva na matriz de string os dados referentes ao botão que adiciona a linha da função ótima
        /// na tabela inicial. Será adicionado uma label para a função, depois os valores um a um
        /// e no fim da linha aparece uma tag indicando se o problema tem função ótima max ou min.
        /// O método usa um if para testar se o valor inserido é válido, e depois coloca as strings em
        /// um objeto de list. Esse objeto é adicionado ao listview e o listview é atualizado com todos os
        /// valores já inseridos na tabela.
        /// </summary>
        private void Armazenar4_Click(object sender, EventArgs e)
        {

            conteudo[0, quantD + 1] = "Disponibilidade";

            if (minMax == 0)
            {
                conteudo[1, quantD + 2] = "min";
            }
            else
            {
                conteudo[1, quantD + 2] = "max";
            }

            double n;
            bool eNumero = double.TryParse(tag.Text, out n);

            if (contadorV <= quantD)
            {
                if (tag.Text.Equals(""))
                {
                    MessageBox.Show("Por favor digite o nome da variável de decisão.");
                }
                else if (!eNumero && quantCliques > 1)
                {
                    MessageBox.Show("O valor digitado não corresponde a um numero. Por favor tente novamente!");
                }
                else
                {
                    conteudo[1, contadorV] = tag.Text;
                    contadorV++;
                    tag.Clear();

                    if (contadorV == quantD + 1)
                    {
                        Armazenar4.Enabled = false;
                        contadorV = 0;
                    }

                }

            }

            else
            {
                Armazenar4.Enabled = false;
                contadorV = 0;
            }

            inteiro = 1;

            listView1.Clear();

            for (int j = 0; j <= 1; j++)
            {
                var list = new List<string>();
                for (int i = 0; i < quantD + 3; i++)
                {
                    list.Add(string.Format(" {0,20}", conteudo[j, i]));

                }

                string str = "";

                foreach (string x in list)
                {
                    str = str + x + " ";
                }

                ListViewItem item = new ListViewItem();
                item.Text = str;
                listView1.Items.Add(item);

            }
            

            listView1.Show();
            quantCliques++;
            

            
        }
        
    }
}
