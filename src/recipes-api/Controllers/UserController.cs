using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    public readonly IUserService _service;

    public UserController(IUserService service)
    {
        this._service = service;
    }

    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {
        try
        {
            var user = _service.GetUser(email);
            if (user == null)
                return NotFound();
            return Ok(user);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        try
        {
            if (user == null)
                return BadRequest();
            _service.AddUser(user);
            return CreatedAtRoute("GetUser", new { email = user.Email }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{email}")]
    public IActionResult Update(string email, [FromBody] User user)
    {
        try
        {
            var userUpdate = _service.GetUser(email);
            if (userUpdate == null) return NotFound();
            _service.UpdateUser(user);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        try
        {
            var user = _service.GetUser(email);
            if (user == null) return NotFound();
            _service.DeleteUser(email);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}