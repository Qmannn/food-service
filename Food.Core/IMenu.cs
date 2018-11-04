using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core
{
    public interface IMenu
    {
        public int MenuId { get; }
        public DateTime Date { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<IDish> Dishes { get; }  // интерфейс блюда
    }
}