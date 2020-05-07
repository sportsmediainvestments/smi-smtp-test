using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace smtpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String userName = "";
            String userPwd = "";
            String serverPort = "";
            String mailTo = "";

            Console.Write("Username: ");
            userName = Console.ReadLine();

            Console.Write("Password: ");
            userPwd = Console.ReadLine();

            Console.Write("Port (465/587): ");
            serverPort = Console.ReadLine();

            Console.Write("Mail To: ");
            mailTo = Console.ReadLine();

            MailMessage message = new MailMessage();
            message.To.Add(mailTo);
            message.From = new MailAddress(userName);
            message.Subject = "Testing SMTP SSL Connection";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = "Test Mail :-)";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(userName, userPwd);
            client.Port = Convert.ToInt32(serverPort);
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            client.Send(message);
        }
    }
}
