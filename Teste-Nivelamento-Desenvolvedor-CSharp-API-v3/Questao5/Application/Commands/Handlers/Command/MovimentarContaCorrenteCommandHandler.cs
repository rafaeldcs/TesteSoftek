using Dapper;
using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore;
using System.Data;

namespace Questao5.Application.Commands.Handlers.Command
{
    public class MovimentarContaCorrenteCommandHandler : IRequestHandler<MovimentarContaCorrenteCommand, Guid>
    {
        private readonly IMovimentarContaCorrenteComandStore _movimentarContaCorrenteComandStore;

        public MovimentarContaCorrenteCommandHandler(IMovimentarContaCorrenteComandStore movimentarContaCorrenteComandStore)
        {
            _movimentarContaCorrenteComandStore = movimentarContaCorrenteComandStore;
        }

        public async Task<Guid> Handle(MovimentarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            // Validações de negócio
            var contaCorrente = await _movimentarContaCorrenteComandStore.BuscarContaCorrente(request);

            if (contaCorrente == null)
                throw new Exception("Conta corrente não encontrada. Tipo: INVALID_ACCOUNT");

            if (!contaCorrente.Ativo)
                throw new Exception("Conta corrente inativa. Tipo: INACTIVE_ACCOUNT");

            if (request.Valor <= 0)
                throw new Exception("Valor inválido. Tipo: INVALID_VALUE");

            if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
                throw new Exception("Tipo de movimento inválido. Tipo: INVALID_TYPE");

            return await _movimentarContaCorrenteComandStore.InserirMovimentacaoConta(request);
        }
    }
}
