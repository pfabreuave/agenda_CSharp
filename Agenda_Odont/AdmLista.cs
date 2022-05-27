using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class AdmLista
    {
        int i = 0;
       
        public List<Paciente> pacientes = new List<Paciente>();
            
        /*
         *      Os pacientes são adicionados à lista
        */

        public void AgregarPaciente(Paciente persona)

        {
            bool encontrado = false;
            for (i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i].cpf == persona.cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", pacientes[i].nome, pacientes[i].cpf, pacientes[i].fec_nac + " ja existe");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                pacientes.Add(persona);
                Console.WriteLine(persona.cpf + " Adicionado con sucesso");
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
                if (pacientes[i].cpf == persona.cpf)
                {
                    Console.WriteLine("{0}  {1}  {2}", pacientes[i].nome, pacientes[i].cpf, pacientes[i].fec_nac + " eliminado");
                    pacientes.Remove(pacientes[i]);
                    break;
                }
            }
            if (i == pacientes.Count)
            {
                Console.WriteLine(persona.cpf + " Nao existe " + " indice " + i);
            }
            Console.ReadKey();
        }

        /*
         *      lista de pacientes classificados pelo CPF
        */

        public void ListaCpf()
        {
            Console.Clear();
            Console.WriteLine("CPF \t\t Nome    \t\t\tDt.Nasc.   \tIdade");
            Console.WriteLine("-----------------------------------------------------------------------");
            IEnumerable<Paciente> listaOrdenada = pacientes.OrderBy(Lista => Lista.cpf);
            foreach (Paciente paciente in listaOrdenada)
            {
                string ed = CalcEdad(paciente.fec_nac);
                int edad = Convert.ToInt32(ed);
                Console.WriteLine(paciente.cpf + "\t " + paciente.nome + "\t\t" + paciente.fec_nac + "\t" + edad);
            }
            Console.ReadKey();
        }

        /*
         *      lista de pacientes classificados pelo NOME
        */

        public void ListaNome()
        {
            Console.Clear();
            Console.WriteLine("CPF \t\t Nome    \t\t\tDt.Nasc.   \tIdade");
            Console.WriteLine("-----------------------------------------------------------------------");
            IEnumerable<Paciente> listaOrdenada = pacientes.OrderBy(Lista => Lista.nome);
            foreach (Paciente paciente in listaOrdenada)
            {
                string ed = CalcEdad(paciente.fec_nac);
                int edad = Convert.ToInt32(ed);
                Console.WriteLine(paciente.cpf + "\t " + paciente.nome + "\t\t" + paciente.fec_nac + "\t" + edad);
            }
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
