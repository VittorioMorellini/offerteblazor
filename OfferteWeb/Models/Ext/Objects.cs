using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferteWeb.Models;

public class Role
{
    public const string ADMIN = "ADMIN";    //Amministratore
    public const string MANAGER = "MANAGER";    //Capogruppo della Company
    public const string OPERATOR = "OPERATOR";  //Centralino
    public const string CUSTOMER = "CUSTOMER";  //Cliente che vede i suoi ordini
}

public class NotificationTypes
{
    public const string MAIL = "M";
    public const string APP_MESSAGE = "A";
}

public static class StatoOfferta
{
    public static string? GetStatusDescription(byte statusCode)
    {
        switch (statusCode)
        {
            case 1:
                return Inserita.Item2;
            case 2:
                return Accettata.Item2;
            case 3:
                return Rifiutata.Item2;
            default:
                return "Undefined";
        }
    }

    public static Tuple<byte, string> Inserita { get { return Tuple.Create((byte)1, "Inserita"); } }
    public static Tuple<byte, string> Accettata { get { return Tuple.Create((byte)2, "Accettata"); } }
    public static Tuple<byte, string> Rifiutata { get { return Tuple.Create((byte)3, "Rifiutata"); } }
}
