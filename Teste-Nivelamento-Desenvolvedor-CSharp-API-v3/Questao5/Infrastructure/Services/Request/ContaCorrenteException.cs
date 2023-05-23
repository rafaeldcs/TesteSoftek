namespace Questao5.Infrastructure.Services.Request
{
    public class ContaCorrenteException : Exception
    {
        public string TipoFalha { get; }

        public ContaCorrenteException(string tipoFalha, string message) : base(message)
        {
            TipoFalha = tipoFalha;
        }
    }
}
