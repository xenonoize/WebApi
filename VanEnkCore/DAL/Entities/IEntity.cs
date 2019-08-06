using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DAL.Entities
{
    public interface IEntity
    {
          
    }

    public interface IUserEntity : IEntity
    {
        [Key]
        string Id { get; set; }
        DateTimeOffset CreationDateTime { get; set; }
    }
    public interface IDataEntity : IEntity
    {
        [Key]
        Guid Id { get; set; }
        DateTimeOffset CreationDateTime { get; set; }
    }

}
