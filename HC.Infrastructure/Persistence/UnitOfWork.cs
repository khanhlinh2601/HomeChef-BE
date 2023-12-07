using HC.Application.Common.Interfaces;
using HC.Domain.Entities;
using HC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HC.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IGenericRepository<User> _user;
        public IGenericRepository<User> User{
            get
            {
                if (_user == null)
                {
                    _user = new GenericRepository<User>(_dbContext);
                }
                return _user;
            }
        }

        private IGenericRepository<Chef> _chef;
        public IGenericRepository<Chef> Chef {
            get
            {
                if (_chef == null)
                {
                    _chef = new GenericRepository<Chef>(_dbContext);
                }
                return _chef;
            }
        }

        private IGenericRepository<Province> _province;
        public IGenericRepository<Province> Province {
            get
            {
                if (_province == null)
                {
                    _province = new GenericRepository<Province>(_dbContext);
                }
                return _province;
            }
        }

        private IGenericRepository<District> _district;
        public IGenericRepository<District> District {
            get
            {
                if (_district == null)
                {
                    _district = new GenericRepository<District>(_dbContext);
                }
                return _district;
            }
        }

        private IGenericRepository<CustomerAddress> _customerAddress;
        public IGenericRepository<CustomerAddress> CustomerAddress {
            get
            {
                if (_customerAddress == null)
                {
                    _customerAddress = new GenericRepository<CustomerAddress>(_dbContext);
                }
                return _customerAddress;
            }
        }

        
        private IGenericRepository<Role> _role;

        public IGenericRepository<Role> Role {
            get
            {
                if (_role == null)
                {
                    _role = new GenericRepository<Role>(_dbContext);
                }
                return _role;
            }
        }
        private IGenericRepository<Chat> _chat;

        public IGenericRepository<Chat> Chat {
            get
            {
                if (_chat == null)
                {
                    _chat = new GenericRepository<Chat>(_dbContext);
                }
                return _chat;
            }
        }

        private IGenericRepository<Order> _order;
        public IGenericRepository<Order> Order {
            get
            {
                if (_order == null)
                {
                    _order = new GenericRepository<Order>(_dbContext);
                }
                return _order;
            }
        }
        private IGenericRepository<OrderDetail> _orderDetail;
        public IGenericRepository<OrderDetail> OrderDetail {
            get
            {
                if (_orderDetail == null)
                {
                    _orderDetail = new GenericRepository<OrderDetail>(_dbContext);
                }
                return _orderDetail;
            }
        }
        private IGenericRepository<Feedback> _feedback;
        public IGenericRepository<Feedback> Feedback {
            get
            {
                if (_feedback == null)
                {
                    _feedback = new GenericRepository<Feedback>(_dbContext);
                }
                return _feedback;
            }
        }
        private IGenericRepository<Promotion> _promotion;
        public IGenericRepository<Promotion> Promotion {
            get
            {
                if (_promotion == null)
                {
                    _promotion = new GenericRepository<Promotion>(_dbContext);
                }
                return _promotion;
            }
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _dbContext.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is null)
                return;

            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            catch
            {
                await RolebackTransactionAsync();
            }
        }

        public async Task RolebackTransactionAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
