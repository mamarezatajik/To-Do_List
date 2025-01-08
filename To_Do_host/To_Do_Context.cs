using Microsoft.EntityFrameworkCore;


using To_Do_Project;
public class To_Do_Context : DbContext
{
    public To_Do_Context()
    {
    }

    public To_Do_Context(DbContextOptions<To_Do_Context> options) : base(options)
    {
    }

    public DbSet<To_Do> To_Do_DataBase_List { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite(@"Data Source=To_Do_DataBase.db");
    }
}