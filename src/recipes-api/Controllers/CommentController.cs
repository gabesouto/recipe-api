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
[Route("comment")]
public class CommentController : ControllerBase
{
    public readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        this._service = service;
    }


    [HttpPost]
    public IActionResult Create([FromBody] Comment comment)
    {
        try
        {
            if (comment == null)
                return BadRequest();
            _service.AddComment(comment);
            return CreatedAtRoute("GetComment", new { name = comment }, comment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("{name}", Name = "GetComment")]
    public IActionResult Get(string name)
    {
        try
        {
            var comment = _service.GetComments(name);
            if (comment == null)
                return NotFound();
            return Ok(comment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}