using LiveAble.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveAble.Services.Interfaces
{
    interface IDatabase
    {
        List<People> GetAllInformationData();

        People GetInformationData(int id);

        void SaveItemAsync(People info);

        void DeleteInfo(int id);
    }
}
