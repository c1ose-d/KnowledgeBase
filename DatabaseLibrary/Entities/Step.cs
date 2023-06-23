namespace DatabaseLibrary.Entities;

public class Step
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Solution? Solutions { get; set; }
}
