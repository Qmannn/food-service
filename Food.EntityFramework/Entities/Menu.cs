using System;

namespace Food.EntityFramework.Entities
{
    internal sealed class Menu : IEntity
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
        //блюда 
    }
}
