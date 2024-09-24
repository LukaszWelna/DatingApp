using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext dbContext) : ControllerBase
{
    [HttpGet] // /api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
    {
        var users = await dbContext.Users.ToListAsync();

        return Ok(users);
    }

    [HttpGet("{id:int}")] // /api/users/1
    public async Task<ActionResult<AppUser>> GetUser(int id) 
    {
        var user = await dbContext.Users
            .FindAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
}
