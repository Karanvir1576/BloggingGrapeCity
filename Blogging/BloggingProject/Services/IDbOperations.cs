using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BloggingProject.Models;

namespace BloggingProject.Services
{
    public interface IDbOperations
    {
        public object GetData(int userId=0);
        public void UpdateData(object dbModel,object updateModel);
        public void DeleteData(object deleteModel);
        public void InsertData(object model,int userId=0); 
    }
}
