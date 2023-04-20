using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace cr_quizer.Data
{
	public class QuizContext : DbContext
	{

		public QuizContext(DbContextOptions<QuizContext> options) : base(options)
		{

		}

		public DbSet<Quiz> Quizs { get; set; }

		
			
		
	}
}
