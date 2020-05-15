using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoRenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Deseja cadastrar contribuinte s/S: ");
            List<Contribuinte> listaContribuintes = new List<Contribuinte>();
            char resp = char.Parse(Console.ReadLine());
            Console.WriteLine();
            int id = 1;

            while (resp == 's' || resp == 'S')
            {
                
                Console.WriteLine($"ID: {id}");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("CPF: ");
                string cpf = Console.ReadLine();
                Console.Write("Nº dependentes: ");
                int dependentes = int.Parse(Console.ReadLine());
                Console.Write("Renda bruta mensal: ");
                double rendaBruta = double.Parse(Console.ReadLine());
                Console.WriteLine();

                listaContribuintes.Add(new Contribuinte(id, nome, cpf, dependentes, rendaBruta));

                Console.Write("Deseja cadastrar novo contribuinte? ");
                resp = char.Parse(Console.ReadLine());
                switch(resp)
                {
                    case 's':
                        id++;
                        break;
                    case 'S':
                        id++;
                        break;
                }
               
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (Contribuinte list in listaContribuintes)
            {
                Console.WriteLine(list);
            }
            Console.WriteLine();

            Console.Write("Informe o valor do salario minimo atual: ");
            double salarioMinimo = double.Parse(Console.ReadLine());

            List<Contribuinte> contribuintesImposto = new List<Contribuinte>();

            foreach (Contribuinte contribuinte in listaContribuintes)
            {
                
                contribuinte.RendaLiquida();
                contribuinte.CalculoIR(salarioMinimo);
                contribuintesImposto.Add(contribuinte);
            }

            foreach (Contribuinte contribuinte in contribuintesImposto)
            {
                Console.WriteLine($"{contribuinte.Nome}, {contribuinte.Imposto}");
            }


            Console.ReadKey();

            
        }
    }
}
