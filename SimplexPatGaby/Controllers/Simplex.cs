/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

/**
 *
 * @author Gaby
 */
namespace backend
{
    /// <summary>
    /// Classe do simplex. Atributos:
    /// linhas: quantidade de linhas da tabela do simplex
    /// colunas: quantidade de colunas da tabela do simplex
    /// linhaSelecao: linha selecionada para escolher a coluna permitida
    /// colunaPermitida: coluna permitida da execução
    /// linhaPermitida: linha permitida da execução
    /// elementoPermitidoInvertido: inverso do elemento na posicao linhaPermitida x colunaPermitida
    /// content: matriz de string contendo os valores recebidos pelo front-end
    /// labelColuna: vetor com os nomes das variaveis de cada coluna
    /// labelLinha: vetor com os nomes das variaveis de cada linha
    /// celulaSuperior: matriz com os valores da celula superior da matriz do simplex
    /// celulaInferior: matriz com os valores da celula inferior da matriz do simplex
    /// restricoes: quantidade de restricoes
    /// varaiveisDecisao: quantidade de variaveis de decisao
    /// </summary>
    public class Simplex
    {

        public int linhas, colunas,  linhaSelecao, linhaPermitida, colunaPermitida;
        double elementoPermitidoInvertido;
        string[,] content;
        public string[] labelColuna, labelLinha;
        public double[,] celulaSuperior, celulaInferior;
        int restricoes;
        int variaveisDecisao;

        /// <summary>
        /// Construtor do objeto simplex.
        /// </summary>
        /// <param name="variaveisDecisao">Quantidade de variavies de decisao do problema</param>
        /// <param name="restricoes">Quantidade de restricoes do problema</param>
        /// <param name="conteudo">String contendo os valores digitados pelo usuario</param>
        public Simplex(int variaveisDecisao, int restricoes, string [,] conteudo)
        {
            this.restricoes = restricoes;
            this.variaveisDecisao = variaveisDecisao;
            this.content = new string[(restricoes + 2), (variaveisDecisao + 3)];
            this.linhas = restricoes + 1;
            this.colunas = variaveisDecisao + 1;
            this.content = conteudo;

        }

        
        /// <summary>
        /// Método de debug para mostrar a matriz no console.
        /// </summary>
        /// <param name="matriz">matriz que se deseja mostrar na tela</param>
        public void mostrarMatriz(double[,] matriz)
        {

            Console.Write("-- ");

            for (int k = 0; k < colunas; k++)
            {

                Console.Write(labelLinha[k] + " ");
            }

            Console.WriteLine("");

            for (int i = 0; i < linhas; i++)
            {

                Console.Write(labelColuna[i] + " ");

                for (int j = 0; j < colunas; j++)
                {

                    Console.Write(matriz[i, j] + " ");

                }

                Console.WriteLine("");
            }

        }

        /// <summary>
        /// Reseta a matriz referente a celula Inferior para ser reutilizada
        /// </summary>
        public void limparCelulaInferior()
        {

            for (int i = 0; i < linhas; i++)
            {

                for (int j = 0; j < colunas; j++)
                {

                    celulaInferior[i, j] = 0;

                }
            }

        }

