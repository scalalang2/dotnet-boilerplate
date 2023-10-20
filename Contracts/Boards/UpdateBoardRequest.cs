using System.ComponentModel.DataAnnotations;

namespace Contracts.Boards;

public record UpdateBoardRequest(
    [Required]
    string Title,
    
    [Required]
    string Content
    );