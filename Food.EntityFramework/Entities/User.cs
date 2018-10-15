namespace Food.EntityFramework.Entities
{
    internal sealed class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}