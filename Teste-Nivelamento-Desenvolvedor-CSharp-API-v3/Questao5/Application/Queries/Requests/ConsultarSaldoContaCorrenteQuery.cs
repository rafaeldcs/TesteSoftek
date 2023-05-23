using MediatR;
using Questao5.Application.DTOs;

namespace Questao5.Application.Queries.Requests
{
    public class ConsultarSaldoContaCorrenteQuery : IRequest<SaldoContaCorrenteDto>
    {
        public string IdContaCorrente { get; set; }
    }
}
