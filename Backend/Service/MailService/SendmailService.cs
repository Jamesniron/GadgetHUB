namespace Backend.Service.MailService
{
  public class SendmailService(EmailServiceProvider _emailServiceProvider)
  {
    public async Task<string> Sendmail(SendMailRequest sendMailRequest)
    {
      if (sendMailRequest == null) throw new ArgumentNullException(nameof(sendMailRequest));

      var template = await Template().ConfigureAwait(false);
      if (template == null) throw new Exception("Template not found");

      var bodyGenerated = await EmailBodyGenerate(template, sendMailRequest.Name);

      MailModel mailModel = new MailModel
      {
        Subject = "Emergyfy" ?? string.Empty,
        Body = bodyGenerated ?? string.Empty,
        SenderName = "Sample System",
        To = sendMailRequest.Email ?? throw new Exception("Recipient email address is required")
      };

      await _emailServiceProvider.SendMail(mailModel).ConfigureAwait(false);

      return "email was sent successfully";
    }
    public async Task<string> EmailBodyGenerate(string emailbody, string? name = null)
    {
      var replacements = new Dictionary<string, string?>
            {
                { "{Name}", name }
            };

      foreach (var replacement in replacements)
      {
        if (!string.IsNullOrEmpty(replacement.Value))
        {
          emailbody = emailbody.Replace(replacement.Key, replacement.Value, StringComparison.OrdinalIgnoreCase);
        }
      }

      return emailbody;
    }

    public async Task<string> Template()
    {
      return "<!DOCTYPE html>\n" +
      "<html>\n" +
      "<head>\n" +
      "  <meta charset=\"UTF-8\">\n" +
      "  <title>Weather Alert</title>\n" +
      "  <style>\n" +
      "    body {\n" +
      "      margin: 0;\n" +
      "      padding: 0;\n" +
      "      font-family: Arial, sans-serif;\n" +
      "      background-color: #ffffff;\n" +
      "    }\n" +
      "\n" +
      "    .container {\n" +
      "      max-width: 600px;\n" +
      "      margin: 0 auto;\n" +
      "      border: 1px solid #ddd;\n" +
      "      background-color: #fff;\n" +
      "    }\n" +
      "\n" +
      "    .header {\n" +
      "      background-color: #000;\n" +
      "      color: #fff;\n" +
      "      padding: 20px;\n" +
      "      text-align: center;\n" +
      "    }\n" +
      "\n" +
      "    .header h1 {\n" +
      "      margin: 0;\n" +
      "      font-size: 24px;\n" +
      "      color: #ff0000;\n" +
      "    }\n" +
      "\n" +
      "    .content {\n" +
      "      padding: 20px;\n" +
      "      color: #000;\n" +
      "    }\n" +
      "\n" +
      "    .content h2 {\n" +
      "      color: #ff0000;\n" +
      "    }\n" +
      "\n" +
      "    .footer {\n" +
      "      background-color: #000;\n" +
      "      color: #fff;\n" +
      "      text-align: center;\n" +
      "      padding: 15px;\n" +
      "      font-size: 14px;\n" +
      "    }\n" +
      "\n" +
      "    .button {\n" +
      "      display: inline-block;\n" +
      "      padding: 10px 20px;\n" +
      "      margin-top: 20px;\n" +
      "      background-color: #ff0000;\n" +
      "      color: #fff;\n" +
      "      text-decoration: none;\n" +
      "      border-radius: 4px;\n" +
      "    }\n" +
      "\n" +
      "    @media screen and (max-width: 600px) {\n" +
      "      .content, .header, .footer {\n" +
      "        padding: 15px;\n" +
      "      }\n" +
      "\n" +
      "      .header h1 {\n" +
      "        font-size: 20px;\n" +
      "      }\n" +
      "    }\n" +
      "  </style>\n" +
      "</head>\n" +
      "<body>\n" +
      "  <div class=\"container\">\n" +
      "    <div class=\"header\">\n" +
      "      <h1>🌦️ Weather Alert</h1>\n" +
      "    </div>\n" +
      "\n" +
      "    <div class=\"content\">\n" +
      "      <h2>Hello {Name},</h2>\n" +
      "      <p>Here is your <strong>weather forecast</strong> for today:</p>\n" +
      "\n" +
      "      <ul>\n" +
      "        <li><strong>Forecast:</strong> Rainy with thunderstorms</li>\n" +
      "        <li><strong>Temperature:</strong> 28°C / 82°F</li>\n" +
      "        <li><strong>Wind:</strong> 15 km/h SE</li>\n" +
      "        <li><strong>Chance of Rain:</strong> 80%</li>\n" +
      "      </ul>\n" +
      "\n" +
      "      <p>Please take necessary precautions:</p>\n" +
      "      <ul>\n" +
      "        <li>Carry an umbrella ☔</li>\n" +
      "        <li>Drive carefully 🚗</li>\n" +
      "        <li>Wear weather-appropriate clothes</li>\n" +
      "      </ul>\n" +
      "\n" +
      "      <a href=\"#\" class=\"button\">View Full Forecast</a>\n" +
      "    </div>\n" +
      "\n" +
      "    <div class=\"footer\">\n" +
      "      &copy; 2025 WeatherAlert Inc. | Stay safe and informed.\n" +
      "    </div>\n" +
      "  </div>\n" +
      "</body>\n" +
      "</html>\n";
    }
  }
}
