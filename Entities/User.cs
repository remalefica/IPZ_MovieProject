using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
	public class User
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public IEnumerable<Comment> Comments { get; set; }
		public IEnumerable<Vote> Votes { get; set; }

	}
}
