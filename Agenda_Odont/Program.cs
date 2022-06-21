using System;


namespace Agenda_Odont
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string opcion_prog;
            CargaPaciente adm = new CargaPaciente();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ CONSULTÓRIO ODONTOLÓGICO ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n" +
                                  "\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PRINCIPAIS OPÇÕES ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t1 - Cadastro de pacientes" +
                                  "\n\t\t\t2 - Agenda" +
                                  "\n\t\t\t3 - Fim");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\t\t\tElija su Opcion: ");
                opcion_prog = Convert.ToString(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                switch (opcion_prog)
                {
                    case ("1"):
                        adm.MenuAdm();
                        break;
                    case ("2"):
                        adm.MenuAge();
                        break;
                    case ("3"):
                        Console.WriteLine(" \n\n\t\t\tObrigado por participar deste projeto");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine(" \n\n\t\t\tescolha uma opção válida");
                        Console.ReadLine();
                        break;
                }
            }
            while (opcion_prog != "3");
        }
    }
}
