using Core.DAL.Repositories;
using WebApi.DAL.Entities;

namespace WebApi.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }


    }
   
}
