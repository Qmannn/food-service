using System;

namespace Food.EntityFramework.Entities
{
    internal sealed class Order : IEntity
    {
        public int Id { get; set; }
        public int TotalSum { get; set; }
        public DateTime OrderDate { get; set; }
        public int MenuId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int UserId { get; set; }
        //таблица блюдо
    }
}
