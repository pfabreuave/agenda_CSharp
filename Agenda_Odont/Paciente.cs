using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
    internal class Paciente
    {
        public Paciente() { }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fec_Nac { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Horah { get; set; }
        public Paciente(string nome = "", string cpf = "", string fec_nac = "", string data = "", string hora = "", string horah = null)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Fec_Nac = fec_nac;
            this.Data = data;
            this.Hora = hora;
            this.Horah = horah;
        }
    }
}

