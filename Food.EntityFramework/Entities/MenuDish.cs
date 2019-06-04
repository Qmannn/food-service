namespace Food.EntityFramework.Entities
{
    public class MenuDish : IEntity
    {
        public int Id { get; set; }

        public int DishId { get; set; }
        public int MenuId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
