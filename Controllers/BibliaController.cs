using Biblia.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliaController(IBibliaService service) : ControllerBase
    {
        private readonly IBibliaService _service = service;

        // Buscar por livro e (opcionalmente) capítulo
        // Exemplo: /api/biblia/livro?nome=João&capitulo=3
        [HttpGet("livro")]
        public async Task<IActionResult> GetPorLivro([FromQuery] string nome, [FromQuery] int? capitulo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("Informe o nome do livro.");

            var resultado = await _service.BuscarPorLivroCapituloAsync(nome, capitulo);

            if (resultado == null)
                return NotFound("Livro ou capítulo não encontrado.");

            return Ok(resultado);
        }

        // Buscar por tema (palavra-chave)
        // Exemplo: /api/biblia/tema?palavra=amor
        [HttpGet("tema")]
        public async Task<IActionResult> BuscarPorTema([FromQuery] string termo, [FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 20)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return BadRequest("O termo de busca é obrigatório.");

            var (versiculos, total) = await _service.BuscarPorTemaAsync(termo, pagina, tamanhoPagina);

            var resultado = new
            {
                Pagina = pagina,
                TamanhoPagina = tamanhoPagina,
                Total = total,
                Versiculos = versiculos
            };

            return Ok(resultado);
        }


        [HttpGet("versiculo-do-dia")]
        public async Task<IActionResult> GetVersiculoDoDia()
        {
            var versiculo = await _service.GetVersiculoDoDiaAsync();
            if (versiculo == null)
                return NotFound("Nenhum versículo encontrado.");

            return Ok(versiculo);
        }
    }
}
