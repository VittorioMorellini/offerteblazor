using System.Text.Json;

namespace OfferteWeb.State;

public class InitialApplicationState
{
    public AuthData AuthData { get; set; }
}

public class AuthData
{
    public string Username { get; set; }
    public string Role { get; set; }
    public string Mail { get; set; }
    public string Token { get; set; }
    public string Id { get; set; }
    public string RagioneSociale { get; set; }
    //public JsonElement UserData { get; set; }
    //public string UserDataString { get; }
}
