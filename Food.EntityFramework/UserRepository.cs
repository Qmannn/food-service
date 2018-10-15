using Food.EntityFramework.Context;
using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Food.EntityFramework
{
    class UserRepository : Repository<UserDbContext, User>
    {
        private UserDbContext _userDbContext;
        private bool _isDisposed;

        public UserRepository(){_userDbContext = new UserDbContext();}

        public override User GetItem(int id) => _userDbContext.Users.Find(id);

        public override IEnumerable<User> GetList() => _userDbContext.Users;

        public override void Create(User item) { _userDbContext.Users.Add(item); }

        public override void Update(User item) { _userDbContext.Entry(item).State = EntityState.Modified; }

        public override void Save() { _userDbContext.SaveChanges(); }

        public override void Delete(User item)
        {
            var user = _userDbContext.Users.Find(item);
            _userDbContext.Users?.Remove(user);
        }

        public override void Delete(int id)
        {
            var user = _userDbContext.Users.Find(id);
            _userDbContext.Users?.Remove(user);
        }

        public override void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;
            _userDbContext.Dispose();
            System.GC.SuppressFinalize(this);
        }
    }
}