        /// <summary>
        /// Analisa a matriz resultado do simplex de forma a encontrar a solucao final do problema.
        /// </summary>
        /// <returns>String com a resposta da solucao final</returns>
        public string mostrarSolucao()
        {
            string resposta = "";
            bool negativoImpossivel = false;
            bool ilimitado = true;
            bool resp = false;
            int flagOtimo = -1;

            for (int i = 1; i < linhas; i++)
            {

                if (celulaSuperior[i, 0] < 0)
                {

                    for (int j = 1; j < colunas; j++)
                    {

                        if (celulaSuperior[i, j] < 0)
                        {

                            negativoImpossivel = true;
                        }

                    }

                    if (!negativoImpossivel)
                    {

                        resposta = "Solução Impossível: não existe região permissiva. |";
                        resp = true;
                    }

                }

            }

            if (!resp)
            {

                for (int i = 1; i < colunas; i++)
                {

                    if (celulaSuperior[0, i] > 0)
                    {

                        flagOtimo = i;

                    }
                    else if (celulaSuperior[0, i] == 0 && flagOtimo == -1)
                    {

                        flagOtimo = 0;
                    }

                }

                if (flagOtimo == -1)
                {

                    resposta = "Solução ótima: |";
                    for (int i = 1; i < colunas; i++)
                    {

                        resposta += labelLinha[i] + " = " + 0 + "|";

                    }

                    for (int i = 0; i < linhas; i++)
                    {

                        resposta += labelColuna[i] + " = " + celulaSuperior[i, 0] + "|";

                    }
                }
                else if (flagOtimo == 0)
                {

                    resposta = "Múltiplas Soluções: |";
                    for (int i = 1; i < colunas; i++)
                    {

                        resposta += labelLinha[i] + " = " + 0 + "|";

                    }

                    for (int i = 0; i < linhas; i++)
                    {

                        resposta += labelColuna[i] + " = " + celulaSuperior[i, 0] + "|";

                    }
                }
                else
                {

                    for (int i = 1; i < linhas; i++)
                    {

                        if (celulaSuperior[i, flagOtimo] >= 0)
                        {

                            ilimitado = false;

                        }

                    }

                    if (ilimitado)
                    {

                        resposta = "Solução ilimitada!|";

                    }
                    else
                    {

                        resposta = "ERRO!|";

                    }

                }

            }
            return resposta;
        }

        /// <summary>
        /// Analisa se existe elemento positivo na linha do fx na matriz do simplex
        /// </summary>
        /// <returns>true, se existir. false, se nao existir</returns>
        public bool hasPositivoFX()
        {

            bool resp = false;

            for (int i = 1; i < colunas; i++)
            {

                if (celulaSuperior[0, i] > 0)
                {

                    colunaPermitida = i;
                    resp = true;
                    break;

                }
            }

            return resp;

        }

        /// <summary>
        /// Executa o algoritmo da troca entre as celulas superior e inferior do algoritmo
        /// </summary>
        public void algoritmoTroca()
        {

            string temp = "";

            temp = labelLinha[colunaPermitida];
            labelLinha[colunaPermitida] = labelColuna[linhaPermitida];
            labelColuna[linhaPermitida] = temp;

            for (int i = 0; i < linhas; i++)
            {

                for (int j = 0; j < colunas; j++)
                {

                    if (i == linhaPermitida)
                    {

                        celulaSuperior[linhaPermitida, j] = celulaInferior[linhaPermitida, j];
                    }
                    else if (j == colunaPermitida)
                    {

                        celulaSuperior[i, colunaPermitida] = celulaInferior[i, colunaPermitida];
                    }
                    else
                    {

                        celulaSuperior[i, j] += celulaInferior[i, j];
                    }

                }
            }

        }

        /// <summary>
        /// Calcula o falor das celulas inferiores baseado no valor que a celula superior tem na linha
        /// permitida e que a celula inferior tem na coluna permitida
        /// </summary>
        public void calculaDemaisCelulas()
        {

            for (int i = 0; i < linhas; i++)
            {

                for (int j = 0; j < colunas; j++)
                {

                    if (i != linhaPermitida && j != colunaPermitida)
                    {

                        celulaInferior[i, j] = celulaSuperior[linhaPermitida, j]
                                * celulaInferior[i, colunaPermitida];

                    }

                }

            }

        }

        /// <summary>
        /// Calcula os valores a serem inseridos na coluna permitida da célula inferior a partir
        /// do inverso do elemento permitido e da coluna permitida da celula superior
        /// </summary>
        public void calculaColunaPermitida()
        {

            for (int i = 0; i < linhas; i++)
            {

                if (i != linhaPermitida)
                {

                    celulaInferior[i, colunaPermitida]
                            = celulaSuperior[i, colunaPermitida] * elementoPermitidoInvertido * -1;
                }
            }

        }

