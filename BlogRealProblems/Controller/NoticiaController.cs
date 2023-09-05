using BlogRealProblems.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace BlogRealProblems.Controller
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly ILogger<NoticiaController> _logger;

        private readonly Repository _repository;
        //private readonly Guid _usuarioId;

        public NoticiaController(ILogger<NoticiaController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{id}")]
        //[Route("NoticiaById")]
        [SwaggerOperation(Summary = "Noticia por Id", Description = "Retorna a respectiva notícia pelo Id")]
        public IActionResult NoticiaById(int id)
        {
            //var usuarioId = obterUsuarioId();

            //if (usuarioId == null) return Unauthorized();

            Noticia noticia = _repository.GetNoticiaById(id);

            return Ok(noticia);

        }

        [HttpPost]
        //[Route("/NovaNoticia")]
        [SwaggerOperation(Summary = "Salvar noticia", Description = "Solicita a criação da noticia no DB")]
        //public async Task<IActionResult> NewNoticia(string titulo, string descricao, string chapeu, /*DateTime dataPublicacao,*/ string autor)
        public async Task<IActionResult> NewNoticia([FromBody] Noticia noticia)
        {

            try
            {
                //var usuarioId = obterUsuarioId();

                //if (usuarioId == null) return Unauthorized();

                //var resultado = await _repository.AddNoticia(new Noticia(titulo, descricao, chapeu, autor));
                var resultado = await _repository.AddNoticia(noticia);

                return Ok(resultado);

            }
            catch (Exception)
            {
                return NoContent();
            }

        }
        
        [HttpGet]
        //[Route("/Notiicias")]
        [SwaggerOperation(Summary = "Todas as notícias", Description = "Retorna todas as notícias disponíveis")]
        public IActionResult GetNoticias()
        {
            try
            {
                //var usuarioId = obterUsuarioId();

                //if (usuarioId == null) return Unauthorized();

                IEnumerable<Noticia> noticias = _repository.GetNoticias();

                return Ok(noticias);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }


        [HttpDelete("{id}")]
        //[Route("/NovaNoticia")]
        [SwaggerOperation(Summary = "Deletar noticia", Description = "Solicita a deleção da noticia no DB")]
        //public async Task<IActionResult> NewNoticia(string titulo, string descricao, string chapeu, /*DateTime dataPublicacao,*/ string autor)
        public IActionResult DeleteNoticia(int id)
        {

            try
            {
                //var usuarioId = obterUsuarioId();

                //if (usuarioId == null) return Unauthorized();

                //var resultado = await _repository.AddNoticia(new Noticia(titulo, descricao, chapeu, autor));
                var resultado = _repository.DeleteNoticia(id);
                return Ok(resultado);

            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        //private Guid obterUsuarioId()
        //{
        //    var usuarioId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

        //    if (usuarioId == null) return Guid.Empty;

        //    return new Guid(usuarioId);
        //}


    }


}
