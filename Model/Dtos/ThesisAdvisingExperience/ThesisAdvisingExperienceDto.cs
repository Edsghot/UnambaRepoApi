﻿namespace UnambaRepoApi.Model.Dtos.ThesisAdvisingExperience;

public record ThesisAdvisingExperienceDto
{
    public int Id { get; set; }
    public string University { get; set; } = string.Empty;
    public string Thesis { get; set; } = string.Empty;
    public string ThesisStudent { get; set; } = string.Empty;
    public string Repository { get; set; } = string.Empty;
    public DateTime ThesisAcceptanceDate { get; set; }
    public int TeacherId { get; set; }
}