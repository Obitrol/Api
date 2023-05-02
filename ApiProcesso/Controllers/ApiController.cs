using ApiProcesso.Model;
using ApiProcesso.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiProcesso.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        public ApiController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
       [HttpGet]
       [Route("BuscarTodos")]
        public async Task<ActionResult<List<ContatoModel>>> BuscarTodos()
        {
            List<ContatoModel> contatos = await _contatoRepository.BuscarTodos();
            return contatos;
        }
        [HttpPost]
        [Route(("Remover/{id}"))]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool contato = await _contatoRepository.Remover(id);
            return Ok();
        }
        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult<ContatoModel>> Adicionar([FromBody] ContatoModel contato)
        {
            ContatoModel contatoModel = await _contatoRepository.Adicionar(contato);
            return Ok(contatoModel);
        }
        [HttpPatch]
        [Route("Atualizar")]
        public async Task<ActionResult<ContatoModel>> Atualizar([FromBody] ContatoModel contato)
        {
            ContatoModel contatoModel = await _contatoRepository.Atualizar(contato);
            return Ok(contatoModel);
        }
    }
}
