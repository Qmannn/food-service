namespace Food.EntityFramework.Entities
{
    internal sealed class User : IEntity
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string Name { get; set; }
    }
}