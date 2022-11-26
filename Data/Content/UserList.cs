using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class UserList
    {
        public static List<User> GetUnverifiedUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = "33be3fbb-9edf-4e2d-9ccc-c265b9af5b2c",
                    Name = "Eric Green",
                    Address = "Old Town 35",
                    PhoneNumber = "+420 854 815 645",
                    Email = "ericishere@email.com",
                    UserName = "eric",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }
            };
        }

        public static List<User> GetVerifiedUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = "84712b0f-17cc-43a2-ae83-0536dad5e0c1",
                    Name = "Jenny Blue",
                    Address = "New Town 36",
                    PhoneNumber = "+15 654 215",
                    Email = "jennyishere@email.com",
                    UserName = "jenny",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }
            };
        }
        public static List<User> GetVets()
        {
            return new List<User>()
            {
                new User
                {
                    Id = "78eb4516-8e37-4ed2-b386-2cf62ea8a61b",
                    Name = "John Black",
                    Address = "Small Town 37",
                    PhoneNumber = "+178 154 754 215",
                    Email = "johnishere@email.com",
                    UserName = "john",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }
            };
        }
        public static List<User> GetCareTakers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = "d17770c6-f8bf-4472-a03c-739e49aa01b3",
                    Name = "Jimmy Yellow",
                    Address = "Large Town 38",
                    PhoneNumber = "+114 154 754 215",
                    Email = "jimmyishere@email.com",
                    UserName = "jimmy",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }
            };
        }
    }
}