using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrerySystem.Models;
using LibrerySystem.DTOs;
using AutoMapper;

namespace LibrerySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LoansController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Loans
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans(int id)
        {
            return await _context.Loans.Where(x => x.UserId == id).ToListAsync();
        }

        // GET: api/Loans/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Loan>> GetLoan(int id)
        //{
        //    var loan = await _context.Loans.Where(x => x.UserId == id).ToListAsync(); ;

        //    if (loan == null)
        //    {
        //        return NotFound();
        //    }

        //    return loan;
        //}

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loan)
        {
            if (id != loan.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
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

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(CreateLoanDTO loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            //setup init date for the loan obj
            loan.IsReturned = false;
            loan.LoanDate = DateTime.Now;
            loan.ReturnDate = null;

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.LoanId }, loan);
        }
        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("returnbook{id}")]
        public async Task<ActionResult<Loan>> ReturnBook(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound("Bok Is not there");
            }
            loan.ReturnDate = DateTime.Now;
            loan.IsReturned = true;
            await _context.SaveChangesAsync();

            return Ok("Book has been returned");
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }
    }
}
