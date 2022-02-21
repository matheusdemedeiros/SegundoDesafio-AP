using System;

namespace SegundoDesafio.ConsoleApp
{

    /*
     Pelo que percebi, para formar o diamante basta somar "2" ao input
    inicial "1" até que ele seja que ele seja igual ao input informado
    pelo usuário. Depois que a line central for escrita basta ir 
    subtraindo "2" até que o input se torne igual a "1" novamente;
     */

    public class Program
    {
        public static void Main()
        {
            #region Declaração de variáveis
            int inputNumerico, qtdEspacos = 1, qtdSimbolos;
            string simbolo = "X", linha = "", input;
            bool EhInputNumerico = false;
            #endregion

            Console.WriteLine("=======================================================================");
            Console.WriteLine("OLÁ, SEJA BEM VINDO AO SISTEMA DE GERAÇÃO DE DIAMANTES!!");

            do
            {
                ApresentarMenuOpcoes();

                input = Console.ReadLine();

                if (input == "s" || input == "S")
                {
                    ApresentarMensagem("\nVOCÊ ESCOLHEU SAIR!!\n", ConsoleColor.Cyan);
                    break;
                }

                else if (EhInputNumerico = int.TryParse(input, out int inputNumericoConvertido))
                {
                    if (EhInputNumerico)
                    {
                        inputNumerico = inputNumericoConvertido;

                        if (inputNumerico <= 0)
                        {
                            ApresentarMensagem("INFORME SOMENTE NÚMEROS POSITIVOS!! TENTE NOVAMENTE!!", ConsoleColor.Red);
                            continue;
                        }

                        else if (EhImpar(inputNumerico))
                        {

                            Console.WriteLine("\n");
                            Console.ForegroundColor = ConsoleColor.Green;

                            #region Código que desenha a parte de cima do diamante

                            qtdSimbolos = 1;

                            while (qtdSimbolos < inputNumerico)
                            {
                                qtdEspacos = DefininirQuantidadeEspacos(inputNumerico, qtdSimbolos);

                                linha = AdicionandoEspacosEmBrancoNaLinha(qtdEspacos, linha);

                                linha = AdicionandoSimbolosNaLinha(qtdSimbolos, linha, simbolo);

                                PrintarLinhaEmTela(linha);

                                linha = LimparLinha();

                                qtdSimbolos = IncrementarQuantidadeDeSimbolos(qtdSimbolos);

                            }

                            #endregion

                            #region Código que desenha a parte do meio do diamante

                            if (qtdSimbolos == inputNumerico)
                            {
                                linha = AdicionandoSimbolosNaLinha(qtdSimbolos, linha, simbolo);

                                PrintarLinhaEmTela(linha);

                                qtdSimbolos = DecrementarQuantidadeDeSimbolos(qtdSimbolos);

                                linha = LimparLinha();
                            }

                            #endregion

                            #region Código que desenha a parte de baixo do diamante

                            while (qtdSimbolos >= 1)
                            {
                                qtdEspacos = DefininirQuantidadeEspacos(inputNumerico, qtdSimbolos);

                                linha = AdicionandoEspacosEmBrancoNaLinha(qtdEspacos, linha);

                                linha = AdicionandoSimbolosNaLinha(qtdSimbolos, linha, simbolo);

                                PrintarLinhaEmTela(linha);

                                linha = LimparLinha();

                                qtdSimbolos = DecrementarQuantidadeDeSimbolos(qtdSimbolos);

                            }

                            #endregion

                            Console.ResetColor();
                        }

                        else
                        {
                            ApresentarMensagem("INFORME SOMENTE NÚMEROS ÍMPARES!! TENTE NOVAMENTE!!", ConsoleColor.Yellow);
                            continue;
                        }
                    }
                }
                else
                {
                    ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);
                    continue;
                }


            } while (input != "s" || input != "S");

        }
        static int DefininirQuantidadeEspacos(int inputNumericoAtual, int qtdSimbolos)
        {
            int retorno = (inputNumericoAtual - qtdSimbolos) / 2;
            return retorno;
        }

        static bool EhImpar(int inputNumerico)
        {
            bool retorno = false;
            if ((inputNumerico % 2) != 0)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return retorno;

        }

        static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine("\n=======================================================================");
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static string AdicionandoEspacosEmBrancoNaLinha(int quantidadeEspacos, string linha)
        {
            for (int j = 0; j < quantidadeEspacos; j++)
            {
                linha += " ";
            }
            string retorno = linha;

            return retorno;
        }

        static string AdicionandoSimbolosNaLinha(int quantidadeSimbolos, string linha, string simbolo)
        {
            for (int j = 0; j < quantidadeSimbolos; j++)
            {
                linha += simbolo;
            }
            string retorno = linha;

            return retorno;
        }

        static string LimparLinha()
        {
            return "";
        }

        static int IncrementarQuantidadeDeSimbolos(int quantidadeSimbolos)
        {
            int retorno = quantidadeSimbolos + 2;
            return retorno;
        }

        static int DecrementarQuantidadeDeSimbolos(int quantidadeSimbolos)
        {
            int retorno = quantidadeSimbolos - 2;
            return retorno;
        }

        static void PrintarLinhaEmTela(string linha)
        {
            Console.WriteLine(linha);
        }

        static void ApresentarMenuOpcoes()
        {
            Console.WriteLine("\n** Digite S para sair;");
            Console.WriteLine("** Ou digite um número ímpar para construir o diamante;");
            Console.Write("Digite aqui: ");
        }
    }
}
