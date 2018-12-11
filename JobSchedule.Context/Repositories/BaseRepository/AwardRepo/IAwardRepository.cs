using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.AwardRepo
{
    public interface IAwardRepository : IRepository<Award>
    {
        //Task<IEnumerable<Award>> SortAllAscending<T>(Expression<Func<Award, T>> orderBy, int count = 10);

    }
}
