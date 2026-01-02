namespace infra;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

public class MyFinanceDBContext : DbContext
{
    public DbSet<PlanoConta> PlanoCOnta {get; set;}
    public DbSet<Transacao> Transacao {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=myfinance;Username=postgres;Password=yourpassword");
    }
}