        /// <summary>
        /// Calcula os valores da linha permitida da celula inferior baseando-se nos valores da linha
        /// permitida da celula superior e no inverso do elemento permitido
        /// </summary>

        public void calculaLinhaPermitida()
        {

            for (int i = 0; i < colunas; i++)
            {

                if (i != colunaPermitida)
                {
                    celulaInferior[linhaPermitida, i]
                            = celulaSuperior[linhaPermitida, i] * elementoPermitidoInvertido;
                }
            }

        }

        /// <summary>
        /// Calcula o inverso do elemento permitido e o armazena na célula correspondente na matriz
        /// celula inferior
        /// </summary>
        public void inverteElementoPermitido()
        {

            elementoPermitidoInvertido = 1 / celulaSuperior[linhaPermitida, colunaPermitida];
            celulaInferior[linhaPermitida, colunaPermitida] = elementoPermitidoInvertido;

        }

        /// <summary>
        /// Seleciona a linha permitida da matriz.
        /// </summary>

        public void selectLinhaPermitida()
        {

            double temp = Double.MaxValue;
            linhaPermitida = 0;
            //bool resp = false;

            for (int i = 1; i < linhas; i++)
            {

                if ((celulaSuperior[i, 0] >= 0
                        && celulaSuperior[i, colunaPermitida] > 0)
                        || (celulaSuperior[i, 0] <= 0
                        && celulaSuperior[i, colunaPermitida] < 0))
                {

                    if (temp > (celulaSuperior[i, 0] / celulaSuperior[i, colunaPermitida]))
                    {

                        temp = celulaSuperior[i, 0] / celulaSuperior[i, colunaPermitida];
                        linhaPermitida = i;

                    }

                }

            }

            //return resp;

        }

        /// <summary>
        /// Seleciona a coluna permitida da matriz.
        /// </summary>

        public void selectColunaPermitida()
        {

            for (int i = 1; i < colunas; i++)
            {

                if (celulaSuperior[linhaSelecao, i] < 0)
                {

                    colunaPermitida = i;
                    break;
                }

            }

        }

        /// <summary>
        /// Verifica se existe membro livre com valor negativo na matriz de celula superior.
        /// </summary>
        /// <returns>true, se exitir. False, se nao existir</returns>

        public bool hasMBNegativo()
        {

            bool resp = false;

            for (int i = 1; i < linhas; i++)
            {

                if (celulaSuperior[i, 0] < 0)
                {

                    linhaSelecao = i;
                    resp = true;
                }

            }

            return resp;

        }

        /// <summary>
        /// Povoa a matriz com os valores recebidos da entrada do front-end.
        /// Nomes de restrições e variaveis de decisao vao para os arrays de linha e coluna, respectivamente
        /// Os valores sao convertidos para double
        /// Trabalha os algebrismos das equações da restricoes e da funcao ótima, já os colocando na
        /// matriz de celula superior com os sinais corretos. Calcula tambem se baseando nas variaveis
        /// de folga e excesso. Todo o algebrismo é feito envolvendo sinais de forma que os valores já
        /// são inseridos na matriz de celula superior com os devidos sinais.
        /// </summary>

