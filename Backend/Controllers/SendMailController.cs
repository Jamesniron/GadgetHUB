using Backend.Service.MailService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("api/SendMail")]
  [ApiController]
  public class SendMailController(SendmailService _sendmail) : ControllerBase
  {
    [HttpPost("Send-Mail")]
    public async Task<IActionResult> Sendmail(SendMailRequest sendMailRequest)
    {
      var res = await _sendmail.Sendmail(sendMailRequest).ConfigureAwait(false);
      return Ok(res);
    }
  }
}
