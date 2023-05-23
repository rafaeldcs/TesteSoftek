using System;
using System.Globalization;

namespace Questao1 {
    class Program {
        static void Main(string[] args) {

            ContaBancaria conta;

            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S') {
                Console.Write("Entre o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else {
                conta = new ContaBancaria(numero, titular);
            }
            Console.Clear();
            Console.WriteLine(conta);
            int opc = 99;
            do 
            {
                Console.WriteLine("Entre o número da Opção: ");
                Console.WriteLine("1 - Depositar?");
                Console.WriteLine("2 - Sacar(Há uma taxa de 3.50)");
                Console.WriteLine("3 - Alterar Titular");
                Console.WriteLine("0 - Sair");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine();
                            Console.Write("Entre um valor para depósito: ");
                            double quantia = double.Parse(Console.ReadLine().Replace(",","."), CultureInfo.InvariantCulture);
                            conta.Deposito(quantia);
                            Console.Clear();
                            Console.WriteLine("Dados da conta atualizados:");
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.Write(e.Message);
                        }                        
                        break;
                    case 2:
                        try 
                        { 
                            Console.WriteLine();
                            Console.Write("Entre um valor para saque: ");
                            double quantia = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
                            conta.Saque(quantia);
                            Console.Clear();
                            Console.WriteLine("Dados da conta atualizados:");
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.Write(e.Message);
                        }
                        break;
                    case 3:
                        try 
                        { 
                            Console.WriteLine();
                            Console.Write("Digite o novo nome do titular:");
                            conta.AlterarTitular(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Dados da conta atualizados:");
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.Write(e.Message);
                        }
                        break;
                    default:
                        break;
                }
                
                Console.WriteLine(conta);
            } while (opc != 0);
            
            
            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);

            

            

            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}
