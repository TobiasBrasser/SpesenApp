 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpesenApp.Models;

public class PersonenController : Controller
{
    private readonly AppDbContext _context;

    public PersonenController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var personen = await _context.Personen.ToListAsync();
        return View(personen);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("Create", new Person()); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Person person)
    {
        if (!ModelState.IsValid)
            return View("Create", person);

        _context.Personen.Add(person);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var person = await _context.Personen.FindAsync(id);
        if (person == null) return NotFound();

        return View("Create", person);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Person person)
    {
        if (id != person.Id) return NotFound();

        if (!ModelState.IsValid)
            return View("Create", person);

        _context.Update(person);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var person = await _context.Personen.FindAsync(id);
        if (person == null) return NotFound();

        return View(person);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var person = await _context.Personen.FindAsync(id);
        if (person != null)
            _context.Personen.Remove(person);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
