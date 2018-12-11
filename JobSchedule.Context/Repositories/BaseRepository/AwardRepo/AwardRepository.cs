using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.AwardRepo
{
    public class AwardRepository : Repository<Award>, IAwardRepository
    {
        public AwardRepository(JobDBContext context) : base(context)
        {
        }

        //public JobDBContext JobDBContext
        //{
        //    get { return context as JobDBContext; }
        //}

        //public Task<IEnumerable<Award>> GetProductsWithProviders(int pageIndex, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
