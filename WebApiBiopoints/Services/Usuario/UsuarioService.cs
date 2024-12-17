using Microsoft.EntityFrameworkCore;
using WebApiBiopoints.Data;
using WebApiBiopoints.Dto.Usuario;
using WebApiBiopoints.Models;

namespace WebApiBiopoints.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {   

        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario)
        {
            ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == idUsuario);

                if (usuario == null) 
                {
                    resposta.Mensagem = "Nenhum usuário localizado.";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário localizado.";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = new UsuarioModel()
                {
                    Nome = usuarioCriacaoDto.Nome,
                    Email = usuarioCriacaoDto.Email,
                    Senha = usuarioCriacaoDto.Senha
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuário criado com sucesso.";

                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == usuarioEdicaoDto.Id);

                if (usuario == null)
                {
                    resposta.Mensagem = "Usuário não localizado.";
                    return resposta;
                }

                usuario.Nome = usuarioEdicaoDto.Nome;
                usuario.Email = usuarioEdicaoDto.Email;
                usuario.Senha = usuarioEdicaoDto.Senha;

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuário alterado com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ExcluirUsuario(int idUsuario)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _context.Usuarios.
                    FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Usuário não localizado.";
                    return resposta;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuário removido com sucesso.";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {   
            ResponseModel<List<UsuarioModel>> resposta =new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                resposta.Mensagem = "Todos os usuários foram coletados.";

                resposta.Dados = usuarios;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
