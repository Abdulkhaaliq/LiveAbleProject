using LiveAble.Enums;
using LiveAble.Messages;
using LiveAble.Model.Security;
using LiveAble.Services.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveAble.Services
{
    public class SecurityService : ISecurityService
    {
        private IEventAggregator _eventAggregator;
        public IList<MenuItem> _allMenuItems;

        public bool LoggedIn { get; set; }

        public SecurityService(IEventAggregator eventAggregator)
        {
            CreateMenuItems();

            _eventAggregator = eventAggregator;
        }

        public IList<MenuItem> GetAllowedAccessItems()
        {
            if (LoggedIn)
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.Secured || item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.LogOut)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
            else
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.Login)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
        }

        public bool Login(string Email, string Password)
        {
            // Do Your Stuff to Check if Legit (ie API Calls)

            LoggedIn = true;

            return true;
        }

        public void LogOut()
        {
            LoggedIn = false;

            _eventAggregator.GetEvent<LogOutMessage>().Publish();
        }



        private void CreateMenuItems()
        {
            _allMenuItems = new List<MenuItem>();

            var menuItem = new MenuItem();
            menuItem.MenuItemId = 1;
            menuItem.MenuItemName = "Login";
            menuItem.NavigationPath = "NavigationPage/LoginPage";
            menuItem.MenuType = MenuTypeEnum.Login;
            menuItem.MenuOrder = 99;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 2;
            menuItem.MenuItemName = "Logout";
            menuItem.NavigationPath = "";
            menuItem.MenuOrder = 99;
            menuItem.MenuType = MenuTypeEnum.LogOut;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 3;
            menuItem.MenuItemName = "About Us";
            menuItem.NavigationPath = "NavigationPage/AboutUs";
            menuItem.MenuOrder = 3;
            menuItem.MenuType = MenuTypeEnum.UnSecured;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 5;
            menuItem.MenuItemName = "SeeAllPage";
            menuItem.NavigationPath = "NavigationPage/SeeAllPage";
            menuItem.MenuOrder = 5;
            menuItem.MenuType = MenuTypeEnum.Secured;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 4;
            menuItem.MenuItemName = "Account";
            menuItem.NavigationPath = "NavigationPage/AccountPage";
            menuItem.MenuOrder = 4;
            menuItem.MenuType = MenuTypeEnum.Secured;
        }
    }
}
