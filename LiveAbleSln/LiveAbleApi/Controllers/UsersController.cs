using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveAbleApi.Data;
using LiveAbleApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveAbleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PeopleContext _context;

        public UsersController(PeopleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<People>> GetAll() =>
            _context.UsersInfo.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetById(long id)
        {
            var user = await _context.UsersInfo.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<People>> Create(People user)
        {
            _context.UsersInfo.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.ID }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, People user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _context.UsersInfo.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.UsersInfo.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}