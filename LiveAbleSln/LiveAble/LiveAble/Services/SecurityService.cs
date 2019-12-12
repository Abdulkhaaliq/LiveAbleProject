﻿using LiveAble.Enums;
using LiveAble.Messages;
using LiveAble.Model.Security;
using LiveAble.Services.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveAble.Services
{
    public class SecurityService : ISecurityService
    {
        private IEventAggregator _eventAggregator;
        public IList<MenuItem> _allMenuItems;

        private IDatabase _database;

        public bool LoggedIn { get; set; }

        public SecurityService(IEventAggregator eventAggregator, IDatabase database)
        {
            CreateMenuItems();

            _eventAggregator = eventAggregator;
            _database = database;
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

        public async Task<bool> Login(string Email, string Password)
        {
            // Do Your Stuff to Check if Legit (ie API Calls)

            var userProfile = await _database.GetPeopleByEmail(Email);

            if (userProfile.Password == Password && userProfile.Email == Email)
            {
                LoggedIn = true;
              
                return true;
            }

            return false;
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
            menuItem.NavigationPath = "NavigationPage/LoginPage";
            menuItem.MenuOrder = 99;
            menuItem.MenuType = MenuTypeEnum.LogOut;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 3;
            menuItem.MenuItemName = "About Us";
            menuItem.NavigationPath = "NavigationPage/AboutUs";
            menuItem.MenuOrder = 5;
            menuItem.MenuType = MenuTypeEnum.UnSecured;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 5;
            menuItem.MenuItemName = "Home";
            menuItem.NavigationPath = "NavigationPage/HomePage";
            menuItem.MenuOrder = 3;
            menuItem.MenuType = MenuTypeEnum.Secured;

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 4;
            menuItem.MenuItemName = "Account";
            menuItem.NavigationPath = "NavigationPage/MyAccount";
            menuItem.MenuOrder = 4;
            menuItem.MenuType = MenuTypeEnum.Secured;


        }
    }
}
