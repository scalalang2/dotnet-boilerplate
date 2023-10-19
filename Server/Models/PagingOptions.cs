using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Server.Models;

public sealed class PagingOptions
{
    [FromQuery]
    [Range(0, int.MaxValue, ErrorMessage = "Offset must be positive integer.")]
    public int Offset { get; set; }
    
    [FromQuery]
    [Range(1, int.MaxValue, ErrorMessage = "Limit must be greater than 0.")]
    public int Limit { get; set; }
}