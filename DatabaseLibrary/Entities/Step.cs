namespace DatabaseLibrary.Entities;

public class Step
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int SolutionId { get; set; }

    public Solution? Solution { get; set; }
}
