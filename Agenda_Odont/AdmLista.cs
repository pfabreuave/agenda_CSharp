using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    [Serializable]
    internal class AdmLista
    {
        //Paciente persona = new Paciente();
        List<Paciente> pacientes = new List<Paciente>();

        public void AgregarPaciente(Paciente persona)
        {
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
    [Serializable]
    internal class Inv
    {

    }
}
