using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace BD
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options)
			: base(options)
		{
		}
		
		public DbSet<User> User { get; set; }

	}
}
