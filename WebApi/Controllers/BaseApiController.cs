using AutoMapper;
using Core.DAL.Entities;
using Core.DAL.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebApi.Controllers
{
    public class BaseApiController<TService, TEntity, TMutateModel, TViewModel> : ControllerBase
        where TEntity : class, IEntity
        where TMutateModel : class, IBindModel
        where TViewModel : class, IBindModel
        where TService : Repository<TEntity>
    {
        protected readonly UserManager<User> UserManager;
        protected readonly IMapper Mapper;
        protected readonly ILogger Logger;
        protected readonly TService Repository;

        public BaseApiController(IMapper mapper,
                              ILogger logger,
                              UserManager<User> userManager,
                              TService repository)
        {
            Repository = repository;
            Mapper = mapper;
            UserManager = userManager;
            Logger = logger;
        }

        [HttpGet]
        protected IActionResult Get()
        {
            return Ok(Mapper.Map<TViewModel>(Repository.GetAll()));
        }

        [HttpGet("{id}")]
        protected async Task<IActionResult> Get<TKey>([FromRoute]TKey id)
        {
            return Ok(Mapper.Map<TViewModel>(await Repository.FindAsync(id)));
        }
        [HttpPost]
        protected async Task<IActionResult> Post([FromBody]TMutateModel mutateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TEntity entity = Mapper.Map<TEntity>(mutateModel);

            await Repository.AddAsync(entity);

            if (await Repository.SaveChangesAsync() == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPut("{id}")]
        protected async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] TMutateModel mutateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Task<TEntity> entity = Repository.FindAsync(id);
            entity = Mapper.Map(mutateModel, entity);

            if (id.Equals(entity.Id))
                return BadRequest();

            Repository.Update(entity);

            if (await Repository.SaveChangesAsync() == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        protected async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TEntity entity = await Repository.FindAsync(id);

            if (entity == null)
                return NotFound();

            Repository.Remove(entity);

            if (await Repository.SaveChangesAsync() == 0)
                return BadRequest();

            return Ok();
        }

        [NonAction]
        protected virtual string GetUserId()
        {
            return UserManager.GetUserId(HttpContext.User);
        }
    }
}
