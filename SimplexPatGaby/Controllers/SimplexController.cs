using backend;
using Microsoft.AspNetCore.Mvc;
using SimplexPatGaby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplexPatGaby.Controllers
{

    /// <summary>
    /// Contoller do simplex. 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Simplex")]
    public class SimplexController : Controller
    {

        public SimplexController()
        {

        }

        /// <summary>
        /// Resolve o simplex. Usa um for para formatar a matriz a ser mostrada na matriz de resposta.
        /// Recebe a string com a resposta dos valores finais já formatada pelo simplex.
        /// </summary>
        /// <param name="entrada">Objeto do tipo input com os dados enviados pela tela 
        /// do windows forms</param>
        /// <returns>Retorna uma string com a solução do problema.</returns>
        [HttpPost("Solver/")]
        [Route("Simplex/Solver")]
        public IActionResult Solver([FromBody] Input entrada)
        {

            try
            {

                Simplex simplex = new Simplex(entrada.quantD, entrada.quantR, entrada.conteudo);

                string str = simplex.runSimplex();
                string saida = "";
                saida += "____";

                for (int k = 0; k < simplex.colunas; k++)
                {

                    saida += simplex.labelLinha[k] + " ";
                }

                saida += "|";

                for (int i = 0; i < simplex.linhas; i++)
                {

                    saida += simplex.labelColuna[i] + " ";

                    for (int j = 0; j < simplex.colunas; j++)
                    {

                        saida += simplex.celulaSuperior[i, j] + " ";

                    }

                    saida += "|";
                }

                for (int i = 0; i < entrada.quantR + 2; i++)
                {

                    for (int j = 0; j < entrada.quantD + 3; j++)
                    {

                        Console.Write(entrada.conteudo[i, j] + " ");

                    }

                    Console.WriteLine();

                }

                return Ok(saida + "|" + str);
            }
            catch
            {
                return BadRequest("Não é possível calcular o simplex");
            }
        }
    }
}
