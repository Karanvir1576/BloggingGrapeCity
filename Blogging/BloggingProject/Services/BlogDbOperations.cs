using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BloggingProject.Models;

namespace BloggingProject.Services
{
    public class BlogDbOperations : IDbOperations
    {
        private readonly Test20Context _context;
        public  BlogDbOperations(Test20Context context)
        {
            _context = context;
        }
        public object GetData(int userId=0)
        {
            return _context.Blogs.Where(item => _context.UserXBlogs.Any(userBlog => userBlog.BlogId == item.BlogId && userBlog.UserId == userId)).ToList().OrderByDescending(item => item.DttmRcdAdded);
        }
        public void InsertData(object blogModel,int userId)
        {
            var blog = (Blog)blogModel;
            _context.Database.ExecuteSqlInterpolated($"CreateBlog {blog.BlogHeader}, {blog.Content},{userId}");//Called StoredProc for Inserting
        }

        public void UpdateData(object dbModel, object updateModel)
        {
            var dbBlog = (Blog)dbModel;
            var blogToUpdate = (Blog)updateModel;
            dbBlog.BlogHeader = blogToUpdate.BlogHeader;
            dbBlog.Content = blogToUpdate.Content;
            dbBlog.DttmRcdUpdated = DateTime.Now.ToString("yyyyMMddhhmmss");
            _context.Update(dbModel);
            _context.SaveChanges();
        }

        public void DeleteData(object deleteModel)
        {
            var blogToDelete = (Blog)deleteModel;
            _context.Blogs.Remove(blogToDelete);
            _context.SaveChanges();
        }


    }
}
