using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class AdmLista
    {
        Paciente persona = new Paciente();
        List<Paciente> pacientes = new List<Paciente>();

        public void AgregarPaciente(Paciente persona)
        {
            Console.WriteLine("llego aqui " + persona.cpf);
      
            Console.ReadKey();
            pacientes.Add(persona);
            
        }
        public void EliminarPaciente(Paciente persona)
        {

            pacientes.Remove(persona);
        }
        public List<Paciente> ObtenerPaciente()
        {
            return pacientes;
        }

    }
}
