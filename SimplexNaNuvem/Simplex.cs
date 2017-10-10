///*
// * To change this license header, choose License Headers in Project Properties.
// * To change this template file, choose Tools | Templates
// * and open the template in the editor.
// */


///*using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.IO;

///**
// *
// * @author Gaby
// */
//namespace backend
//{
//    public class Simplex
//    {

//        public int linhas, colunas, variaveis, linhaSelecao, linhaPermitida, colunaPermitida;
//        double elementoPermitidoInvertido;
//        string[,] content;
//        public string[] labelColuna, labelLinha;
//        public double[,] celulaSuperior, celulaInferior;
//        int restricoes;
//        int variaveisDecisao;

//        public Simplex(int variaveisDecisao, int restricoes, string [,] conteudo)
//        {
//            this.restricoes = restricoes;
//            this.variaveisDecisao = variaveisDecisao;
//            this.content = new string[(restricoes + 2), (variaveisDecisao + 3)];
//            this.linhas = restricoes + 1;
//            this.colunas = variaveisDecisao + 1;
//            this.variaveis = 0;
//            this.content = conteudo;

//        }

//        //public void formatContent()
//        //{

//        //    string replace = "";
//        //    bool clean = false;

//        //    for (int i = 0; i < ???; i++)
//        //    {

//        //        for (int j = 0; j < ???; j++)
//        //        {

//        //            for (int k = 0; k < content[i, j].length(); k++)
//        //            {

//        //                if (!clean && content[i, j].charAt(k) = " ")
//        //                {



//        //                }

//        //            }

//        //        }

//        //    }

//        //}

//        public void mostrarMatriz(double[,] matriz)
//        {

//            Console.Write("-- ");

//            for (int k = 0; k < colunas; k++)
//            {

//                Console.Write(labelLinha[k] + " ");
//            }

//            Console.WriteLine("");

//            for (int i = 0; i < linhas; i++)
//            {

//                Console.Write(labelColuna[i] + " ");

//                for (int j = 0; j < colunas; j++)
//                {

//                    Console.Write(matriz[i, j] + " ");

//                }

//                Console.WriteLine("");
//            }

//        }

//        public void limparCelulaInferior()
//        {

//            for (int i = 0; i < linhas; i++)
//            {

//                for (int j = 0; j < colunas; j++)
//                {

//                    celulaInferior[i, j] = 0;

//                }
//            }

//        }

//        public string mostrarSolucao()
//        {
//            string resposta = "";
//            bool negativoImpossivel = false;
//            bool ilimitado = true;
//            bool resp = false;
//            int flagOtimo = -1;

//            for (int i = 1; i < linhas; i++)
//            {

//                if (celulaSuperior[i, 0] < 0)
//                {

//                    for (int j = 1; j < colunas; j++)
//                    {

//                        if (celulaSuperior[i, j] < 0)
//                        {

//                            negativoImpossivel = true;
//                        }

//                    }

//                    if (!negativoImpossivel)
//                    {

//                        resposta = "Solução Impossível: não existe região permissiva. \n";
//                        resp = true;
//                    }

//                }

//            }

//            if (!resp)
//            {

//                for (int i = 1; i < colunas; i++)
//                {

//                    if (celulaSuperior[0, i] > 0)
//                    {

//                        flagOtimo = i;

//                    }
//                    else if (celulaSuperior[0, i] == 0 && flagOtimo == -1)
//                    {

//                        flagOtimo = 0;
//                    }

//                }

//                if (flagOtimo == -1)
//                {

//                    resposta = "Solução ótima: \n";
//                    for (int i = 1; i < colunas; i++)
//                    {

//                        resposta += labelLinha[i] + " = " + 0 + "\n";

//                    }

//                    for (int i = 0; i < linhas; i++)
//                    {

//                        resposta += labelColuna[i] + " = " + celulaSuperior[i, 0] + "\n";

//                    }
//                }
//                else if (flagOtimo == 0)
//                {

//                    resposta = "Múltiplas Soluções: \n";
//                    for (int i = 1; i < colunas; i++)
//                    {

//                        resposta += labelLinha[i] + " = " + 0 + "\n";

//                    }

//                    for (int i = 0; i < linhas; i++)
//                    {

//                        resposta += labelColuna[i] + " = " + celulaSuperior[i, 0] + "\n";

//                    }
//                }
//                else
//                {

//                    for (int i = 1; i < linhas; i++)
//                    {

//                        if (celulaSuperior[i, flagOtimo] >= 0)
//                        {

//                            ilimitado = false;

//                        }

//                    }