        public void popularMatriz()
        {

            for(int i = 0; i< restricoes + 2; i++)
            {

                for (int j = 0; j< variaveisDecisao + 3; j++)
                {

                    Console.Write(content[i, j]);

                }

                Console.WriteLine();

            }

            
            labelColuna = new string[restricoes + 1];
            labelLinha = new string[variaveisDecisao + 1];
            celulaSuperior = new double[restricoes + 1, variaveisDecisao + 1];
            celulaInferior = new double[restricoes + 1, variaveisDecisao + 1];

            labelColuna[0] = "f(x)";
            labelLinha[0] = "ML";

            for(int i = 1; i < labelColuna.Length; i++)
            {
                string label = "x" + (i + variaveisDecisao);
                labelColuna[i] = label;

            }

            for (int i = 1; i < labelLinha.Length; i++)
            {
                labelLinha[i] = content[0, i];

            }

            celulaSuperior[0, 0] = 0;

            if (content[1, variaveisDecisao + 2].Equals("min"))
            {


                for(int i = 1; i <= variaveisDecisao; i++)
                {

                    celulaSuperior[0, i] = Convert.ToDouble(content[1, i]);
                    celulaSuperior[0, i] *= -1;

                }
            }
            else
            {

                for (int i = 1; i <= variaveisDecisao; i++)
                {

                    celulaSuperior[0, i] = Convert.ToDouble(content[1, i]);

                }

            }

            for (int i = 2; i < restricoes + 2; i++)
            {

                if (content[i, variaveisDecisao + 2].Equals(">="))
                {


                    celulaSuperior[i - 1, 0] = Convert.ToDouble(content[i, variaveisDecisao + 1]);
                    celulaSuperior[i - 1, 0] *= -1;

                }
                else
                {

                    celulaSuperior[i - 1, 0] = Convert.ToDouble(content[i, variaveisDecisao + 1]);

                }

            }

            for (int i = 2; i < restricoes + 2; i++)
            {

                if (content[i, variaveisDecisao + 2].Equals(">="))
                {

                    for (int j = 1; j <= variaveisDecisao; j++)
                    {

                        celulaSuperior[i - 1, j] = Convert.ToDouble(content[i, j]);
                        celulaSuperior[i - 1, j] *= -1;

                    }

                }
                else
                {

                    for (int j = 1; j <= variaveisDecisao; j++)
                    {
                        celulaSuperior[i - 1, j] = Convert.ToDouble(content[i, j]);
                    }

                }

            }



           // mostrarMatriz(celulaSuperior);
            

        }

        /// <summary>
        /// Executa o simplex, chamando os métodos. Primeiro a matriz é populada com os valores corretos.
        /// Depois, se entra na primeira fase do algoritmo. Enquanto houver membro livre negativo, 
        /// escolhe-se uma coluna permitida e uma linha permitida. Inverte-se o valor do elemento
        /// permitido, calcula-se o valor de linha e coluna permitidas na celula inferior, calcula
        /// as demais celulas inferiores e executa o algoritmo da troca. Depois, limpa o conteudo da
        /// celula inferior para um reuso posterior.
        /// Na segunda fase do algoritmo, enquanto houver valor positivo na linha do f(x),
        /// escolhe-se uma linha permitida (a coluna já é escolhida no metodo que testa a presença
        /// de valor positivo na linha do f(x). Inverte-se o valor do elemento
        /// permitido, calcula-se o valor de linha e coluna permitidas na celula inferior, calcula
        /// as demais celulas inferiores e executa o algoritmo da troca. Depois, limpa o conteudo da
        /// celula inferior para um reuso posterior.
        /// Por fim, gera-se a string de resposta.
        /// </summary>
        /// <returns>String com a resposta do simplex.</returns>

        public string runSimplex()
        {
            string str = "";
            popularMatriz();

            //primeira fase do algoritmo
            while (hasMBNegativo()) {
                selectColunaPermitida();
                selectLinhaPermitida();
                inverteElementoPermitido();
                calculaLinhaPermitida();
                calculaColunaPermitida();
                calculaDemaisCelulas();
                algoritmoTroca();
                limparCelulaInferior();
            }

            //segunda fase do algoritmo
            while (hasPositivoFX()) {
                selectLinhaPermitida();
                inverteElementoPermitido();
                calculaLinhaPermitida();
                calculaColunaPermitida();
                calculaDemaisCelulas();
                algoritmoTroca();
                limparCelulaInferior();
            }

            //mostrarMatriz(celulaSuperior);
            str = mostrarSolucao();
            return str;
        }

    }
}