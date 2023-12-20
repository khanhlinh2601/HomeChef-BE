using HC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> User {  get; }
        IGenericRepository<Chef> Chef { get; }
        IGenericRepository<Role> Role { get; }
        IGenericRepository<Chat> Chat { get; }
        IGenericRepository<Order> Order { get; }
        IGenericRepository<OrderDetail> OrderDetail { get; }
        IGenericRepository<Feedback> Feedback { get; }
        IGenericRepository<Promotion> Promotion { get; }

        IGenericRepository<Province> Province { get; }
        IGenericRepository<District> District { get; }
        IGenericRepository<CustomerAddress> CustomerAddress { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RolebackTransactionAsync();
    }
}