//                    if (ilimitado)
//                    {

//                        resposta = "Solução ilimitada!\n";

//                    }
//                    else
//                    {

//                        resposta = "ERRO!\n";

//                    }

//                }

//            }
//            return resposta;
//        }

//        public bool hasPositivoFX()
//        {

//            bool resp = false;

//            for (int i = 1; i < colunas; i++)
//            {

//                if (celulaSuperior[0, i] > 0)
//                {

//                    colunaPermitida = i;
//                    resp = true;
//                    break;

//                }
//            }

//            return resp;

//        }

//        public void algoritmoTroca()
//        {

//            string temp = "";

//            temp = labelLinha[colunaPermitida];
//            labelLinha[colunaPermitida] = labelColuna[linhaPermitida];
//            labelColuna[linhaPermitida] = temp;

//            for (int i = 0; i < linhas; i++)
//            {

//                for (int j = 0; j < colunas; j++)
//                {

//                    if (i == linhaPermitida)
//                    {

//                        celulaSuperior[linhaPermitida, j] = celulaInferior[linhaPermitida, j];
//                    }
//                    else if (j == colunaPermitida)
//                    {

//                        celulaSuperior[i, colunaPermitida] = celulaInferior[i, colunaPermitida];
//                    }
//                    else
//                    {

//                        celulaSuperior[i, j] += celulaInferior[i, j];
//                    }

//                }
//            }

//        }

//        public void calculaDemaisCelulas()
//        {

//            for (int i = 0; i < linhas; i++)
//            {

//                for (int j = 0; j < colunas; j++)
//                {

//                    if (i != linhaPermitida && j != colunaPermitida)
//                    {

//                        celulaInferior[i, j] = celulaSuperior[linhaPermitida, j]
//                                * celulaInferior[i, colunaPermitida];

//                    }

//                }

//            }

//        }

//        public void calculaColunaPermitida()
//        {

//            for (int i = 0; i < linhas; i++)
//            {

//                if (i != linhaPermitida)
//                {

//                    celulaInferior[i, colunaPermitida]
//                            = celulaSuperior[i, colunaPermitida] * elementoPermitidoInvertido * -1;
//                }
//            }

//        }

//        public void calculaLinhaPermitida()
//        {

//            for (int i = 0; i < colunas; i++)
//            {

//                if (i != colunaPermitida)
//                {
//                    celulaInferior[linhaPermitida, i]
//                            = celulaSuperior[linhaPermitida, i] * elementoPermitidoInvertido;
//                }
//            }

//        }

//        public void inverteElementoPermitido()
//        {

//            elementoPermitidoInvertido = 1 / celulaSuperior[linhaPermitida, colunaPermitida];
//            celulaInferior[linhaPermitida, colunaPermitida] = elementoPermitidoInvertido;

//        }

//        public bool selectLinhaPermitida()
//        {

//            double temp = Double.MaxValue;
//            linhaPermitida = 0;
//            bool resp = false;

//            for (int i = 1; i < linhas; i++)
//            {

//                if ((celulaSuperior[i, 0] >= 0
//                        && celulaSuperior[i, colunaPermitida] > 0)
//                        || (celulaSuperior[i, 0] <= 0
//                        && celulaSuperior[i, colunaPermitida] < 0))
//                {

//                    if (temp > (celulaSuperior[i, 0] / celulaSuperior[i, colunaPermitida]))
//                    {

//                        temp = celulaSuperior[i, 0] / celulaSuperior[i, colunaPermitida];
//                        linhaPermitida = i;

//                    }

//                }

//            }

//            return resp;

//        }

//        public void selectColunaPermitida()
//        {

//            for (int i = 1; i < colunas; i++)
//            {

//                if (celulaSuperior[linhaSelecao, i] < 0)
//                {

//                    colunaPermitida = i;
//                    break;
//                }

//            }

//        }

//        public bool hasMBNegativo()
//        {

//            bool resp = false;

//            for (int i = 1; i < linhas; i++)
//            {

//                if (celulaSuperior[i, 0] < 0)
//                {

//                    linhaSelecao = i;
//                    resp = true;
//                }

//            }

//            return resp;

//        }

//        public void popularMatriz()
//        {

//            //int restricoes = 3;
//            //int variaveisDecisao = 2;
//            //linhas = restricoes + 1;
//            //colunas = variaveisDecisao + 1;

//            //string[,] content = new string[(restricoes+2),(variaveisDecisao + 3)];

