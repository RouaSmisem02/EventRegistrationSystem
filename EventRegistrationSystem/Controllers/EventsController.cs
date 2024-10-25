using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventsController : Controller
{
    private readonly DBContext _context;

    public EventsController(DBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Events.ToListAsync());
    }

    // Implement Create, Edit, Delete methods here...
}
