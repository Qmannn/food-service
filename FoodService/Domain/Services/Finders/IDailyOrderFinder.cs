using FoodService.Domain.Entities;
using System;

namespace FoodService.Domain.Services.Finders
{
    public interface IDailyOrderFinder
    {
        DailyOrder GetDailyOrder(int userId, DateTime date);
    }
}
