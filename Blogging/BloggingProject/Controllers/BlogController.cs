using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BloggingProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BloggingProject.Helper;
using BloggingProject.Services;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggingProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly Test20Context _context;
        private readonly IDbOperations _dbOperations;
        int userId;
        public BlogController(Test20Context context, IDbOperations dbOperations)
        {
            _context = context;
            _dbOperations = dbOperations;
        }

        // GET: api/<BlogController>
        [HttpGet]
        public IActionResult Get()  //I have assumed that fetching all blogs created by user only.
        {
            try
            {
                userId = UserLoginHelper.GetTokenId(HttpContext);
                var allBlogs = _dbOperations.GetData(userId) as IEnumerable<Blog>;
             
                if (allBlogs.Count() != 0)
                    return Ok(allBlogs);
                else
                    return Ok("No Blogs found");
            }
            catch
            {
                return StatusCode(500);//Implement a logger where we can log the errors.
            }
        }
   

        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Post(Blog blogModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(blogModel);
            }
            try
            {
                userId = UserLoginHelper.GetTokenId(HttpContext);
                _dbOperations.InsertData(blogModel,userId);
                return Ok("Blog added successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500);//Implement a logger where we can log the errors.
            }
            
        }

        // PUT api/<BlogController>/5
        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult Put(int id,Blog blogModel)     
        {
            try
            {
                var blog = _context.Blogs.Find(id);
                if(blog!=null)
                {
                    _dbOperations.UpdateData(blog, blogModel);
                    return Ok("Blog Updated Successfully");
                }
                return Ok("Particular Blog does not exist");

            }
            catch
            {
                return StatusCode(500); //Implement a logger where we can log the errors.
            }

        }

        // DELETE api/<BlogController>/5
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var blog = _context.Blogs.Find(id);
                if(blog!=null)
                {
                    _dbOperations.DeleteData(blog);
                    return Ok("Blog Successfully Deleted");
               }
                return NotFound();
            }
            catch(Exception e)
            {
                return StatusCode(500);//Implement a logger where we can log the errors.
            }

        }
    }
}
