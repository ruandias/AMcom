using System.Globalization;

namespace Questao1
{
    public class ContaBancaria 
    {
        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0;
        }
        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            Numero = numero;
            Titular = titular;
            DepositoInicial = depositoInicial;
            Saldo = DepositoInicial;
        }

        private int Numero { get; set; }
        public string Titular { get; set; }
        private double DepositoInicial { get; set; }
        private double Saldo { get; set; }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo.ToString("0.00", CultureInfo.InvariantCulture)}";
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            double taxa = 3.5;

            Saldo = Saldo - (taxa + quantia);
        }

    }
}
