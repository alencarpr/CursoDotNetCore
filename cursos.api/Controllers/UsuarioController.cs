using cursos.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
		//[SwaggerResponse(statusCode: 400, description: "Campos obrigat�rios", Type = typeof(LoginViewModelInput))]
		//[SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(LoginViewModelInput))]


		[HttpPost]
		[Route("logar")]
		public IActionResult Logar(LoginViewModelInput loginViewModelInput)
		{

			return Ok(loginViewModelInput);
		}

		[HttpPost]
		[Route("registrar")]
		public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
		{

			return Created("", registroViewModelInput);
		}

	}
}