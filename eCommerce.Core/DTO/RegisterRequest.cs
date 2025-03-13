using System;

namespace eCommerce.Core.DTO

public record RegisterRequest(string? Email, string? Password, string? personName, GenderOptions gender, string? ConfirmPassword);