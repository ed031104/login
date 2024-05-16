namespace User
{
	using DB;
	using Microsoft.EntityFrameworkCore;
	public class DataBaseContex: DbContext
	{
		public DataBaseContex(DbContextOptions<DataBaseContex> options) 
			:base(options)
		{
			
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Login> Logins { get; set; }

	}
}
