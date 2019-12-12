using LiveAbleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveAbleApi.Data
{
    public class SeedData
    {
        public static void Initialize(PeopleContext context)
        {
            if (!context.UsersInfo.Any())
            {
                context.UsersInfo.AddRange(

                );

                context.SaveChanges();
            }
        }
    }
}
