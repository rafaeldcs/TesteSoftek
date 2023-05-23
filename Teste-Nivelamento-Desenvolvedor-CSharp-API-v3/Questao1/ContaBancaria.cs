using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public ContaBancaria(int numeroConta, string TitularConta, double DepositoInicial = 0)
        {
            this.NumeroConta = numeroConta;
            this.TitularConta = TitularConta;
            this.DepositoInicial = DepositoInicial;
        }

        public int NumeroConta { get; set; }
        public string TitularConta { get; set; }
        public double DepositoInicial { get; set; }

        public void Deposito(double quantia)
        {
            if (quantia < 0)
            {
                throw new System.Exception("Valor de Depósito tem que ser maior 0");
            }

            this.DepositoInicial += quantia;
        }
        public void Saque(double quantia)
        {
            //CASO FOSSE NECESSÁRIO VERIFICAR VALOR DO SALDO E O SALDO E TAXA PARA SACAR
            /*if (DepositoInicial < quantia)
            {
                throw new System.Exception("Valor de Saque maior que o valor em conta!");
            }

            if (DepositoInicial < quantia + 3.50)
            {
                throw new System.Exception("Valor de retirada + a taxa é maior que o valor de saldo");
            }*/

            this.DepositoInicial -= quantia + 3.5;
        }

        public void AlterarTitular(string Titular)
        {
            if(string.IsNullOrEmpty(Titular)) 
            {
                throw new System.Exception("Favor Inserir um nome!");
            }

            if (Titular.Equals(this.TitularConta))
            {
                throw new System.Exception("Nome do titular é igual ao existente!");
            }

            this.TitularConta = Titular;
        }

        public override string ToString()
        {
            return "\nConta: " + this.NumeroConta + "\nTitular: " + this.TitularConta + "\nValor Depositado: $" + string.Format("{0:N2}", this.DepositoInicial).Replace(",", ".");
        }
    }
}
