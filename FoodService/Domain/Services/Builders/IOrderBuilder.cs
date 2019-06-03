using FoodService.Domain.Entities;
using FoodService.Dto.Order;

namespace FoodService.Domain.Services.Builders
{
    public interface IOrderBuilder
    {
        DailyOrder BuildDailyOrder(OrderDto order);
    }
}
