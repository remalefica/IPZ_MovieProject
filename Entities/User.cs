using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public byte[] UserPic { get; set; }
		public IEnumerable<Comment> Comments { get; set; }
		public IEnumerable<Vote> Votes { get; set; }

	}
}
