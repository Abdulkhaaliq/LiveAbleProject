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
                    new People
                    {
                        UserName = "Abdul-Khaaliq",
                        Age = 20,
                        Email = "abdulkhaaliq@gmail.com",
                        Gender = "Male",
                        Password ="Dollie",
                    },
                    new People
                    {
                        UserName = "Abdul",
                        Age = 21,
                        Email = "abdul@gmail.com",
                        Gender = "Male",
                        Password = "Solomon",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
