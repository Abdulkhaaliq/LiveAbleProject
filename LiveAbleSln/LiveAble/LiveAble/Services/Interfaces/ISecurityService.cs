using LiveAble.Model.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveAble.Services.Interfaces
{ 
    public interface ISecurityService
    {
    IList<MenuItem> GetAllowedAccessItems();
    Task<bool> Login(string Email, string Password);
    void LogOut();
    }
}
