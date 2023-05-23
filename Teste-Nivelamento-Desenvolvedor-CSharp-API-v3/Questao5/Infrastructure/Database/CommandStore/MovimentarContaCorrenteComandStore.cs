using Dapper;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class MovimentarContaCorrenteComandStore : IMovimentarContaCorrenteComandStore
    {
        private readonly IDbConnection _dbConnection;

        public MovimentarContaCorrenteComandStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContaCorrente> BuscarContaCorrente(MovimentarContaCorrenteCommand request)
        {
           return await _dbConnection.QueryFirstOrDefaultAsync<ContaCorrente>(
                "SELECT * FROM contacorrente WHERE idcontacorrente = @IdContaCorrente",
                new { request.IdContaCorrente });
        }

        public async Task<Guid> InserirMovimentacaoConta(MovimentarContaCorrenteCommand request)
        {
            var movimentoId = Guid.NewGuid();

            await _dbConnection.ExecuteAsync(
                "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) " +
                "VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)",
                new
                {
                    IdMovimento = movimentoId,
                    request.IdContaCorrente,
                    DataMovimento = DateTime.Now.ToString("dd/MM/yyyy"),
                    request.TipoMovimento,
                    request.Valor
                });

            return movimentoId;
        }
    }
}
