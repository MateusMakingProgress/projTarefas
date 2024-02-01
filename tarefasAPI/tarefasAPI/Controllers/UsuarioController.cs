using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tarefasAPI.Repositorios.Interfaces;

namespace tarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(Guid id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuario, Guid id)
        {
            usuario.Id = id;
            UsuarioModel user = await _usuarioRepositorio.BuscarPorId(id);
            await _usuarioRepositorio.Atualizar(usuario, id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
        [HttpDelete]
        public async Task<ActionResult<UsuarioModel>> Apagar(Guid id)
        {
            await _usuarioRepositorio.Apagar(id);
            return Ok();
        }
        
    }
}
