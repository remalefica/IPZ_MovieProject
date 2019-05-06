using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IVoteService
	{
		Task<Vote> AddVoteAsync(Vote vote);
	}
}
