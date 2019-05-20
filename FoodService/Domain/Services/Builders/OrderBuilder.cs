using Food.EntityFramework;
using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodService.Domain.Entities;
using FoodService.Domain.Exceptions;
using FoodService.Domain.Services.Converters;
using FoodService.Dto.Order;

namespace FoodService.Domain.Services.Builders
{
    public class OrderBuilder: IOrderBuilder
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IDailyOrderConverter _dailyOrderConverter;

        public OrderBuilder(IMenuRepository menuRepository, IRepository<User> userRepository, IDailyOrderConverter dailyOrderConverter)
        {
            _menuRepository = menuRepository;
            _userRepository = userRepository;
            _dailyOrderConverter = dailyOrderConverter;
        }

        public DailyOrder BuildDailyOrder(OrderDto order)
        {
            Menu menu = _menuRepository.GetMenu(order.MenuId);
            if (menu == null)
            {
                throw new MenuNotExistException(order.MenuId);
            }
            User user = _userRepository.GetItem(order.UserId);
            if (user == null)
            {
                throw new UserNotExistException(order.UserId);
            }
            return _dailyOrderConverter.ConvertDailyOrder(order, user, menu);
        }
    }
}
