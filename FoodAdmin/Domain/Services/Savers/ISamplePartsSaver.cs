using Food.Core.Domain.Entities;

namespace FoodAdmin.Domain.Services.Savers
{
    public interface ISamplePartsSaver
    {
        void SavePart(DailySamplePart dailySamplePart);
    }
}