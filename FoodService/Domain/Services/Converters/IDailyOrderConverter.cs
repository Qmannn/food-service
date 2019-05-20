using Food.EntityFramework.Entities;
using FoodService.Domain.Entities;
using FoodService.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Domain.Services.Converters
{
    public interface IDailyOrderConverter
    {
        DailyOrder ConvertDailyOrder(OrderDto order, User user, Menu menu);
    }
}
