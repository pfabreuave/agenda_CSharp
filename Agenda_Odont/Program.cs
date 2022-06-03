using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Agenda_Odont
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            CargaPaciente adm = new CargaPaciente();
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("    Menu Principal");
                Console.WriteLine("    ==============");
                Console.WriteLine("1-Cadastro de pacientes");
                Console.WriteLine("2-Agenda");
                Console.WriteLine("3-Fim");
                Console.Write("Elija su Opcion: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        adm.MenuAdm();
                        break;
                    case "2":
                        adm.MenuAge();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(" \n\nObrigado por participar deste projeto");
                        Console.ReadLine();
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n   escolha uma opção válida");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
