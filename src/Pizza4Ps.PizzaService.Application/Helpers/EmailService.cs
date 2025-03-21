﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using QRCoder;

namespace Pizza4Ps.PizzaService.Application.Helpers
{
    public class EmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendWorkshopEmail(string customerEmail, string customerName, string workshopName, string registrationCode)
        {
            var emailSettings = _config.GetSection("EmailSettings");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailSettings["SenderName"], emailSettings["SenderEmail"]));
            message.To.Add(new MailboxAddress(customerName, customerEmail));
            message.Subject = $"Xác nhận đăng ký Workshop {workshopName}";

            // Đọc template email với đường dẫn chính xác
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var templatePath = Path.Combine(basePath, "Templates", "WorkshopRegisterEmailTemplate.html");

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template not found: {templatePath}");
            }

            string emailTemplate = File.ReadAllText(templatePath);

            // Thay thế nội dung động
            emailTemplate = emailTemplate.Replace("{{CustomerName}}", customerName)
                                         .Replace("{{WorkshopName}}", workshopName)
                                         .Replace("{{RegistrationCode}}", registrationCode);

            // Tạo QR Code
            var qrCodeImage = GenerateQrCode(registrationCode);

            // Tạo nội dung email
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = emailTemplate
            };

            // Đính kèm QR Code
            var imageAttachment = bodyBuilder.LinkedResources.Add("qrCode.png", qrCodeImage);
            imageAttachment.ContentId = "qrCodeImage";

            message.Body = bodyBuilder.ToMessageBody();

            // Gửi email
            using var client = new SmtpClient();
            await client.ConnectAsync(emailSettings["SmtpServer"], int.Parse(emailSettings["SmtpPort"]), false);
            await client.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        private byte[] GenerateQrCode(string text)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}
