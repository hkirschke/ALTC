﻿using ALTC.Infra.Json.API.Dtos;

namespace ALTC.Application.Models;

public class UserModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public Company? Company { get; set; }
}