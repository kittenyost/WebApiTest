﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Data;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly WebApiTestContext _context;

        public ContentsController(WebApiTestContext context)
        {
            _context = context;
        }

        // GET: api/Contents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Content>>> GetContent()
        {
            return await _context.Content.ToListAsync();
        }

        // GET: api/Contents/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Content>> GetContent(int id)
        {
            var content = await _context.Content.FindAsync(id);

            if (content == null)
            {
                return NotFound();
            }

            return content;
        }

        // PUT: api/Contents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles= "Admin")]
        public async Task<IActionResult> PutContent(int id, Content content)
        {
            if (id != content.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
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

        // POST: api/Contents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Content>> PostContent(Content content)
        {
            _context.Content.Add(content);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContent", new { id = content.ContentId }, content);
        }

        // DELETE: api/Contents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            var content = await _context.Content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            _context.Content.Remove(content);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentExists(int id)
        {
            return _context.Content.Any(e => e.ContentId == id);
        }
    }
}
