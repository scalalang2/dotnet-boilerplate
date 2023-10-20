using System.ComponentModel.DataAnnotations;

namespace Contracts.Boards;

public record CreateBoardRequest(
    [Required]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 256 characters long.")]
    string Title,
    
    [Required]
    string Content
    );