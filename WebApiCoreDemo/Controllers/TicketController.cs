using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreDemo.Data;
using WebApiCoreDemo.Model;
using WebApiCoreDemo.Repositories;

namespace WebApiCoreDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        //private ApplicationDbContext _context;
        public IRepository<TicketItem> _repository;
        public IUnitOfWork _unitOfWork;

        public TicketController(
            //ApplicationDbContext context,
            IRepository<TicketItem> repository,
            IUnitOfWork unitOfWork
            )
        {
            //_context = context;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<TicketItem> GetAll()
        {
            var tickets = _repository.GetAll();
            return tickets;
            //return _context.TicketItems.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult GetById(long id)
        {
            var ticket = _repository.Get(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return new ObjectResult(ticket);
        }

        [HttpPost]
        public IActionResult Create([FromBody]TicketItem ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            _repository.Add(ticket);
            _unitOfWork.SaveChanges();
            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TicketItem ticket)
        {
            if (ticket == null || ticket.Id != id)
            {
                return BadRequest();
            }

            var tic = _repository.Get(id);
            if (tic == null)
            {
                return NotFound();
            }

            tic.Concert = ticket.Concert;
            tic.Artist = ticket.Artist;
            tic.Available = ticket.Available;

            _repository.Update(tic);
            _unitOfWork.SaveChanges();

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //var tic = _context.TicketItems.FirstOrDefault(t => t.Id == id);
            var entity = _repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            _repository.Remove(entity);
            _unitOfWork.SaveChanges();

            return new NoContentResult();
        }
    }
}