using AutoMapper;
using WebApi.DAL.Entities;
using WebApi.Models.Mutate;
using WebApi.Models.View;

namespace WebApi.Util
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("DataWebAPIProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<UserMutateModel, User>();
            CreateMap<User, UserViewModel>();

        }
    }
}
