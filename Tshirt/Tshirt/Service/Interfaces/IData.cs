 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tshirt.Models;

namespace Tshirt.Service.Interfaces
{
   public interface IData
    {
        Task<List<Tees>> GetItemsAsync();
        Task<List<Tees>> GetItemsNotDoneAsync();
        Task<Tees> GetItemAsync(int id);
        Task<int> SaveItemAsync(Tees item);
        Task<int> DeleteItemAsync(Tees item);
    }
}
