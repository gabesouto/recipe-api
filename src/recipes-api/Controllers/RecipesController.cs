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
[Route("recipe")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;

    public RecipesController(IRecipeService service)
    {
        this._service = service;
    }


    [HttpGet]
    public IActionResult Get()
    {
        var recipes = _service.GetRecipes();
        return Ok(recipes);
    }



    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        if (!_service.RecipeExists(name))
            return NotFound();
        var recipe = _service.GetRecipe(name);
        return Ok(recipe);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        if (recipe == null)
            return BadRequest();
        _service.AddRecipe(recipe);
        return CreatedAtRoute("GetRecipe", new { name = recipe.Name }, recipe);
    }


    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        if (recipe == null || !_service.RecipeExists(recipe.Name))
            return BadRequest();

        _service.UpdateRecipe(recipe);
        return NoContent();
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        if (!_service.RecipeExists(name))
            return NotFound();
        _service.DeleteRecipe(name);
        return NoContent();
    }
}
