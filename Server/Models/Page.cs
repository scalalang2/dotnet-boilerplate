namespace Server.Models;

public sealed class Page<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalSize { get; set; }
}