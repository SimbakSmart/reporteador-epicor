

using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public  interface ICallInQueuesProvider
    {
        Task<int> FetchCountAsync(string queryParams = "");

        Task<List<CallInQueues>> FetchAllAsync(int pageSize = 50, int startRow = 0,string queryParams="");
    }
}
