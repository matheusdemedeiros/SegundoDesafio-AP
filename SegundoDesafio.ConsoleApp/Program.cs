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
            int inputNumeric, qtdSpaces, qtdSimbols;
            string s = "", simbol = "X", spaces = " ", line = "", input;
            bool isInputNumeric = false;

            Console.WriteLine("=======================================================================");
            Console.WriteLine("OLÁ, SEJA BEM VINDO AO SISTEMA DE GERAÇÃO DE DIAMANTES!!");

            do
            {
                Console.WriteLine("\n** Digite S para sair;");
                Console.WriteLine("** Ou digite um número ímpar para construir o diamante;");
                Console.Write("Digite aqui: ");

                input = Console.ReadLine();


                if (input == "s" || input == "S")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=======================================================================");
                    Console.WriteLine("\nVOCÊ ESCOLHEU SAIR!!\n");
                    Console.ResetColor();
                    break;
                }
                else if (isInputNumeric = int.TryParse(input, out int resultInput))
                {

                    if (isInputNumeric)
                    {
                        inputNumeric = resultInput;

                        if (inputNumeric <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n=======================================================================");
                            Console.WriteLine("INFORME SOMENTE NÚMEROS POSITIVOS!! TENTE NOVAMENTE!!");
                            Console.ResetColor();
                            continue;
                        }
                        else
                        {
                            if ((inputNumeric % 2) != 0)
                            {
                                Console.WriteLine("\n");
                                Console.ForegroundColor = ConsoleColor.Green;
                                qtdSimbols = 1;

                                for (int i = 0; i < inputNumeric; i++)
                                {

                                    qtdSpaces = (inputNumeric - qtdSimbols) / 2;

                                    for (int j = 0; j < qtdSpaces; j++)
                                    {

                                        line += spaces;
                                    }

                                    for (int k = 0; k < qtdSimbols; k++)
                                    {
                                        s += simbol;
                                    }

                                    qtdSimbols += 2;
                                    line += s;
                                    if ((line.Length > 0) && line.Contains("X"))
                                    {
                                        Console.WriteLine(line);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    line = "";
                                    s = "";

                                    if (qtdSimbols == inputNumeric)
                                    {

                                        for (int l = inputNumeric; l >= 1; l--)
                                        {
                                            qtdSpaces = (inputNumeric - qtdSimbols) / 2;

                                            for (int j = 0; j < qtdSpaces; j++)
                                            {
                                                line += spaces;
                                            }
                                            for (int k = 0; k < qtdSimbols; k++)
                                            {
                                                s += simbol;
                                            }

                                            qtdSimbols -= 2;
                                            line += s;
                                            if ((line.Length > 0) && line.Contains("X"))
                                            {
                                                Console.WriteLine(line);
                                            }
                                            else
                                            {
                                                break;
                                            }

                                            line = "";
                                            s = "";
                                        }
                                    }
                                }

                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n=======================================================================");
                                Console.WriteLine("INFORME SOMENTE NÚMEROS ÍMPARES!! TENTE NOVAMENTE!!");
                                Console.ResetColor();
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n=======================================================================");
                    Console.WriteLine("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!");
                    Console.ResetColor();
                    continue;
                }

            } while (input != "s" || input != "S");
        }
    }
}
