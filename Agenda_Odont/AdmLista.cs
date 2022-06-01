using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class AdmLista
    {
        public List<Paciente> pacientes = new List<Paciente>();
        int i = 0;

        /*
         *      Os pacientes são adicionados à lista
        */

        public void AgregarPaciente(Paciente persona)

        {
            bool encontrado = false;
            for (i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i].Cpf == persona.Cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", pacientes[i].Nome, pacientes[i].Cpf, pacientes[i].Fec_Nac + " ja existe");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                pacientes.Add (persona);
                Console.WriteLine(persona.Cpf + " Adicionado con sucesso");
            }
            Console.ReadKey();
        }
        public void AgregarAgenda(Paciente persona)
        
        {
            
            bool encontrado = false;
            for (i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i].Cpf == persona.Cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", pacientes[i].Nome, pacientes[i].Cpf, pacientes[i].Fec_Nac + " Agenda confirmada");
                    pacientes[i].Data = persona.Data;
                    pacientes[i].Hora = persona.Hora;
                    pacientes[i].Horah = persona.Horah;
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine(persona.Cpf + " Paciente nao cadastrado");
            }
            Console.ReadKey();
        }

        /*
         *      Os pacientes são removidos da lista
        */

        public void EliminarPaciente(Paciente persona)
        {
            for (i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i].Cpf == persona.Cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", pacientes[i].Nome, pacientes[i].Cpf, pacientes[i].Fec_Nac + " eliminado");
                    pacientes.Remove(pacientes[i]);
                    break;
                }
            }
            if (i == pacientes.Count)
            {
                Console.WriteLine(persona.Cpf + " Nao existe " + " indice " + i);
            }
            Console.ReadKey();
        }

        /*
         *       Agendamento é removido da lista
        */
        public void EliminarAgenda(Paciente persona)
        {
            bool encontrado = false;
            for (i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i].Cpf == persona.Cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", pacientes[i].Nome, pacientes[i].Cpf, pacientes[i].Fec_Nac + " Agenda cancelada");
                    pacientes[i].Data = "";
                    pacientes[i].Hora = "";
                    pacientes[i].Horah = "";
                    break;
                }
            }
            if (!encontrado)
            {
                
                Console.WriteLine(persona.Cpf + " Paciente nao cadastrado");
            }
            Console.ReadKey();
        }

        /*
         *      lista de pacientes classificados pelo CPF
        */

        public void ListaCpf()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("CPF \t\t Nome           \t\t\tDt.Nasc.      Idade");
            Console.WriteLine("---------------------------------------------------------------------------");
            IEnumerable<Paciente> listaOrdenada = pacientes.OrderBy(Lista => Lista.Cpf);
            foreach (Paciente paciente in listaOrdenada)
            {
                string ed = CalcEdad(paciente.Fec_Nac);
                int edad = Convert.ToInt32(ed);
                Console.WriteLine("{0,-16} {1,-37} {2,-10} {3,7}", paciente.Cpf, paciente.Nome, paciente.Fec_Nac, edad);

                if (paciente.Data == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("                 Agendado para: {0,2}", paciente.Data);
                    Console.WriteLine("                 HHMM {0,2} as HHMM {1,2}\n", paciente.Hora, paciente.Hora);
                }
                
            }
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ReadKey();
        }

        /*
         *      lista de pacientes classificados pelo NOME
        */

        public void ListaNome()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("CPF \t\t Nome           \t\t\tDt.Nasc.      Idade");
            Console.WriteLine("---------------------------------------------------------------------------");
            IEnumerable<Paciente> listaOrdenada = pacientes.OrderBy(Lista => Lista.Nome);
            foreach (Paciente paciente in listaOrdenada)
            {
                string ed = CalcEdad(paciente.Fec_Nac);
                int edad = Convert.ToInt32(ed);
                Console.WriteLine("{0,-16} {1,-37} {2,-10} {3,7}", paciente.Cpf, paciente.Nome, paciente.Fec_Nac, edad);

                if (paciente.Data == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("                 Agendado para: {0,2}", paciente.Data);
                    Console.WriteLine("                 HHMM {0,2} as HHMM {1,2}\n", paciente.Hora, paciente.Hora);
                }

            }
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ReadKey();
        }
        public void Lista_agenda()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("CPF \t\t Nome           \t\t\tDt.Nasc.      Idade");
            Console.WriteLine("---------------------------------------------------------------------------");
            IEnumerable<Paciente> listaOrdenada = pacientes.OrderBy(Lista => Lista.Data);
            foreach (Paciente paciente in listaOrdenada)
            {
                if (paciente.Data == null)
                {
                    continue;
                }
                else
                {
                    string ed = CalcEdad(paciente.Fec_Nac);
                    int edad = Convert.ToInt32(ed);
                    Console.WriteLine("{0,-16} {1,-37} {2,-10} {3,7}", paciente.Cpf, paciente.Nome, paciente.Fec_Nac, edad);
                    Console.WriteLine("                 Agendado para: {0,2}", paciente.Data);
                    Console.WriteLine("                 HHMM {0,2} as HHMM {1,2}\n", paciente.Hora, paciente.Horah);
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ReadKey();
        }
        /*
         *      retorna lista de pacientes
        */

        public List<Paciente> ObtenerPaciente()
        {
            return pacientes;
        }

        /*
         *      calcula a idade do paciente
        */

        public static string CalcEdad(string fnac)
        {
            DateTime dat = Convert.ToDateTime(fnac);
            DateTime nacimiento = new DateTime(dat.Year, dat.Month, dat.Day);
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            return edad.ToString();

        }
    }
}
