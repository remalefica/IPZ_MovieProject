using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;

		private FilmRepository _filmRepository;
		private CommentRepository _commentRepository;
		private UserRepository _userRepository;
		private VoteRepository _voteRepository;

		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new NullReferenceException();
		}

		public FilmRepository FilmRepository
		{
			get
			{
				if(_filmRepository == null)
				{
					_filmRepository = new FilmRepository(_dbContext);
				}

				return _filmRepository;
			}
		}

		public CommentRepository CommentRepository
		{
			get
			{
				if (_commentRepository == null)
				{
					_commentRepository = new CommentRepository(_dbContext);
				}

				return _commentRepository;
			}
		}

		public UserRepository UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_dbContext);
				}

				return _userRepository;
			}
		}

		public VoteRepository VoteRepository
		{
			get
			{
				if (_voteRepository == null)
				{
					_voteRepository = new VoteRepository(_dbContext);
				}

				return _voteRepository;
			}
		}

		public async Task<int> SaveAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
