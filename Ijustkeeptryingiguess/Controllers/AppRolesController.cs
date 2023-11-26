// Bruker nødvendige Microsoft-namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// Kontrolleren krever at brukere må ha rollen "Admin" for å få tilgang
[Authorize(Roles = "Admin")]
public class AppRolesController : Controller
{
    // En instans av RoleManager for å administrere roller
    private readonly RoleManager<IdentityRole> _roleManager;

    // Konstruktør som injiserer RoleManager via Dependency Injection
    public AppRolesController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    // Metode for å vise alle roller opprettet av brukere
    public IActionResult Index()
    {
        // Henter alle roller og sender dem til visningen
        var roles = _roleManager.Roles;
        return View(roles);
    }

    // HTTP GET-metode for å vise skjemaet for å opprette en ny rolle
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // HTTP POST-metode for å opprette en ny rolle
    [HttpPost]
    public async Task<IActionResult> Create(IdentityRole model)
    {
        // Unngå å opprette duplikatrolle
        if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
        {
            // Opprett en ny rolle asynkront og vent på resultatet
            _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
        }

        // Omdiriger til rolleindeks etter opprettelse
        return RedirectToAction("Index");
    }
}

