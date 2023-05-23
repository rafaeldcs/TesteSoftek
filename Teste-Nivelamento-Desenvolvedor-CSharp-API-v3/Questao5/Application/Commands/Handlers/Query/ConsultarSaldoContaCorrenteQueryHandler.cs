using Dapper;
using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Application.DTOs;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore;
using System.Data;

namespace Questao5.Application.Commands.Handlers.Query
{
    public class ConsultarSaldoContaCorrenteQueryHandler : IRequestHandler<ConsultarSaldoContaCorrenteQuery, SaldoContaCorrenteDto>
    {
        private readonly IConsultarSaldoContaCorrenteQueryStore _consultarSaldoContaCorrenteQueryStore;

        public ConsultarSaldoContaCorrenteQueryHandler(IConsultarSaldoContaCorrenteQueryStore consultarSaldoContaCorrenteQueryStore)
        {
            _consultarSaldoContaCorrenteQueryStore = consultarSaldoContaCorrenteQueryStore;
        }

        public async Task<SaldoContaCorrenteDto> Handle(ConsultarSaldoContaCorrenteQuery request, CancellationToken cancellationToken)
        {
            // Validações de negócio
            var contaCorrente = await _consultarSaldoContaCorrenteQueryStore.BuscarContaCorrente(request);

            if (contaCorrente == null)
                throw new Exception("Conta corrente não encontrada. Tipo: INVALID_ACCOUNT");

            if (!contaCorrente.Ativo)
                throw new Exception("Conta corrente inativa. Tipo: INACTIVE_ACCOUNT");

            // Calcular saldo da conta corrente
            var saldo = await _consultarSaldoContaCorrenteQueryStore.ConsultaSaldoConta(request);

            var saldoContaCorrenteDto = new SaldoContaCorrenteDto
            {
                NumeroConta = contaCorrente.Numero,
                NomeTitular = contaCorrente.Nome,
                DataHoraConsulta = DateTime.Now,
                Saldo = saldo
            };

            return saldoContaCorrenteDto;
        }
    }
}
