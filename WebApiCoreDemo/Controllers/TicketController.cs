using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreDemo.Model;
using WebApiCoreDemo.Repositories;

namespace WebApiCoreDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {

        public IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public TicketController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {            
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet]
        public IEnumerable<TicketItemViewModel> GetAll()
        {
            var tickets = _unitOfWork.GetRepository<TicketItem>().GetAll();
            var mapperTtem = _mapper.Map<List<TicketItemViewModel>>(tickets);
            return mapperTtem;
            //return _context.TicketItems.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult GetById(long id)
        {
            var ticket = _unitOfWork.GetRepository<TicketItem>().Get(id);
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
            _unitOfWork.GetRepository<TicketItem>().Add(ticket);
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

            var tic = _unitOfWork.GetRepository<TicketItem>().Get(id);
            if (tic == null)
            {
                return NotFound();
            }

            tic.Concert = ticket.Concert;
            tic.Artist = ticket.Artist;
            tic.Available = ticket.Available;

            _unitOfWork.GetRepository<TicketItem>().Update(tic);
            _unitOfWork.SaveChanges();

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var entity = _unitOfWork.GetRepository<TicketItem>().Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            _unitOfWork.GetRepository<TicketItem>().Remove(entity);
            _unitOfWork.SaveChanges();

            return new NoContentResult();
        }
    }
}