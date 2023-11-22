using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class RestaurantDataAccess : IRestaurantDataAccess
    {
        private IDbContext _dbContext;

        public RestaurantDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetByExternalId(string Id)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
