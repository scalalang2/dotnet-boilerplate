using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("users")]
public class User {
    [Key]
    [Column("user_id")]
    public int UserID { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(256)]
    [Column("username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(256)]
    [Column("password")]
    public string Password { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}