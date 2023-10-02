using Application.Models;
using Application.Models.DTOs;
using Application.Models.DTOs.Category;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _service;

    public AdminController(IAdminService service)
    {
        _service = service;
    }

    [HttpGet("getStatistics")]
    [Authorize(AuthenticationSchemes ="Bearer",Roles = "Admin")]
    public ActionResult<Statistics> GetStatistics()
    {
        var statistics = _service.GetStatistics();
        return Ok(statistics);
    }

    [HttpGet("showAllCategories")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public ActionResult<IEnumerable<CategoryShowDTO>> GetAllCategories()
    {
        var categories = _service.GetAllCategories();
        return Ok(categories);
    }

    [HttpPost("addAdmin")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult<bool>> AddAdmin([FromBody] LoginRequest model)
    {
        var result = await _service.AddNewAdmin(model);
        return Ok(result);
    }

    [HttpPut("updateCategory")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult<bool>> UpdateCategory([FromBody] CategoryUpdateDTO model)
    {
        var result = await _service.UpdateCategoryAsync(model);
        return Ok(result);
    }

    [HttpPost("addCategory")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult<bool>> AddCategory([FromBody] CategoryDTO model)
    {
        var result = await _service.AddCategoryAsync(model);
        return Ok(result);
    }
}

