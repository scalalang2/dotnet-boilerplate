using System.ComponentModel.DataAnnotations;

namespace Contracts;

public record LoginUserRequest(
    [Required]
    [StringLength(25, MinimumLength = 5)]
    string Username,
    [Required]
    [StringLength(25, MinimumLength = 5)]
    string Password
);