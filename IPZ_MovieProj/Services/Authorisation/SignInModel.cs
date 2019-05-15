using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPZ_MovieProj.Services.Authorisation
{
	public sealed class SignInModel
	{
		[Required(ErrorMessage = "No email input")]
		public string Login { get; set; }

		[Required(ErrorMessage = "No password input")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
