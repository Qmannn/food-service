using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core
{
    public interface IOrder
    {
        public int OrderId { get; }
        public int TotalAmount { get; }
        public DateTime OrderDate { get; }
        public DateTime DeliveryDate { get; }
        public IMenu Menu { get; }//id меню
        public IUser User { get; }//id пользователя
        public List<IDish> OrderDishes { get; }
        //блюдо в заказе(таблица)
    }
}