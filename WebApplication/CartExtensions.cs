using DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApplication
{
    public static class CartExtensions
    {
        private const string CartSessionKey = "cart";

        public static List<Dishes> GetCart(this ISession session)
        {
            return HttpContext.Session.GetString("username");
            //return session.GetObjectFromJson<List<Dishes>>(CartSessionKey) ?? new List<Dishes>();
        }

        public static void SaveCart(this ISession session, List<Dishes> cart)
        {
            session.SetObjectAsJson(CartSessionKey, cart);
            
        }
    }
}
