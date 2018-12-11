using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSchedule.Context.Repositories.BaseRepository.FamilyRepo
{
    public class FamilyRepository : Repository<Family>, IFamilyRepository
    {
        public FamilyRepository(JobDBContext context) : base(context)
        {
        }

        public JobDBContext JobDBContext
        {
            get { return context as JobDBContext; }
        }
    }
}
