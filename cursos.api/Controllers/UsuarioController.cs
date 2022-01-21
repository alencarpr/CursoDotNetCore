using cursos.api.Filters;
using cursos.api.Models;
using cursos.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace cursos.api.Controllers
{
	[Route("api/v1/usuario")]
	[ApiController]

	public class UsuarioController : ControllerBase
	{
		/// <summary>
		/// Este serviço permite autenticar um usuário cadastrado e ativo.
		/// </summary>
		/// <param name="loginViewModelInput">View model do login</param>
		/// <returns>Retorna status ok, dados do usuário e o token em caso de sucesso</returns>
		[SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
		[SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
		[SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
		[HttpPost]
		[Route("logar")]
		[ValidacaoModelStateCustomizado]
		public IActionResult Logar(LoginViewModelInput loginViewModelInput)
		{

			return Ok(loginViewModelInput);
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