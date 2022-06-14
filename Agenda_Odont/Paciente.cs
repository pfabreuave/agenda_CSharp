namespace Agenda_Odont
{
    internal class Paciente
    {
        public Paciente() { }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fec_Nac { get; set; }
        public string Data { get; set; }
        public int Hora { get; set; }
        public int Horah { get; set; }
        public Paciente(string nome = "", string cpf = "", string fec_nac = "", string data = "", int hora = 0, int horah = 0)
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

