using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBiopoints.Dto.Usuario;
using WebApiBiopoints.Models;
using WebApiBiopoints.Services.Usuario;

namespace WebApiBiopoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface) 
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);    
        }

        [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(usuarioCriacaoDto);
            return Ok(usuarios);
        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            var usuarios = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);
            return Ok(usuarios);
        }

        [HttpDelete("ExcluirUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ExcluirUsuario(int idUsuario)
        {
            var usuarios = await _usuarioInterface.ExcluirUsuario(idUsuario);
            return Ok(usuarios);
        }
    }
}
