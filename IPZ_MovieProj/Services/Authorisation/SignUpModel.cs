using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPZ_MovieProj.Services.Authorisation
{
	public sealed class SignUpModel
	{
		[Required]
		public SignInModel SignInModel { get; set; }

		[Required(ErrorMessage = "No email input")]
		public string Email { get; set; }
	}
}
