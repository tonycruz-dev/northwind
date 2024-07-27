using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.DTOs;
using NorthwindApi.Helpers;
using NorthwindApi.Interfaces;
using NorthwindApi.Models;

namespace NorthwindApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(NorthwindContext _context, ISalesCategory _salesCategoryRepo) : ControllerBase
{
    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return category;
    }

    // PUT: api/Categories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        _context.Entry(category).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Categories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategory", new { id = category.Id }, category);
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }

    [HttpGet("CategorySales")]
    public async Task<ActionResult<SalesCategoryDto>> GetCategoriesSales([FromQuery] SalesCategoriesParam categoriesSalesParam)
    {
        return await _salesCategoryRepo.GetCategoriesChartAsync(categoriesSalesParam);
        
        //var fromShippedDateParam = new SqlParameter("@fromSD", $@"{categoriesSalesParam.From}");
        //var toShippedDateParam = new SqlParameter("@toSD", $@"{categoriesSalesParam.To}");

        //var productSales = await _context
        //    .ProductSales
        //    .FromSqlRaw(SqlStatements.GetCategoriesSales, fromShippedDateParam, toShippedDateParam)
        //    .ToListAsync();

        //var groupByCategory = productSales
        //    .GroupBy(ps => new { ps.CategoryName })
        //    .Select(ps => new 
        //    {
        //     categoryName = ps.Key.CategoryName,
        //     totalSales = ps.Sum(p => p.Sales)
        //    }).ToList();



        //if (productSales == null)
        //{
        //    return NotFound();
        //}

        //return Ok(groupByCategory);
    }
}
