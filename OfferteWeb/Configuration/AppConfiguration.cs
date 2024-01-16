namespace OfferteWeb;

public class AppConfiguration
{
    public string? BaseAddress { get; set; }
    public string? B64key { get; set; }
}
public class EmailConfiguration
{
    public string? SmtpServer { get; set; }
    public string? SmtpUser { get; set; }
    public string? SmtpPassword { get; set; }
    public string? SmtpFrom { get; set; }
}