namespace Backend.Service.MailService
{
  public class SendMailRequest
  {
    public string? Name { get; set; }
    public string? Email { get; set; }
    public required EmailTypes emailTypes { get; set; }
  }
}
