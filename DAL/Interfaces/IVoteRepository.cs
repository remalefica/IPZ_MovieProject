using System;
using Entities;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	interface IVoteRepository
	{
        void AddVote(Vote vote);
       
    }
}
