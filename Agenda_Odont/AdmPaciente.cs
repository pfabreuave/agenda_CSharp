using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Odont
{
   
    internal class AdmPaciente
    {
        //@"^\d+,\d{2}$"
        bool continuar = true;
        string val = "";
        readonly AdmLista admLista = new AdmLista();
        //Paciente persona = new Paciente();

        /*
         *      menu de controle do paciente
        */

        public void MenuAdm()
        {
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("    Menu do Cadastro de Pacientes");
                Console.WriteLine("    =============================\n");
                Console.WriteLine("1 - Cadastrar novo paciente");
                Console.WriteLine("2 - Excluir paciente");
                Console.WriteLine("3 - Listar pacientes(ordenado por CPF");
                Console.WriteLine("4 - Listar pacientes(ordenado por nome");
                Console.WriteLine("5 - Voltar p / menu ");
                Console.Write("Elija su Opcion: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Cadastrar();

                        break;
                    case "2":
                        ExcluirPac();

                        break;
                    case "3":
                        admLista.ListaCpf();

                        break;
                    case "4":
                        admLista.ListaNome();

                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine(" \n\n   Escolha uma opção válida");
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
            Console.Write(txt+" ");
            val = Console.ReadLine();
            if (val.Length < 1)
            {
                Console.WriteLine(" Todos os campos são obrigatórios " + txt);
                Ler(txt);
            }
            
            if (txt == "Nombre:")
            {
                if (val.Length < 5)
                {
                    Console.WriteLine(" O nome do paciente deve ter mais de 4 dígitos " + val.Length);
                    Console.ReadKey();
                    Ler(txt);
                }
            }


            if (txt == "CPF:")
            {

                ValidaCPF(val);

                if (ValidaCPF(val) == false)
                {
                    Console.WriteLine(" CPF errado; tente novamente " + val);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    val = val.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                }
            }
            
            if (txt == "data de nascimento DD/MM/AAAA:")
            {
                
                EsFecha(val);
               
                if (EsFecha(val) == false)
                {
                    Console.WriteLine(" data de nascimento errada " + val);
                    Console.ReadKey();
                    Ler(txt);
                }
                else
                {
                    string ed = CalcEdad(val);
                    int edad = Convert.ToInt32(ed);
                    
                    if (edad < 13)
                    {
                        Console.WriteLine(" idade deve ter mais de 13 anos e ter " + edad);
                        Console.ReadKey();
                        Ler(txt);
                    }

                }
            }
            
            return val;
        }

        /*
         *      registrar pacientes
        */

        public void Cadastrar()
        {

            Console.Clear();
            Paciente persona = new Paciente();
            persona.nome = Convert.ToString(Ler("Nome:"));
            persona.cpf = Convert.ToString(Ler("CPF:"));
            persona.fec_nac = Convert.ToString(Ler("data de nascimento DD/MM/AAAA:"));
            admLista.AgregarPaciente(persona);
        }

        /*
         *      excluir paciente
        */

        public void ExcluirPac()
        {
            Console.Clear();
            Paciente persona = new Paciente();
            Console.Write("CPF a Excluir: ");
            string cpf = Console.ReadLine();
            persona.cpf = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            admLista.EliminarPaciente(persona);
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

