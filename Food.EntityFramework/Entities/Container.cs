namespace Food.EntityFramework.Entities
{
    internal sealed class Container : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
