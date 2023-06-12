namespace DatabaseLibrary.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Kind { get; set; } = null!;

    public List<Solution> Solutions { get; set; } = new();
}