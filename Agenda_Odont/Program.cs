﻿using System;
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
            AdmPaciente adm = new AdmPaciente();
            AdmAgenda ada = new AdmAgenda();

            try
            {
                IFormatter lformatter = new BinaryFormatter();
                Stream lstream = new FileStream("pacientes.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                adm = (AdmPaciente)lformatter.Deserialize(lstream);
                lstream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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
                        ada.MenuAge();
                        break;
                    case "3":
                        
                        IFormatter formatter = new BinaryFormatter();
                        Stream lstream = new FileStream("pacientes.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(lstream, adm);
                        lstream.Close();
                        
                        Console.Clear();
                        Console.WriteLine(" \n\ngracias por participar en este proyecto");
                        Console.ReadLine();
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n   elija una opcion valida");
                        Console.ReadLine();
                        break;


                }
            }
        }
    }
}
