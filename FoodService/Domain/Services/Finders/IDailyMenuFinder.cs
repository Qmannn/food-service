using FoodService.Dto.DayMenu;
using System;

namespace FoodService.Domain.Services.Finders
{
    public interface IDailyMenuFinder
    {
        DayMenuDto GetMenuFromDate(DateTime menuDate);
    }
}
