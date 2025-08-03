using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpesenApp.Models;
using SpesenApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SpesenEintragController : Controller
{
    private readonly AppDbContext _context;

    public SpesenEintragController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create(int personId)
    {
        var viewModel = new SpesenEintragCreateViewModel
        {
            PersonenId = personId,
            Datum = DateTime.Today,
            Kst1Optionen = GetKst1Options()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SpesenEintragCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = new SpesenEintrag
        {
            PersonenId = model.PersonenId,
            Datum = model.Datum,
            Beschreibung = model.Beschreibung,
            Kst1 = model.Kst1,
            Kst2 = model.Kst2 ?? 0,
            Verpflegung = model.Verpflegung,
            Reisekosten = model.Reisekosten,
            KmAuto = model.KmAuto,
            ReisespesenAuto = model.KmAuto * 0.7m,
            Kursmaterial = model.Kursmaterial,
            AndereKosten = model.AndereKosten
        };

        _context.SpesenEintraege.Add(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", new { personId = model.PersonenId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var eintrag = await _context.SpesenEintraege.FindAsync(id);
        if (eintrag == null)
            return NotFound();

        var viewModel = new SpesenEintragCreateViewModel
        {
            PersonenId = eintrag.PersonenId,
            Datum = eintrag.Datum,
            Beschreibung = eintrag.Beschreibung,
            Kst1 = eintrag.Kst1,
            Kst2 = eintrag.Kst2,
            Verpflegung = eintrag.Verpflegung,
            Reisekosten = eintrag.Reisekosten,
            KmAuto = eintrag.KmAuto,
            Kursmaterial = eintrag.Kursmaterial,
            AndereKosten = eintrag.AndereKosten,
            Kst1Optionen = GetKst1Options()
        };

        return View("Create", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SpesenEintragCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var eintrag = await _context.SpesenEintraege.FindAsync(id);
        if (eintrag == null)
            return NotFound();

        eintrag.Datum = model.Datum;
        eintrag.Beschreibung = model.Beschreibung;
        eintrag.Kst1 = model.Kst1;
        eintrag.Kst2 = model.Kst2 ?? 0;
        eintrag.Verpflegung = model.Verpflegung;
        eintrag.Reisekosten = model.Reisekosten;
        eintrag.KmAuto = model.KmAuto;
        eintrag.ReisespesenAuto = model.KmAuto * 0.7m;
        eintrag.Kursmaterial = model.Kursmaterial;
        eintrag.AndereKosten = model.AndereKosten;

        await _context.SaveChangesAsync();
        return RedirectToAction("Index", new { personId = model.PersonenId });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var eintrag = await _context.SpesenEintraege
            .Include(e => e.Person) // Optional, wenn Personendaten gezeigt werden sollen
            .FirstOrDefaultAsync(e => e.Id == id);

        if (eintrag == null)
            return NotFound();

        return View(eintrag);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var eintrag = await _context.SpesenEintraege.FindAsync(id);
        if (eintrag != null)
        {
            _context.SpesenEintraege.Remove(eintrag);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index", new { personId = eintrag?.PersonenId });
    }

    [HttpGet]
    public async Task<IActionResult> Index(int personId)
    {
        var person = await _context.Personen.FindAsync(personId);
        if (person == null)
            return NotFound();

        var eintraege = await _context.SpesenEintraege
            .Where(e => e.PersonenId == personId)
            .ToListAsync();

        ViewBag.Person = person;

        var totalVerpflegung = eintraege.Sum(e => e.Verpflegung);
        var totalReisekosten = eintraege.Sum(e => e.Reisekosten);
        var totalReisespesenAuto = eintraege.Sum(e => e.ReisespesenAuto);
        var totalKursmaterial = eintraege.Sum(e => e.Kursmaterial);
        var totalAndereKosten = eintraege.Sum(e => e.AndereKosten);

        var totalGesamt = eintraege.Sum(e => e.Total);

        ViewBag.TotalVerpflegung = totalVerpflegung;
        ViewBag.TotalReisekosten = totalReisekosten;
        ViewBag.TotalReisespesenAuto = totalReisespesenAuto;
        ViewBag.TotalKursmaterial = totalKursmaterial;
        ViewBag.TotalAndereKosten = totalAndereKosten;
        ViewBag.TotalGesamt = totalGesamt;

        return View(eintraege);
    }

    private List<SelectListItem> GetKst1Options() => new()
    {
        new SelectListItem { Value = "310", Text = "310 - Blockkurse" },
        new SelectListItem { Value = "311", Text = "311 - Tageskurse" },
        new SelectListItem { Value = "312", Text = "312 - Semester -und Jahreskurse" },
        new SelectListItem { Value = "320", Text = "320 - Kreativgruppen" }
    };
}
