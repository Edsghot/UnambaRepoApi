﻿namespace UnambaRepoApi.Model.Dtos.Teacher;

public record LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}