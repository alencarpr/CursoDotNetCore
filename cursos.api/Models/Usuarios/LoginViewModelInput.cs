using System.ComponentModel.DataAnnotations;

namespace cursos.api.Models.Usuarios
{
	public class LoginViewModelInput
	{
		[Required(ErrorMessage = "O Login � obrigat�rio")]
		public string Login { get; set; }

		[Required(ErrorMessage = "A senha � obrigat�ria")]
		public string Senha { get; set; }
	}
}