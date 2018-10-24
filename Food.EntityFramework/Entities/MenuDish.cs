namespace Food.EntityFramework.Entities
{
    internal class MenuDish
    {
        public int DishId { get; set; }
        public int MenuId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
