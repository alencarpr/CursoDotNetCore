using cursos.api.Filters;
using cursos.api.Models;
using cursos.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace cursos.api.Controllers
{
	[Route("api/v1/usuario")]
	[ApiController]

	public class UsuarioController : ControllerBase
	{
		/// <summary>
		/// Este servi�o permite autenticar um usu�rio cadastrado e ativo.
		/// </summary>
		/// <param name="loginViewModelInput">View model do login</param>
		/// <returns>Retorna status ok, dados do usu�rio e o token em caso de sucesso</returns>
		[SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
		[SwaggerResponse(statusCode: 400, description: "Campos obrigat�rios", Type = typeof(ValidaCampoViewModelOutput))]
		[SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
		[HttpPost]
		[Route("logar")]
		[ValidacaoModelStateCustomizado]
		public IActionResult Logar(LoginViewModelInput loginViewModelInput)
		{

			var usuarioViewModelOutput = new UsuarioViewModelOutput()
			{
				Codigo = 1,
				Login = "pauloalencar",
				Email = "pauloalencar@fai.com.br"
			};

			var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
			var symmetricSecurityKey = new SymmetricSecurityKey(secret);
			var securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
					new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
					new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
			};
			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
			var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);



			return Ok(new
			{
				Token = token,
				Usuario = usuarioViewModelOutput
			});
		}

		[HttpPost]
		[Route("registrar")]
		[ValidacaoModelStateCustomizado]
		public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
		{
			return Created("", registroViewModelInput);
		}

	}
}