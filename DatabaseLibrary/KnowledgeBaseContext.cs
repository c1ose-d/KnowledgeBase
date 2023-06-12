namespace DatabaseLibrary;

public class KnowledgeBaseContext : DbContext
{
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Solution> Solutions => Set<Solution>();

    public KnowledgeBaseContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=KnowledgeBase.db");
    }
}