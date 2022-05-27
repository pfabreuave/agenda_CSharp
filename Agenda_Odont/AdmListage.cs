using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class AdmListage
    {
       
        List<Agenda> agendas = new List<Agenda>();

        public void AgregarPaciente(Agenda agenda)
        {
            agendas.Add(agenda);
        }
        public void EliminarPaciente(Agenda agenda)
        {
            agendas.Remove(agenda);
        }
        public List<Agenda> ObtenerPaciente()
        {
            return agendas;
        }
    }
}
