using Food.Core.Domain.Entities;

namespace FoodAdmin.Domain.Services.Savers
{
    public interface IDailySampleSaver
    {
        DailySample Save(DailySample dailySample);
    }
}