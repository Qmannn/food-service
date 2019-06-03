using FoodService.Domain.Entities;
using System;

namespace FoodService.Domain.Services.Savers
{
    public interface IDailyOrderSaver
    {
        DailyOrder SaveDailyOrder(DailyOrder order);
    }
}
