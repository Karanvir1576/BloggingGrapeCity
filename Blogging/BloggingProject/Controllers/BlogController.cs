using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BloggingProject.Models;
using Microsoft.EntityFrameworkCore;

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
        public BlogController(Test20Context context)
        {
            _context = context;
        }
        // GET: api/<BlogController>
        [HttpGet]
        public IActionResult Get()  //fetching all blogs
        {
            try
            {
                var blogs = _context.Blogs.ToList();
                return Ok(blogs);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
   

        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Post([FromBody] Blog value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(value);
            }
            try
            {
                _context.Blogs.Add(value);
                
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
            
        }

        // PUT api/<BlogController>/5
        [HttpPut]
        [Route("edit/{id}")]
        public void Put(int id)     
        {
            try
            {

            }
            catch
            {

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
                    _context.Blogs.Remove(blog);
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }

        }
    }
}
