﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BloggingProject.Helper
{
    public class UserLoginHelper
    {
        IConfiguration _configuration;

        public UserLoginHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public UserLogin ValidateUser(UserLogin login)
        {
            UserLogin user = null;
            if (login.UserName == "GrapeCity")
            {
                user = new UserLogin { UserName = "GrapeCity", Password = "GrapeCityRocks123" }; //Kept in code for test purposes. Can be encrypted and stored in db.
                return user;

            }
            return user;
        }

        public bool ValidatePassword(string password, UserLogin user)
        {
            if (password.CompareTo(user.Password) == 0)
                return true;
            return false;
        }

        public string GetAuthToken(UserLogin userLogin)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

            var securityToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],_configuration["Jwt:Audience"], null, null,DateTime.Now.AddHours(2.0), new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
