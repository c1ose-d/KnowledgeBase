﻿namespace DatabaseLibrary.Entities;

public class Solution
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int TagId { get; set; }
    public List<Tag> Tags { get; set; } = new();

    public Tag? Tag { get; set; }
}