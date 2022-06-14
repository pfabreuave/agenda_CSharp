using System;
using System.Globalization;

namespace Agenda_Odont
{
    internal class CargaPaciente
    {
        bool menu_Paciente = true;
        bool menu_Agenda = true;
        string valores = "";
        readonly AdmLista admLista = new AdmLista();

        /*
         *      menu de controle do paciente
        */

        public void MenuAdm()
        {
            while (menu_Paciente)
            {
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ CADASTRO DE PACIENES ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n" +
                                  "\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PRINCIPAIS OPÇÕES ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t1 - Cadastrar novo paciente" +
                                   "\n\t\t\t2 - Excluir paciente" +
                                   "\n\t\t\t3 - Listar pacientes(ordenado por CPF)" +
                                   "\n\t\t\t4 - Listar pacientes(ordenado por nome)" +
                                   "\n\t\t\t5 - Voltar p / menu ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\t\tElija su Opcion: ");
                string opcion_Paciente = Convert.ToString(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                switch (opcion_Paciente)
                {
                    case ("1"):
                        Cadastrar();
                        break;
                    case ("2"):
                        Excluir_Paciente();
                        break;
                    case ("3"):
                        admLista.ListaCpf();
                        break;
                    case ("4"):
                        admLista.ListaNome();
                        break;
                    case ("5"):
                        menu_Paciente = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n\t\t\tEscolha uma opção válida");
                        Console.ReadLine();
                        break;
                }
            }
        }
        
        public void MenuAge()
        {
            while (menu_Agenda)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ AGENDAMENTO DE PACIENES ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n" +
                                  "\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PRINCIPAIS OPÇÕES ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t1 - Agendar consulta" +
                                   "\n\t\t\t2 - Cancelar agendamento" +
                                   "\n\t\t\t3 - Listar agenda" +
                                   "\n\t\t\t4 - Voltar p / menu principal");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\t\t\tElija su Opcion: ");
                string opcion_Agenda = Convert.ToString(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                switch (opcion_Agenda)
                {
                    case ("1"):
                        Agenda_Consulta();
                        break;
                    case ("2"):
                        Cancela_Agenda();
                        break;
                    case ("3"):
                        admLista.Lista_agenda();
                        break;
                    case ("4"):
                        menu_Agenda = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n\t\t\t   Escolha uma opção válida");
                        Console.ReadLine();
                        break;
                }
            }
        }

        /*
         *      captura e validação do paciente
        */

        public string Ler(string txt)

        {
            Console.Write(txt + " ");
            valores = Console.ReadLine();
            if (valores.Length < 1)
            {
                Console.WriteLine(" Todos os campos são obrigatórios " + txt);
                Ler(txt);
            }

            if (txt == "Nome:")
            {
                if (valores.Length < 5)
                {
                    Console.WriteLine(" O nome do paciente deve ter mais de 4 dígitos " + valores.Length);
                    Console.ReadKey();
                    Ler(txt);
                }
            }

            if (txt == "CPF:")
            {

                ValidaCPF(valores);

                if (ValidaCPF(valores) == false)
                {
                    Console.WriteLine(" CPF errado; tente novamente " + valores);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    valores = valores.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                }
            }

            if (txt == "data de nascimento DD/MM/AAAA:")
            {

                EsFecha(valores);

                if (EsFecha(valores) == false)
                {
                    Console.WriteLine(" data de nascimento errada " + valores);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    string ed = CalcEdad(valores);
                    int edad = Convert.ToInt32(ed);

                    if (edad < 13)
                    {
                        Console.WriteLine(" idade deve ter mais de 13 anos e ter " + edad);
                        Console.ReadKey();
                        Ler(txt);
                    }
                }
            }

            if (txt == "Agenda Data:")
            {
                EsFecha(valores);
                if (EsFecha(valores) == false)
                {
                    Console.WriteLine(" data errada " + valores);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    string fechaini;
                    string mensaje = "";
                    DateTime hoy = DateTime.Today;
                    DateTime fechaini1;
                    fechaini = valores;
                    fechaini1 = Convert.ToDateTime(fechaini, new CultureInfo("es-ES"));
                    if (DateTime.Compare(fechaini1, hoy) < 0)
                    {
                        mensaje += "La fecha  debe ser igual o mayor al dia actual";
                        Console.WriteLine(mensaje);
                        Console.ReadKey();
                        Ler(txt);
                    }
                }
            }

            if (txt == "Hora inicial HHMM:")
            {
                int result;
                int resultd = Int32.Parse(valores);
                if (resultd < 800 || resultd > 1800)
                {
                    Console.WriteLine(" hora deve ser maior ou igual a 8 e menor ou igual a 18 " + valores);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    result = resultd % 100;
                    if (result > 0)
                    {
                        result %= 15;
                        if (result != 0)
                        {
                            Console.WriteLine(" os minutos devem ser um múltiplo de 15 não superior a 45 " + valores);
                            Console.ReadKey();
                            Ler(txt);
                        }
                    }
                }
            }
            if (txt == "Hora final HHMM:")
            {
                int result;
                int resulth = Int32.Parse(valores);
                if (resulth < 800 || resulth > 1800)
                {
                    Console.WriteLine(" hora deve ser maior ou igual a 8 e menor ou igual a 18 " + valores);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    result = resulth % 100;
                    if (result > 0)
                    {
                        result %= 15;
                        if (result != 0)
                        {
                            Console.WriteLine(" os minutos devem ser um múltiplo de 15 não superior a 45 " + valores);
                            Console.ReadKey();
                            Ler(txt);
                        }
                    }
                }
            }

            return valores;
        }

        /*
         *      registrar pacientes
        */

        public void Cadastrar()
        {

            Console.Clear();
            Paciente persona = new Paciente
            {
                Nome = Convert.ToString(Ler("Nome:")),
                Cpf = Convert.ToString(Ler("CPF:")),
                Fec_Nac = Convert.ToString(Ler("data de nascimento DD/MM/AAAA:"))
            };
            admLista.AgregarPaciente(persona);
            
        }
        public void Agenda_Consulta()
        {
            Console.Clear();
            Paciente persona = new Paciente
            {
                Cpf = Convert.ToString(Ler("CPF:")),
                Data = Convert.ToString(Ler("Agenda Data:")),
                Hora = Convert.ToInt32(Ler("Hora inicial HHMM:")),
                Horah = Convert.ToInt32(Ler("Hora Final HHMM:"))

            };
            
            admLista.AgregarAgenda(persona);
            
            
        }

        /*
         *      excluir paciente
        */

        public void Excluir_Paciente()
        {
            Console.Clear();
            Paciente persona = new Paciente();
            Console.Write("CPF a Excluir: ");
            string cpf = Console.ReadLine();
            persona.Cpf = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            admLista.EliminarPaciente(persona);
        }

        public void Cancela_Agenda()
        {
            Paciente persona = new Paciente();
            Console.Write("CPF a Excluir: ");
            string cpf = Console.ReadLine();
            persona.Cpf = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            admLista.EliminarAgenda(persona);
        }

        /*
         *      validação CPF
        */

        static bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);

        }

        /*
         *      Valida Data de nascimento
        */
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

        /*
         *      cálculo de idade
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
