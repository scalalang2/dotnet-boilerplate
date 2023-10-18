using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class User {
    [Key]
    public int UserID { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(256)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(256)]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}