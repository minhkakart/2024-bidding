﻿using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController(ICategoryService categoryService) : ControllerBase
	{
		private readonly ICategoryService _categoryService = categoryService;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _categoryService.GetAll();
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _categoryService.GetById(id);
			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			await _categoryService.Create(category);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(Category category)
		{
			await _categoryService.Update(category);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _categoryService.Delete(id);
			return Ok();
		}

	}
}
