using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OfferteWeb.Services
{
    public interface IMailService : IBaseService<Mail, long, OfferteDbContext>, ISearchEntities<Mail>
    {
        void SendMessage(string destinatario, string nomeDestinatario, string cognomeDestinatario, string usernameUtente, string body);
    }

    public class MailService : BaseService<Mail, long, OfferteDbContext>, IMailService
    {
        private readonly IConfiguration Configuration;
        public EmailConfiguration EmailConfiguration { get; private set; }
        public AppConfiguration AppConfiguration { get; private set; }
        public MailService(IConfiguration configuration, EmailConfiguration conf, AppConfiguration appconf, OfferteDbContext context) : base(configuration, context)
        {
            EmailConfiguration = conf;
            AppConfiguration = appconf;
            Configuration = configuration;

        }
        private SmtpClient CreateSmtpClient()
        {
            string smtpStr = EmailConfiguration.SmtpServer!;
            string userStr = EmailConfiguration.SmtpUser!;
            string pwdStr = EmailConfiguration.SmtpPassword!;
            int port = 25;
            var smtp = new SmtpClient(smtpStr, port)
            {
                Credentials = new NetworkCredential(userStr, pwdStr)
            };
            return smtp;
        }

        public void SendMessage(string destinatario, string nomeDestinatario, string cognomeDestinatario, string usernameUtente, string body)
        {
            string mittente = EmailConfiguration.SmtpFrom!;
            MailMessage message = new()
            {
                Subject = "Nuovo Quesito assegnato",
                Body = @$"<p>Ciao {nomeDestinatario} {cognomeDestinatario}.</p>
                Ti è stato assegnato un quesito inviato dal Cliente {usernameUtente}.
                <p>Testo del Messaggio:</p>
                <p>--------------------</p>
                {body}
                <p>--------------------</p>
                <p>Grazie</p>
                <p>Sixtema S.p.a</p>"
            };
            message.From = new MailAddress(mittente);
            message.IsBodyHtml = true;
            message.To.Add(destinatario);

            SmtpClient smtp = CreateSmtpClient();
            smtp.Send(message);
        }

        public IEnumerable<Mail> SearchByString(string searchString, QueryBuilderSearchModel model, bool includeDeleted)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mail> SearchAll(bool includeDeleted, QueryBuilderSearchModel model)
        {
            throw new NotImplementedException();
        }
    }

    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}