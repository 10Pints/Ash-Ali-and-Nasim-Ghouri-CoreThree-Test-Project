using CoreThree.Models;
using CoreThree.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreThree.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class TicketController : Controller
   {
      private readonly TicketsService _ticketService;

      public TicketController(TicketsService TicketsService) =>
          _ticketService = TicketsService;

      [HttpGet]
      public async Task<List<Ticket>> Get() =>  await _ticketService.GetAsync();

      [HttpGet("{id:length(24)}")]
      public async Task<ActionResult<Ticket>> Get(string id)
      {
         var Ticket = await _ticketService.GetAsync(id);

         if (Ticket is null)
            return NotFound();

         return Ticket;
      }

      [HttpPost]
      public async Task<IActionResult> Post(Ticket newBook)
      {
         await _ticketService.CreateAsync(newBook);
         return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
      }

      [HttpPut("{id:length(24)}")]
      public async Task<IActionResult> Update(string id, Ticket updatedBook)
      {
         var Ticket = await _ticketService.GetAsync(id);

         if (Ticket is null)
            return NotFound();

         updatedBook.Id = Ticket.Id;
         await _ticketService.UpdateAsync(id, updatedBook);
         return NoContent();
      }

      [HttpDelete("{id:length(24)}")]
      public async Task<IActionResult> Delete(string id)
      {
         var Ticket = await _ticketService.GetAsync(id);

         if (Ticket is null)
            return NotFound();

         await _ticketService.RemoveAsync(id);

         return NoContent();
      }
   }
}