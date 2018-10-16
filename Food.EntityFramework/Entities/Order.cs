using System;
using System.Collections.Generic;
using System.Text;

namespace Food.EntityFramework.Entities
{
    internal sealed class Order : IEntity
    {
        public int Id { get; set; }
        public int TotalSum { get; set; }
        public DateTime OrderDate { get; set; }
        public int IdMenu { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int IdUser { get; set; }
        //таблица блюдо
    }
}
