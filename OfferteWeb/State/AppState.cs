using Microsoft.JSInterop;
using OfferteWeb.Services;
using OfferteWeb.Data;
using OfferteWeb.Exceptions;
using OfferteWeb.Models;

namespace OfferteWeb.State;

//public class AppState
//{
//    private bool Initialized = false;
//    private IAgenteService _agenteService;
//    public AppState(IAgenteService agenteService)
//    {
//        _agenteService = agenteService;
//    }
//    //public void Initialize(InitialApplicationState InitialState)
//    //{
//    //    var usrId = InitialState?.AuthData?.Username!;
//    //    User = _agenteService.Find(Convert.ToInt64(usrId));

//    //    if (User == null || User != null && User.ExpirationDate.HasValue && User.ExpirationDate < DateTime.Now)
//    //    {
//    //        throw new AuthorizeException(401);
//    //    }
//    //    if (User != null && User.Disabled == true)
//    //    {
//    //        throw new AuthorizeException(403);
//    //    }

//    //}
//    public Agente? User { get; set; }
//    public string? Username
//    {
//        get
//        {
//            if (User == null)
//            {
//                throw new AuthorizeException(401);
//            }
//            return User?.Username;
//        }
//    }
//    public string? Ruolo
//    {
//        get
//        {
//            if (User == null)
//            {
//                throw new AuthorizeException(401);
//            }
//            return User?.Role;
//        }
//    }
//    public long? UserId { get { return User?.Id; } }
//}
