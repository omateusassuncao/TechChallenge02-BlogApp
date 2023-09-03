﻿using BlogRealProblems.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace BlogRealProblems.Controller
{


    [ApiController]
    [Route("[controller]")]
    public class NoticiaController : ControllerBase
    {

        private readonly Repository _repository;
        //private readonly Guid _usuarioId;

        public NoticiaController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Noticia por Id", Description = "Retorna a respectiva notícia pelo Id")]
        public IActionResult NoticiaById(int id)
        {
            var usuarioId = obterUsuarioId();

            if (usuarioId == null) return Unauthorized();

            Noticia noticia = _repository.GetNoticiaById(id);

            return Ok(noticia);

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Salvar noticia", Description = "Solicita a criação da noticia no DB")]
        public async Task<IActionResult> NewNoticia(string titulo, string descricao, string chapeu, /*DateTime dataPublicacao,*/ string autor)
        {

            try
            {
                var usuarioId = obterUsuarioId();

                if (usuarioId == null) return Unauthorized();

                var resultado = await _repository.AddNoticia(new Noticia(titulo, descricao, chapeu, autor));
                return Ok(resultado);

            }
            catch (Exception e)
            {
                return null;
            }

        }

        [HttpGet]
        [SwaggerOperation(Summary = "Todas as notícias", Description = "Retorna todas as notícias disponíveis")]
        public IActionResult GetNoticias()
        {
            try
            {
                var usuarioId = obterUsuarioId();

                if (usuarioId == null) return Unauthorized();

                IEnumerable<Noticia> noticias = _repository.GetNoticias();

                return Ok(noticias);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private Guid obterUsuarioId()
        {
            var usuarioId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            if (usuarioId == null) return Guid.Empty;

            return new Guid(usuarioId);
        }


    }


}