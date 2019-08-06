using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.DAL.Entities;
using WebApi.DAL.Repositories;
using WebApi.Models.Mutate;
using WebApi.Models.View;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseApiController<UserRepository, User, UserMutateModel, UserViewModel>
    {
        public UserController(IMapper mapper, ILogger logger, UserManager<User> userManager, UserRepository repository) : base(mapper, logger, userManager, repository)
        {
        }
    }
}