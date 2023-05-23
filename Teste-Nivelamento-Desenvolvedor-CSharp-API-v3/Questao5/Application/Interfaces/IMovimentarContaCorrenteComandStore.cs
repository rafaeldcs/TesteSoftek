using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public interface IMovimentarContaCorrenteComandStore
    {
        Task<ContaCorrente> BuscarContaCorrente(MovimentarContaCorrenteCommand request);
        Task<Guid> InserirMovimentacaoConta(MovimentarContaCorrenteCommand request);
    }
}