//            /*content[0, 0] = "     ";
//            content[0, 1] = "Soleira";
//            content[0, 2] = "Peitoril";
//            content[0, 3] = "Disponibilidade";
//            content[0, 4] = "     ";
//            content[1, 0] = "lucro R$";
//            content[1, 1] = "14,00";
//            content[1, 2] = "22,00";
//            content[1, 3] = "     ";
//            content[1, 4] = "max";
//            content[2, 0] = "Area m²";
//            content[2, 1] = "2";
//            content[2, 2] = "4";
//            content[2, 3] = "250";
//            content[2, 4] = "<=";
//            content[3, 0] = "Tempo min";
//            content[3, 1] = "5";
//            content[3, 2] = "8";
//            content[3, 3] = "460";
//            content[3, 4] = ">=";
//            content[4, 0] = "Teste";
//            content[4, 1] = "1";
//            content[4, 2] = "0";
//            content[4, 3] = "40";
//            content[4, 4] = "<=";
//            */

//            for(int i = 0; i< restricoes + 2; i++)
//            {

//                for (int j = 0; j< variaveisDecisao + 3; j++)
//                {

//                    Console.Write(content[i, j]);

//                }

//                Console.WriteLine();

//            }

            
//            labelColuna = new string[restricoes + 1];
//            labelLinha = new string[variaveisDecisao + 1];
//            celulaSuperior = new double[restricoes + 1, variaveisDecisao + 1];
//            celulaInferior = new double[restricoes + 1, variaveisDecisao + 1];

//            labelColuna[0] = "f(x)";
//            labelLinha[0] = "ML";

//            for(int i = 1; i < labelColuna.Length; i++)
//            {
//                string label = "x" + (i + variaveisDecisao);
//                labelColuna[i] = label;

//            }

//            for (int i = 1; i < labelLinha.Length; i++)
//            {
//                labelLinha[i] = content[0, i];

//            }

//            celulaSuperior[0, 0] = 0;

//            if (content[1, variaveisDecisao + 2].Equals("min"))
//            {


//                for(int i = 1; i <= variaveisDecisao; i++)
//                {

//                    celulaSuperior[0, i] = Convert.ToDouble(content[1, i]);
//                    celulaSuperior[0, i] *= -1;

//                }
//            }
//            else
//            {

//                for (int i = 1; i <= variaveisDecisao; i++)
//                {

//                    celulaSuperior[0, i] = Convert.ToDouble(content[1, i]);

//                }

//            }

//            for (int i = 2; i < restricoes + 2; i++)
//            {

//                if (content[i, variaveisDecisao + 2].Equals(">="))
//                {


//                    celulaSuperior[i - 1, 0] = Convert.ToDouble(content[i, variaveisDecisao + 1]);
//                    celulaSuperior[i - 1, 0] *= -1;

//                }
//                else
//                {

//                    celulaSuperior[i - 1, 0] = Convert.ToDouble(content[i, variaveisDecisao + 1]);

//                }

//            }

//            for (int i = 2; i < restricoes + 2; i++)
//            {

//                if (content[i, variaveisDecisao + 2].Equals(">="))
//                {

//                    for (int j = 1; j <= variaveisDecisao; j++)
//                    {

//                        celulaSuperior[i - 1, j] = Convert.ToDouble(content[i, j]);
//                        celulaSuperior[i - 1, j] *= -1;

//                    }

//                }
//                else
//                {

//                    for (int j = 1; j <= variaveisDecisao; j++)
//                    {
//                        celulaSuperior[i - 1, j] = Convert.ToDouble(content[i, j]);
//                    }

//                }

//            }



//            mostrarMatriz(celulaSuperior);
            

//        }

//        public string runSimplex()
//        {
//            string str = "";
//            popularMatriz();

//            //mostrarMatriz(celulaSuperior);

//            while (hasMBNegativo()) {
//                selectColunaPermitida();
//                selectLinhaPermitida();
//                inverteElementoPermitido();
//                calculaLinhaPermitida();
//                calculaColunaPermitida();
//                calculaDemaisCelulas();
//                algoritmoTroca();
//                limparCelulaInferior();
//            }

//            while (hasPositivoFX()) {
//                selectLinhaPermitida();
//                inverteElementoPermitido();
//                calculaLinhaPermitida();
//                calculaColunaPermitida();
//                calculaDemaisCelulas();
//                algoritmoTroca();
//                limparCelulaInferior();
//            }

//            mostrarMatriz(celulaSuperior);
//            str = mostrarSolucao();
//            return str;
//        }




//        /**
//         * @param args the command line arguments
//         */
//        /*public static void Main()
//        {

//            Simplex simplex = new Simplex();
//            simplex.runSimplex();

//        }*/

//    }
//}