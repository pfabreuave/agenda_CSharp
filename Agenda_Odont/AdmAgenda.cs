using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class AdmAgenda
    {
        bool continuar = true;
        Paciente persona = new Paciente();
        List<Paciente> pacientes = new List<Paciente>();
        public void MenuAge()
        {
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("      Agenda");
                Console.WriteLine("      ======\n");
                Console.WriteLine("1 - Agendar consulta");
                Console.WriteLine("2 - Cancelar agendamento");
                Console.WriteLine("3 - Listar agenda");
                Console.WriteLine("4 - Voltar p / menu principal");
                Console.Write("Elija su Opcion: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Agend_Consul();

                        break;
                    case "2":
                        Canc_Agend();

                        break;
                    case "3":
                        Lista_Agend();

                        break;
                    case "4":
                        
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n   elija una opcion valida");
                        Console.ReadLine();
                        break;


                }

            }
        }
        public void Agend_Consul()
        {

        }
        public void Canc_Agend()
        {

        }
        public void Lista_Agend()
        {

        }
    }
}
