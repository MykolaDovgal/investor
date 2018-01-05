using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;

namespace Investor.Service.Interfaces
{
    public interface IStatisticsService
    {
        Task AddStatistics(Statistics statistics);
    }
}
