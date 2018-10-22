namespace Food.EntityFramework.Entities
{
    internal class OrderDish
    {
        public int OrderDishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}