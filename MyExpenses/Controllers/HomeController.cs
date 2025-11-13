using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyExpenses.Models;

namespace MyExpenses.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExpensesDbContext _context;

    public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Expenses()
    {
        var allExpenses = _context.Expenses.ToList();
        return View(allExpenses);
    }
    public IActionResult CreateEditExpenses()
    {
        return View();
    }
    public IActionResult CreateEditExpensesForm(Expense model)  //for the data sumbition
    {
        _context.Expenses.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Expenses");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
