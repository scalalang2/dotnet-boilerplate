using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class UserEntity {
    [Key]
    public int UserID { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}