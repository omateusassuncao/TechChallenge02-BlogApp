using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace BlogRealProblems.Controller
{


    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly Guid _usuarioId;

        public IdentityController()
        {
        }

    }


}
