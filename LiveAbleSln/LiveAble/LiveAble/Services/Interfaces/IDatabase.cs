using LiveAble.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveAble.Services.Interfaces
{
    public interface IDatabase
    {
        Task<int> SaveItemAsync(People info);
        Task<List<People>> GetAllInformationData();
        Task<People> GetPeopleByEmail(string Email);

    }
}
