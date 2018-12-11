using System;
using System.Collections.Generic;
using System.Text;

namespace JobSchedule.Entities.Models
{
    public abstract class BaseEntity
    {
        abstract public int Id { get; set; }
    }
}
