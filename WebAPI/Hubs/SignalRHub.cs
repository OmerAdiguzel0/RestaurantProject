using Microsoft.AspNetCore.SignalR;
using Restaurant.DataAccessLayer.Concrete;

namespace WebAPI.Hubs
{
    public class SignalRHub:Hub
    {
        RestaurantContext context = new RestaurantContext();
        public async Task SendCategoryCount()
        {
            var value =context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
