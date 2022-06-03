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
        bool encontrado;
        string mensaje = string.Empty;
        
        /*
         *      Os pacientes são adicionados à lista
        */

        public void AgregarPaciente(Paciente persona)

        {
            encontrado = false;
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
            if (pacientes.Count == 1)

            {
                /*
                *      adicionados à lista para prueba
                */
                pacientes.Add(new Paciente() { Nome = "ADRIANA SAMPAIO", Cpf = "109.079.268-94", Fec_Nac = "12/02/1989", Data = "07/07/2022", Hora = 1400, Horah = 1530 });
                pacientes.Add(new Paciente() { Nome = "CLAYTON DIVINO BOCH", Cpf = "107.233.478-08", Fec_Nac = "16/08/1978" });
                pacientes.Add(new Paciente() { Nome = "ALINE NUNES", Cpf = "276.729.038-29", Fec_Nac = "18/06/2001", Data = "05/08/2022", Hora = 1200, Horah = 1430 });
                pacientes.Add(new Paciente() { Nome = "JOSÉ ROBERTO", Cpf = "928.484.191-72", Fec_Nac = "15/07/1989", Data = "05/08/2022", Hora = 900, Horah = 1030 });
            }
            
            Console.ReadKey();
            
        }

        /*
         *      Os pacientes são agendados na lista
        */
        public void AgregarAgenda(Paciente persona)
        {
            encontrado = false;
            for (i = 0; i < pacientes.Count; i++)
            {
                
                if (pacientes[i].Cpf.Equals(persona.Cpf))
                    {
                    encontrado = true;
                    VerificaAgenda(persona);
                    break;
                    }
            }
            if (!encontrado)
            {
                mensaje += " \n Solicitud para " + persona.Cpf + " ";
                mensaje += "\n no es posible agendar";
                Console.WriteLine(mensaje);
            }
            else
            {
                Console.WriteLine("{0}  {1}  {2}", pacientes[i].Nome, pacientes[i].Cpf, pacientes[i].Fec_Nac + " Agenda confirmada");
                pacientes[i].Data = persona.Data;
                pacientes[i].Hora = persona.Hora;
                pacientes[i].Horah = persona.Horah;
            }
            Console.ReadKey();
            mensaje = " ";
        }

        public void VerificaAgenda(Paciente persona)
        {
            int h1 = persona.Hora;
            int h2 = persona.Horah;
            int hh1;
            int hh2;
            for (int j = 0; j < pacientes.Count; j++)
            {
                hh1 = pacientes[j].Hora;
                hh2 = pacientes[j].Horah;
                
                if (pacientes[j].Data == (persona.Data))
                {
                    if ((h1 >= hh1 && h1 <= hh2) || (h2 >= hh1 && h2 <= hh2))
                    {
                        encontrado = false;
                        mensaje += "\n horario ocupado por " + pacientes[j].Nome;
                        break;
                    }
                }
            }
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
                    pacientes[i].Data = null;
                    pacientes[i].Hora = 0;
                    pacientes[i].Horah = 0;
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
                    Console.WriteLine("                 HHMM {0,2} as HHMM {1,2}", paciente.Hora, paciente.Hora);
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
                    Console.WriteLine("                 HHMM {0,2} as HHMM {1,2}", paciente.Hora, paciente.Hora);
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
            IEnumerable<Paciente> listaOrdenada = pacientes.OrderBy(Lista => Lista.Data)
                                                           .ThenBy(Lista => Lista.Hora);
                    
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
