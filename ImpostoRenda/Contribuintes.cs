using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpostoRenda
{
    public class Contribuinte
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public int Dependentes { get; set; }
        public double RendaBruta { get; set; }
        public string Imposto { get; set; }

        public Contribuinte(int id, string nome, string cpf, int dependentes, double rendaBruta)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Dependentes = dependentes;
            RendaBruta = rendaBruta;
        }

        public double RendaLiquida()
        {
            return RendaBruta -= Dependentes * 0.05;
        }

        public string CalculoIR(double salarioMinimo)
        {
            if (RendaLiquida() < salarioMinimo * 2)
            {
                Imposto = "Isento";
            }
            else if (RendaLiquida() <= salarioMinimo * 4)
            {
                Imposto = Convert.ToString(RendaLiquida() * 0.075);
            }
            else if (RendaLiquida() <= salarioMinimo * 5)
            {
                Imposto = Convert.ToString(RendaLiquida() * 0.15);
            }
            else if (RendaLiquida() <= salarioMinimo * 7)
            {
                Imposto = Convert.ToString(RendaLiquida() * 0.225);
            }
            else
            {
                Imposto = Convert.ToString(RendaLiquida() * 0.275);
            }
            return Imposto;
        }

        public override string ToString()
        {
            return $"{Nome}, {Cpf}, Nº dependentes:" +
                   $"{Dependentes}, renda bruta: R${RendaBruta.ToString("f2")}";
        }
    }
}
