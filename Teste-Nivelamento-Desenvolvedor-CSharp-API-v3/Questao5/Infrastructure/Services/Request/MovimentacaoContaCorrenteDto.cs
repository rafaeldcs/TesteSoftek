namespace Questao5.Infrastructure.Services.Request
{
    public class MovimentacaoContaCorrenteDto
    {
        public string IdRequisicao { get; set; }
        public string IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
    }

    public enum TipoMovimento
    {
        Credito,
        Debito
    }
}
