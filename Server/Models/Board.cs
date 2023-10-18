using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class Board
{
    [Key]
    public int BoardID { get; set; }
    
    [StringLength(256)]
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime PublishedOn { get; set; }
    
    public int UserID { get; set; }
    public User User { get; set; }
}