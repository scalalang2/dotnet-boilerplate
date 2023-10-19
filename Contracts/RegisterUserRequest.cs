using System.ComponentModel.DataAnnotations;

namespace Contracts;

public record RegisterUserRequest(
    [Required]
    [StringLength(25, MinimumLength = 5)]
    string Username,
    [Required]
    [StringLength(25, MinimumLength = 5)]
    string Password
);