using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models;

[Table("boards")]
public class Board
{
    [Key]
    [Column("board_id")]
    public int BoardID { get; set; }
    
    [StringLength(256)]
    [Column("title")]
    public string Title { get; set; }
    
    [Column("content")]
    public string Content { get; set; }
    
    [Column("published_on")]
    public DateTime PublishedOn { get; set; }
    
    [Column("user_id")]
    public int UserID { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
}