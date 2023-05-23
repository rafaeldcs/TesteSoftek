using MediatR;
using Questao5.Application.DTOs;
using Questao5.Application.Queries.Requests;

namespace Questao5.Application.Commands.Requests
{
    public class ConsultarSaldoContaCorrenteQueryHandler : IRequest<SaldoContaCorrenteDto>
    {
        public string IdContaCorrente { get; set; }
    }
}
