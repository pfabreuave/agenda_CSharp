using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class AdmAgenda
    {
       
        string val = "";
        bool seguir = true;
        
        public void MenuAge()
        {
            while (seguir)
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
                        
                        seguir = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n   elija una opcion valida");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public string Ler(string txt)

        {
            Console.Write(txt + " ");
            val = Console.ReadLine();
            if (val.Length < 1)
            {
                Console.WriteLine(" todos los campos son obligatorios " + txt);
                Ler(txt);
            }


            if (txt == "fecha de agenmeiento DD/MM/AAAA:")
            {
               
                EsFecha(val);

                if (EsFecha(val) == false)
                {
                    Console.WriteLine(" fecha de agendamento errado " + val);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    
                }
            }
            if (txt == "Hoha de agendamento HH:MM :")
            {

                EsFecha(val);

                if (EsFecha(val) == false)
                {
                    Console.WriteLine(" fecha de agendamento errado " + val);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {

                }
            }

            return val;
        }
        public void Agend_Consul()
        {
            AdmLista admLista = new AdmLista();
            Console.Clear();
            Agenda agenda = new Agenda();
            agenda.cpf = Convert.ToString(Ler("CPF:"));
            agenda.data = Convert.ToString(Ler("fecha de agendamento DD/MM/AAAA:"));
            agenda.hora = Convert.ToString(Ler("hora de agendamento HH:MM"));
            List<Paciente> lista = admLista.ObtenerPaciente();

            bool encontrado = false;

            for (int i = 0; i < lista.Count; i++)
            {
                
                if (lista[i].cpf == agenda.cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", lista[i].nome, lista[i].cpf, lista[i].fec_nac + " ja existe");
                    AdmListage admListage = new AdmListage();
                    admListage.AgregarPaciente(agenda);
                    Console.WriteLine(agenda.cpf + " agendamento Adicionado con sucesso");

                    encontrado = true;

                    break;
                }
            }

            if (!encontrado)
            {
               
                Console.WriteLine(agenda.cpf + " paciente debe ser cadastrado");
            }
            Console.ReadKey();

        }
        public void Canc_Agend()
        {

        }
        public void Lista_Agend()
        {

        }
        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
