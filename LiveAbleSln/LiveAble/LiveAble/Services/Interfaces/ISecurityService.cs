using LiveAble.Model.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveAble.Services.Interfaces
{ 
    public interface ISecurityService
    {
    IList<MenuItem> GetAllowedAccessItems();
    bool Login(string Email, string Password);
    void LogOut();
    }
}
