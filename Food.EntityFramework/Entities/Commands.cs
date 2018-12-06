using System;

namespace Food.EntityFramework.Entities
{
    public class Commands: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
       
    }
}