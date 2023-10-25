using System.Net.Mail;
using System.Net;
using Globe_Wander_Final.Models.DTOs;
using Azure.Core;
using EllipticCurve.Utils;
using Globe_Wander_Final.Models.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Stripe;
using System.Drawing;
using System.Numerics;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Globe_Wander_Final.Models.Services
{
    public class EmailService 
    {
        private readonly IConfiguration _configuration;


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        // TODO: Emails for boking trips thansk etc... -osama 
        public async Task sendEmail(string name,EmailDTO email)
        { 
          
            string email_APIkEY = "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";
            var toAddress = new MailAddress(_configuration["Brevo:AdminAddress"], _configuration["Brevo:DefaultFromName"]);
            var fromAddress = new MailAddress(email.Email, name);
            string fromPassword = _configuration["Brevo:fromPassword"];
            var AuthAddress = new MailAddress(_configuration["Brevo:AuthAddress"]);
            string Subject = "Contact Us sent";
            string Body = $"  {email.Message}";


            var smtp = new SmtpClient
            {
                Host = "smtp-relay.brevo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(AuthAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {

                Subject = Subject,
                Body = Body,
                IsBodyHtml = true

            })

            {
                message.Headers.Add("ApiKey", email_APIkEY);
                await smtp.SendMailAsync(message);

            }


            ;




        }

        public async Task InvoiceForBookingRoom(string reciver,string reciverName, BookingRoomDTO bookingRoomDTO)
        {

            var days = bookingRoomDTO.TotalPrice / bookingRoomDTO.Cost;
            string email_APIkEY = "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";
            var fromAddress = new MailAddress(_configuration["Brevo:AdminAddress"], _configuration["Brevo:DefaultFromName"]);
            var toAddress = new MailAddress(reciver, reciverName);
            string fromPassword = _configuration["Brevo:fromPassword"];
            var AuthAddress = new MailAddress(_configuration["Brevo:AuthAddress"]);
            string Subject = "Invoice";
            string Body = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Invoice of </title>\r\n    <style>\r\n        body {{\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f0f0f0;\r\n        }}\r\n\r\n        .invoice-container {{\r\n            background-color: #fff;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            padding: 20px;\r\n            border: 1px solid #ccc;\r\n            border-radius: 5px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n\r\n        .invoice-header {{\r\n            background-color: #000000;\r\n            color: #fff;\r\n            padding: 10px;\r\n            text-align: center;\r\n        }}\r\n\r\n        .invoice-details {{\r\n            margin-top: 20px;\r\n            margin-bottom: 30px;\r\n        }}\r\n\r\n            .invoice-details h1 {{\r\n                font-size: 24px;\r\n            }}\r\n\r\n        .invoice-table {{\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }}\r\n\r\n            .invoice-table th, .invoice-table td {{\r\n                border: 1px solid #ccc;\r\n                padding: 10px;\r\n                text-align: left;\r\n            }}\r\n\r\n            .invoice-table th {{\r\n                background-color: #f0f0f0;\r\n            }}\r\n\r\n        .invoice-total {{\r\n            margin-top: 20px;\r\n            text-align: right;\r\n        }}\r\n\r\n            .invoice-total h3 {{\r\n                font-size: 20px;\r\n                color: #007bff;\r\n            }}\r\n\r\n        .footer {{\r\n            margin-top: 20px;\r\n            text-align: center;\r\n            color: #777;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"invoice-container\">\r\n        <div class=\"invoice-header\">\r\n            <h1>Globe Wander</h1>\r\n        </div>\r\n        <div class=\"invoice-details\">\r\n            <h1>Invoice Details</h1>\r\n    \r\n        </div>\r\n        <table class=\"invoice-table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>Info</th>\r\n                   \r\n        <th>Date</th>           \r\n                                    </tr>\r\n            </thead>\r\n            <tbody>\r\n              ";


            Body += $"<tr> <td>User name :</td>  <td>{bookingRoomDTO.Username}</td> </tr>" +
            $"<tr> <td>CheckIn:</td>  <td>{bookingRoomDTO.CheckIn}</td> </tr>" +
            $"<tr> <td>CheckOut:</td>  <td>{bookingRoomDTO.CheckOut}</td> </tr>" +
        $"<tr> <td>Cost Per-Day:</td>  <td>{bookingRoomDTO.Cost} $</td> </tr>"+
          $"<tr> <td>Day:</td>  <td>{days} </td> </tr>";
    
            Body += $"   </tbody>\r\n        </table>\r\n        <div class=\"invoice-total\">\r\n            <h3>Total Amount:{bookingRoomDTO.TotalPrice} $</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"footer\">\r\n        <p>Thank you for your business!</p>\r\n    </div>\r\n</body>\r\n</html>";



            var smtp = new SmtpClient
            {
                Host = "smtp-relay.brevo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(AuthAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {

                Subject = Subject,
                Body = Body,
                IsBodyHtml = true

            })

            {
                message.Headers.Add("ApiKey", email_APIkEY);
                await smtp.SendMailAsync(message);

            }


    ;




        }

        public async Task InvoiceForBookingTrip(string reciver, string reciverName, BookingTripDTO bookingTripDTO)
        {
            var person = bookingTripDTO.TotalPrice / bookingTripDTO.CostPerPerson;
            string email_APIkEY = "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";
            var fromAddress = new MailAddress(_configuration["Brevo:AdminAddress"], _configuration["Brevo:DefaultFromName"]);
            var toAddress = new MailAddress(reciver, reciverName);
            string fromPassword = _configuration["Brevo:fromPassword"];
            var AuthAddress = new MailAddress(_configuration["Brevo:AuthAddress"]);
            string Subject = "Invoice";
            string Body = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Invoice of </title>\r\n    <style>\r\n        body {{\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f0f0f0;\r\n        }}\r\n\r\n        .invoice-container {{\r\n            background-color: #fff;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            padding: 20px;\r\n            border: 1px solid #ccc;\r\n            border-radius: 5px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n\r\n        .invoice-header {{\r\n            background-color: #000000;\r\n            color: #fff;\r\n            padding: 10px;\r\n            text-align: center;\r\n        }}\r\n\r\n        .invoice-details {{\r\n            margin-top: 20px;\r\n            margin-bottom: 30px;\r\n        }}\r\n\r\n            .invoice-details h1 {{\r\n                font-size: 24px;\r\n            }}\r\n\r\n        .invoice-table {{\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }}\r\n\r\n            .invoice-table th, .invoice-table td {{\r\n                border: 1px solid #ccc;\r\n                padding: 10px;\r\n                text-align: left;\r\n            }}\r\n\r\n            .invoice-table th {{\r\n                background-color: #f0f0f0;\r\n            }}\r\n\r\n        .invoice-total {{\r\n            margin-top: 20px;\r\n            text-align: right;\r\n        }}\r\n\r\n            .invoice-total h3 {{\r\n                font-size: 20px;\r\n                color: #007bff;\r\n            }}\r\n\r\n        .footer {{\r\n            margin-top: 20px;\r\n            text-align: center;\r\n            color: #777;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"invoice-container\">\r\n        <div class=\"invoice-header\">\r\n            <h1>Globe Wander</h1>\r\n        </div>\r\n        <div class=\"invoice-details\">\r\n            <h1>Invoice Details</h1>\r\n    \r\n        </div>\r\n        <table class=\"invoice-table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>Info</th>\r\n                   \r\n        <th>Date</th>           \r\n                                    </tr>\r\n            </thead>\r\n            <tbody>\r\n              ";


            Body += $"<tr> <td>User name :</td>  <td>{bookingTripDTO.Username}</td> </tr>" +
            $"<tr> <td>Start-Day:</td>  <td>{bookingTripDTO.StartDate}</td> </tr>" +
            $"<tr> <td>End-Date:</td>  <td>{bookingTripDTO.EndDate}</td> </tr>" +
        $"<tr> <td>Cost Per-person:</td>  <td>{bookingTripDTO.CostPerPerson} $</td> </tr>"+
          $"<tr> <td>#No. persons:</td>  <td>{person} </td> </tr>";
       
            Body += $"   </tbody>\r\n        </table>\r\n        <div class=\"invoice-total\">\r\n            <h3>Total Amount:{bookingTripDTO.TotalPrice} $</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"footer\">\r\n        <p>Thank you for your business!</p>\r\n    </div>\r\n</body>\r\n</html>";



            var smtp = new SmtpClient
            {
                Host = "smtp-relay.brevo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(AuthAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {

                Subject = Subject,
                Body = Body,
                IsBodyHtml = true

            })

            {
                message.Headers.Add("ApiKey", email_APIkEY);
                await smtp.SendMailAsync(message);

            }


 ;




        }


        public async Task sendEmailTankYou(string reciever, string reciverName)
        {
            string email_APIkEY = "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";
            var fromAddress = new MailAddress(_configuration["Brevo:AdminAddress"], _configuration["Brevo:DefaultFromName"]);
            var toAddress = new MailAddress(reciever, reciverName);
            string fromPassword = _configuration["Brevo:fromPassword"];
            var AuthAddress = new MailAddress(_configuration["Brevo:AuthAddress"]);
            const string Subject = "Thanks For Working With Us";
            string Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"format-detection\" content=\"telephone=no\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Receipts</title>\r\n    <style type=\"text/css\" emogrify=\"no\">\r\n        #outlook a {\r\n            padding: 0;\r\n        }\r\n\r\n        .ExternalClass {\r\n            width: 100%;\r\n        }\r\n\r\n            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {\r\n                line-height: 100%;\r\n            }\r\n\r\n        table td {\r\n            border-collapse: collapse;\r\n            mso-line-height-rule: exactly;\r\n        }\r\n\r\n        .editable.image {\r\n            font-size: 0 !important;\r\n            line-height: 0 !important;\r\n        }\r\n\r\n        .nl2go_preheader {\r\n            display: none !important;\r\n            mso-hide: all !important;\r\n            mso-line-height-rule: exactly;\r\n            visibility: hidden !important;\r\n            line-height: 0px !important;\r\n            font-size: 0px !important;\r\n        }\r\n\r\n        body {\r\n            width: 100% !important;\r\n            -webkit-text-size-adjust: 100%;\r\n            -ms-text-size-adjust: 100%;\r\n            margin: 0;\r\n            padding: 0;\r\n        }\r\n\r\n        img {\r\n            outline: none;\r\n            text-decoration: none;\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n\r\n        a img {\r\n            border: none;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse;\r\n            mso-table-lspace: 0pt;\r\n            mso-table-rspace: 0pt;\r\n        }\r\n\r\n        th {\r\n            font-weight: normal;\r\n            text-align: left;\r\n        }\r\n\r\n        *[class=\"gmail-fix\"] {\r\n            display: none !important;\r\n        }\r\n    </style>\r\n    <style type=\"text/css\" emogrify=\"no\">\r\n        @media (max-width: 600px) {\r\n            .gmx-killpill {\r\n                content: ' \\03D1';\r\n            }\r\n        }\r\n    </style>\r\n    <style type=\"text/css\" emogrify=\"no\">\r\n        @media (max-width: 600px) {\r\n            .gmx-killpill {\r\n                content: ' \\03D1';\r\n            }\r\n\r\n            .r0-o {\r\n                border-style: solid !important;\r\n                margin: 0 auto 0 auto !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r1-i {\r\n                background-color: transparent !important\r\n            }\r\n\r\n            .r2-c {\r\n                box-sizing: border-box !important;\r\n                text-align: center !important;\r\n                valign: top !important;\r\n                width: 320px !important\r\n            }\r\n\r\n            .r3-o {\r\n                border-style: solid !important;\r\n                margin: 0 auto 0 auto !important;\r\n                width: 320px !important\r\n            }\r\n\r\n            .r4-i {\r\n                padding-bottom: 5px !important;\r\n                padding-top: 5px !important\r\n            }\r\n\r\n            .r5-c {\r\n                box-sizing: border-box !important;\r\n                display: block !important;\r\n                valign: top !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r6-o {\r\n                border-style: solid !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r7-i {\r\n                padding-left: 0px !important;\r\n                padding-right: 0px !important\r\n            }\r\n\r\n            .r8-c {\r\n                box-sizing: border-box !important;\r\n                text-align: center !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r9-i {\r\n                padding-bottom: 13px !important;\r\n                padding-left: 10px !important;\r\n                padding-right: 10px !important;\r\n                padding-top: 15px !important;\r\n                text-align: center !important\r\n            }\r\n\r\n            .r10-i {\r\n                background-color: #ffffff !important\r\n            }\r\n\r\n            .r11-c {\r\n                box-sizing: border-box !important;\r\n                text-align: center !important;\r\n                valign: top !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r12-i {\r\n                padding-bottom: 20px !important;\r\n                padding-left: 15px !important;\r\n                padding-right: 15px !important;\r\n                padding-top: 20px !important\r\n            }\r\n\r\n            .r13-c {\r\n                box-sizing: border-box !important;\r\n                text-align: left !important;\r\n                valign: top !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r14-o {\r\n                border-style: solid !important;\r\n                margin: 0 auto 0 0 !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r15-i {\r\n                padding-top: 15px !important;\r\n                text-align: left !important\r\n            }\r\n\r\n            .r16-i {\r\n                background-color: #98DCFF !important\r\n            }\r\n\r\n            .r17-i {\r\n                padding-bottom: 3px !important;\r\n                padding-left: 10px !important;\r\n                padding-right: 10px !important;\r\n                padding-top: 21px !important\r\n            }\r\n\r\n            .r18-i {\r\n                padding-top: 46px !important\r\n            }\r\n\r\n            .r19-i {\r\n                padding-top: 30px !important;\r\n                text-align: left !important\r\n            }\r\n\r\n            .r20-i {\r\n                padding-left: 10px !important;\r\n                padding-right: 10px !important;\r\n                padding-top: 10px !important\r\n            }\r\n\r\n            .r21-i {\r\n                text-align: left !important\r\n            }\r\n\r\n            .r22-i {\r\n                padding-bottom: 30px !important;\r\n                padding-left: 10px !important;\r\n                padding-right: 10px !important;\r\n                padding-top: 30px !important\r\n            }\r\n\r\n            .r23-o {\r\n                border-style: solid !important;\r\n                margin: 0 auto 0 auto !important;\r\n                margin-top: 0px !important;\r\n                width: 100% !important\r\n            }\r\n\r\n            .r24-i {\r\n                font-size: 0px !important;\r\n                padding-left: 72px !important;\r\n                padding-right: 72px !important\r\n            }\r\n\r\n            .r25-c {\r\n                box-sizing: border-box !important;\r\n                width: 32px !important\r\n            }\r\n\r\n            .r26-o {\r\n                border-style: solid !important;\r\n                margin-right: 20px !important;\r\n                width: 32px !important\r\n            }\r\n\r\n            body {\r\n                -webkit-text-size-adjust: none\r\n            }\r\n\r\n            .nl2go-responsive-hide {\r\n                display: none\r\n            }\r\n\r\n            .nl2go-body-table {\r\n                min-width: unset !important\r\n            }\r\n\r\n            .mobshow {\r\n                height: auto !important;\r\n                overflow: visible !important;\r\n                max-height: unset !important;\r\n                visibility: visible !important;\r\n                border: none !important\r\n            }\r\n\r\n            .resp-table {\r\n                display: inline-table !important\r\n            }\r\n\r\n            .magic-resp {\r\n                display: table-cell !important\r\n            }\r\n        }\r\n    </style><!--[if !mso]><!-->\r\n    <style type=\"text/css\" emogrify=\"no\">\r\n        @import url(\"https://fonts.googleapis.com/css2?family=Fira+Sans:wght@500;700&display=swap\");\r\n        @import url(\"https://fonts.googleapis.com/css2?family=Open+Sans&display=swap\");\r\n        @import url(\"https://fonts.googleapis.com/css2?family=Montserrat\");\r\n    </style><!--<![endif]-->\r\n    <style type=\"text/css\">\r\n        p, h1, h2, h3, h4, ol, ul {\r\n            margin: 0;\r\n        }\r\n\r\n        a, a:link {\r\n            color: #34332d;\r\n            text-decoration: none\r\n        }\r\n\r\n        .nl2go-default-textstyle {\r\n            color: #34332d;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 24px;\r\n            line-height: 1.3;\r\n            word-break: break-word\r\n        }\r\n\r\n        .default-button {\r\n            color: #34332d;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 26px;\r\n            font-style: normal;\r\n            font-weight: normal;\r\n            line-height: 1.15;\r\n            text-decoration: none;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_18_white_opensans_reg {\r\n            color: #ffffff;\r\n            font-family: Open Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 18px;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_24_black_reg {\r\n            color: #34332D;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 24px;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_24_black_b {\r\n            color: #34332D;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 24px;\r\n            font-weight: 700;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_26_yellow_m {\r\n            color: #FED385;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 26px;\r\n            font-weight: 500;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_26_red_m {\r\n            color: #FD8369;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 26px;\r\n            font-weight: 500;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_26_blue_m {\r\n            color: #74D5DE;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 26px;\r\n            font-weight: 500;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_30_white_firasans_m {\r\n            color: #ffffff;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 30px;\r\n            font-weight: 500;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_40_white_firasans_m {\r\n            color: #ffffff;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 40px;\r\n            font-weight: 500;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_50_white_firasans_b {\r\n            color: #ffffff;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 50px;\r\n            font-weight: 700;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_50_blue_firasans_b {\r\n            color: #98DCFF;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 50px;\r\n            font-weight: 700;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_headline {\r\n            color: #677876;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 26px;\r\n            word-break: break-word\r\n        }\r\n\r\n        .nl2go_class_impressum {\r\n            color: #999999;\r\n            font-family: Montserrat, Arial, Helvetica, sans-serif;\r\n            font-size: 12px;\r\n            font-style: italic;\r\n            word-break: break-word\r\n        }\r\n\r\n        .default-heading1 {\r\n            color: #ffffff;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 50px;\r\n            word-break: break-word\r\n        }\r\n\r\n        .default-heading2 {\r\n            color: #98dcff;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 50px;\r\n            word-break: break-word\r\n        }\r\n\r\n        .default-heading3 {\r\n            color: #1F2D3D;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 24px;\r\n            word-break: break-word\r\n        }\r\n\r\n        .default-heading4 {\r\n            color: #1F2D3D;\r\n            font-family: Fira Sans, Arial, Helvetica, sans-serif;\r\n            font-size: 18px;\r\n            word-break: break-word\r\n        }\r\n\r\n        a[x-apple-data-detectors] {\r\n            color: inherit !important;\r\n            text-decoration: inherit !important;\r\n            font-size: inherit !important;\r\n            font-family: inherit !important;\r\n            font-weight: inherit !important;\r\n            line-height: inherit !important;\r\n        }\r\n\r\n        .no-show-for-you {\r\n            border: none;\r\n            display: none;\r\n            float: none;\r\n            font-size: 0;\r\n            height: 0;\r\n            line-height: 0;\r\n            max-height: 0;\r\n            mso-hide: all;\r\n            overflow: hidden;\r\n            table-layout: fixed;\r\n            visibility: hidden;\r\n            width: 0;\r\n        }\r\n    </style><!--[if mso]><xml> <o:OfficeDocumentSettings> <o:AllowPNG/> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]-->\r\n    <style type=\"text/css\">\r\n        a:link {\r\n            color: #34332d;\r\n            text-decoration: none;\r\n        }\r\n    </style>\r\n</head>\r\n<body bgcolor=\"#ffffff\" text=\"#34332d\" link=\"#34332d\" yahoo=\"fix\" style=\"background-color: #ffffff;\">\r\n    <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" class=\"nl2go-body-table\" width=\"100%\" style=\"background-color: #ffffff; width: 100%;\"><tr><td> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" align=\"center\" class=\"r0-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r1-i\" style=\"background-color: transparent;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"600\" align=\"center\" class=\"r3-o\" style=\"table-layout: fixed;\"><tr><td class=\"r4-i\" style=\"padding-bottom: 5px; padding-top: 5px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><th width=\"100%\" valign=\"top\" class=\"r5-c\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r6-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r7-i\" style=\"padding-left: 10px; padding-right: 10px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><td class=\"r8-c\" align=\"center\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r0-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td align=\"center\" class=\"r9-i nl2go-default-textstyle\" style=\"color: #34332d; font-family: Montserrat,Arial,Helvetica,sans-serif; font-size: 24px; line-height: 1.3; word-break: break-word; padding-bottom: 13px; padding-left: 30px; padding-right: 30px; padding-top: 15px; text-align: center;\"> <div><p style=\"margin: 0;\"><span style=\"font-size: 12px;\">View in browser</span></p></div> </td> </tr></table></td> </tr></table></td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"600\" align=\"center\" class=\"r3-o\" style=\"table-layout: fixed; width: 600px;\"><tr><td valign=\"top\" class=\"r10-i\" style=\"background-color: #ffffff;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" align=\"center\" class=\"r0-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td class=\"r12-i\" style=\"padding-bottom: 20px; padding-top: 20px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><th width=\"100%\" valign=\"top\" class=\"r5-c\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r6-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r7-i\" style=\"padding-left: 15px; padding-right: 15px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><td class=\"r13-c\" align=\"left\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r14-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td align=\"left\" valign=\"top\" class=\"r15-i nl2go-default-textstyle\" style=\"color: #34332d; font-family: Montserrat,Arial,Helvetica,sans-serif; font-size: 24px; line-height: 1.3; word-break: break-word; padding-top: 15px; text-align: left;\"> <div><h2 class=\"default-heading2\" style=\"margin: 0; color: #98dcff; font-family: Fira Sans,Arial,Helvetica,sans-serif; font-size: 50px; word-break: break-word;\"><span style=\"color: #000000;\">Globe Wander</span></h2></div> </td> </tr></table></td> </tr></table></td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" align=\"center\" class=\"r0-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r16-i\" style=\"background-color: #98DCFF;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"600\" align=\"center\" class=\"r3-o\" style=\"table-layout: fixed; width: 600px;\"><tr><td class=\"r17-i\" style=\"padding-bottom: 3px; padding-left: 20px; padding-right: 20px; padding-top: 21px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><th width=\"100%\" valign=\"top\" class=\"r5-c\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r6-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r7-i\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><td class=\"r11-c\" align=\"center\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"560\" class=\"r0-o\" style=\"table-layout: fixed; width: 560px;\"><tr><td class=\"r18-i\" style=\"font-size: 0px; line-height: 0px; padding-top: 46px;\"> <img src=\"http://img-dev.mailinblue.com/1003776/images/rnb/original/5e8c1b873505dc014d23ec54.png\" width=\"560\" border=\"0\" style=\"display: block; width: 100%;\"></td> </tr></table></td> </tr><tr><td class=\"r13-c\" align=\"left\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r14-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td align=\"left\" valign=\"top\" class=\"r19-i nl2go-default-textstyle\" style=\"color: #34332d; font-family: Montserrat,Arial,Helvetica,sans-serif; font-size: 24px; word-break: break-word; line-height: 1.1; padding-top: 30px; text-align: left;\"> <div><h1 class=\"default-heading1\" style=\"margin: 0; color: #fff; font-family: Fira Sans,Arial,Helvetica,sans-serif; font-size: 50px; word-break: break-word;\">thank you </h1></div> </td> </tr></table></td> </tr></table></td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"600\" align=\"center\" class=\"r3-o\" style=\"table-layout: fixed; width: 600px;\"><tr><td valign=\"top\" class=\"r10-i\" style=\"background-color: #ffffff;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" align=\"center\" class=\"r0-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td class=\"r20-i\" style=\"padding-left: 20px; padding-right: 20px; padding-top: 10px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><th width=\"100%\" valign=\"top\" class=\"r5-c\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r6-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r7-i\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><td class=\"r13-c\" align=\"left\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r14-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td align=\"left\" valign=\"top\" class=\"r21-i nl2go-default-textstyle\" style=\"color: #34332d; font-family: Montserrat,Arial,Helvetica,sans-serif; font-size: 24px; word-break: break-word; line-height: 1.1; text-align: left;\"> <div><h2 class=\"default-heading2\" style=\"margin: 0; color: #98dcff; font-family: Fira Sans,Arial,Helvetica,sans-serif; font-size: 50px; word-break: break-word;\">For the working with us</h2></div> </td> </tr></table></td> </tr></table></td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" align=\"center\" class=\"r0-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r16-i\" style=\"background-color: #98DCFF;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"600\" align=\"center\" class=\"r3-o\" style=\"table-layout: fixed; width: 600px;\"><tr><td class=\"r22-i\" style=\"padding-bottom: 30px; padding-left: 20px; padding-right: 20px; padding-top: 30px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><th width=\"100%\" valign=\"top\" class=\"r5-c\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r6-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td valign=\"top\" class=\"r7-i\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><td class=\"r8-c\" align=\"center\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"560\" align=\"center\" class=\"r0-o\" style=\"table-layout: fixed; width: 560px;\"><tr><td valign=\"top\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><td class=\"r8-c\" style=\"display: inline-block;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"560\" class=\"r23-o\" style=\"table-layout: fixed; width: 560px;\"><tr><td class=\"r24-i\" style=\"padding-left: 202px; padding-right: 202px;\"> <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\"><tr><th width=\"52\" class=\"r25-c mobshow resp-table\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r26-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td class=\"r4-i\" style=\"font-size: 0px; line-height: 0px; padding-bottom: 5px; padding-top: 5px;\"> <img src=\"https://creative-assets.mailinblue.com/editor/social-icons/original_light/facebook_32px.png\" width=\"32\" border=\"0\" style=\"display: block; width: 100%;\"></td> <td class=\"nl2go-responsive-hide\" width=\"20\" style=\"font-size: 0px; line-height: 1px;\">­ </td> </tr></table></th> <th width=\"52\" class=\"r25-c mobshow resp-table\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r26-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td class=\"r4-i\" style=\"font-size: 0px; line-height: 0px; padding-bottom: 5px; padding-top: 5px;\"> <img src=\"https://creative-assets.mailinblue.com/editor/social-icons/original_light/instagram_32px.png\" width=\"32\" border=\"0\" style=\"display: block; width: 100%;\"></td> <td class=\"nl2go-responsive-hide\" width=\"20\" style=\"font-size: 0px; line-height: 1px;\">­ </td> </tr></table></th> <th width=\"52\" class=\"r25-c mobshow resp-table\" style=\"font-weight: normal;\"> <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" width=\"100%\" class=\"r26-o\" style=\"table-layout: fixed; width: 100%;\"><tr><td class=\"r4-i\" style=\"font-size: 0px; line-height: 0px; padding-bottom: 5px; padding-top: 5px;\"> <img src=\"https://creative-assets.mailinblue.com/editor/social-icons/original_light/twitter_32px.png\" width=\"32\" border=\"0\" style=\"display: block; width: 100%;\"></td> <td class=\"nl2go-responsive-hide\" width=\"20\" style=\"font-size: 0px; line-height: 1px;\">­ </td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table>\r\n</body>\r\n</html>\r\n";



            var smtp = new SmtpClient
            {
                Host = "smtp-relay.brevo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(AuthAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {

                Subject = Subject,
                Body = Body,
                IsBodyHtml = true

            })
            {
                message.Headers.Add("ApiKey", email_APIkEY);
                await smtp.SendMailAsync(message);
            };


        }

        public async Task sendEmailRefund(string reciver, string reciverName,int totalrefund)
        {
            string email_APIkEY = "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";
            var fromAddress = new MailAddress(_configuration["Brevo:AdminAddress"], _configuration["Brevo:DefaultFromName"]);
            var toAddress = new MailAddress(reciver, reciverName);
            string fromPassword = _configuration["Brevo:fromPassword"];
            var AuthAddress = new MailAddress(_configuration["Brevo:AuthAddress"]);
            string Subject = "Invoice";
            string Body = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Invoice of </title>\r\n    <style>\r\n        body {{\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f0f0f0;\r\n        }}\r\n\r\n        .invoice-container {{\r\n            background-color: #fff;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            padding: 20px;\r\n            border: 1px solid #ccc;\r\n            border-radius: 5px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n\r\n        .invoice-header {{\r\n            background-color: #000000;\r\n            color: #fff;\r\n            padding: 10px;\r\n            text-align: center;\r\n        }}\r\n\r\n        .invoice-details {{\r\n            margin-top: 20px;\r\n            margin-bottom: 30px;\r\n        }}\r\n\r\n            .invoice-details h1 {{\r\n                font-size: 24px;\r\n            }}\r\n\r\n        .invoice-table {{\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }}\r\n\r\n            .invoice-table th, .invoice-table td {{\r\n                border: 1px solid #ccc;\r\n                padding: 10px;\r\n                text-align: left;\r\n            }}\r\n\r\n            .invoice-table th {{\r\n                background-color: #f0f0f0;\r\n            }}\r\n\r\n        .invoice-total {{\r\n            margin-top: 20px;\r\n            text-align: right;\r\n        }}\r\n\r\n            .invoice-total h3 {{\r\n                font-size: 20px;\r\n                color: #007bff;\r\n            }}\r\n\r\n        .footer {{\r\n            margin-top: 20px;\r\n            text-align: center;\r\n            color: #777;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"invoice-container\">\r\n        <div class=\"invoice-header\">\r\n            <h1>Globe Wander</h1>\r\n        </div>\r\n        <div class=\"invoice-details\">\r\n            <h1>Invoice Details</h1>\r\n    \r\n        </div>\r\n        <table class=\"invoice-table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>Refund</th>\r\n                   \r\n                    \r\n                                    </tr>\r\n            </thead>\r\n            <tbody>\r\n              ";

            Body+= $"<p> Dear {reciverName},</p>" +
                " <p> We are pleased to inform you that your recent request to update your booking on our platform has been successfully processed. The payment for the additional days will be refunded by the team in 7 working days, and your booking has been updated as per your request.</p>" +
                " <p> We would like to take this opportunity to thank you for choosing our services.Your trust and confidence in us are greatly appreciated.</p>" +
                " <p> If you have any further requests or need assistance, please do not hesitate to visit our website or contact our customer service team.</p>" +
                " <p> Thank you once again for working with us.We look forward to serving you in the future.</p>" +
                " <p> Best regards,<br> Globe Wander </p>";
            Body += $"   </tbody>\r\n        </table>\r\n        <div class=\"invoice-total\">\r\n            <h3>The  Amount Refunded:{totalrefund} $</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"footer\">\r\n        <p>Thank you for your business!</p>\r\n    </div>\r\n</body>\r\n</html>";
            var smtp = new SmtpClient
            {
                Host = "smtp-relay.brevo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(AuthAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true
            })

            {
                message.Headers.Add("ApiKey", email_APIkEY);
                await smtp.SendMailAsync(message);

            }


    ;




        }
    }
    }

