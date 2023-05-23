using Dapper;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class ConsultarSaldoContaCorrenteQueryStore : IConsultarSaldoContaCorrenteQueryStore
    {
        private readonly IDbConnection _dbConnection;

        public ConsultarSaldoContaCorrenteQueryStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContaCorrente> BuscarContaCorrente(ConsultarSaldoContaCorrenteQuery request)
        {
           return await _dbConnection.QueryFirstOrDefaultAsync<ContaCorrente>(
                "SELECT * FROM contacorrente WHERE idcontacorrente = @IdContaCorrente",
                new { request.IdContaCorrente });
        }

        public async Task<decimal> ConsultaSaldoConta(ConsultarSaldoContaCorrenteQuery request)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<decimal>(
                "SELECT SUM(CASE WHEN tipomovimento = 'C' THEN valor ELSE -valor END) " +
                "FROM movimento WHERE idcontacorrente = @IdContaCorrente",
                new { request.IdContaCorrente }); ;
        }
    }
}
