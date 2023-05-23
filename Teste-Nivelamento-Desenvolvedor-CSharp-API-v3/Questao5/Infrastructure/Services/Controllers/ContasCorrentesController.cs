using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;
using Questao5.Infrastructure.Services.Request;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaCorrenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("movimentar")]
        public async Task<IActionResult> MovimentarContaCorrente(MovimentarContaCorrenteCommand command)
        {
            try
            {
                var movimentoId = await _mediator.Send(command);
                return Ok(new { MovimentoId = movimentoId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("saldo/{idContaCorrente}")]
        public async Task<IActionResult> ConsultarSaldoContaCorrente(string idContaCorrente)
        {
            try
            {
                var query = new ConsultarSaldoContaCorrenteQuery { IdContaCorrente = idContaCorrente };
                var saldoContaCorrente = await _mediator.Send(query);
                return Ok(saldoContaCorrente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}