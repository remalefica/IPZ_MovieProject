using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPZ_MovieProj.Config
{
	public static class DependencyRegistar
	{
		public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("AppDb"));
			});

			services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<IFilmRepository, FilmRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IVoteRepository, VoteRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<IFilmService, FilmService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IVoteService, VoteService>();
		}
	}
}
