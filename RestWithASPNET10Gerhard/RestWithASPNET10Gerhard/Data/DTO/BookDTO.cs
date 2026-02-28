namespace RestWithASPNET10Gerhard.Data.DTO;

public class BookDTO
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime LaunchDate { get; set; }
}
