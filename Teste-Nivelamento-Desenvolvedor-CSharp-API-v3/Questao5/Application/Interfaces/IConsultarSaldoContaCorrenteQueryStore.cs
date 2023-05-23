using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public interface IConsultarSaldoContaCorrenteQueryStore
    {
        Task<ContaCorrente> BuscarContaCorrente(ConsultarSaldoContaCorrenteQuery request);
        Task<decimal> ConsultaSaldoConta(ConsultarSaldoContaCorrenteQuery request);
    }
}
