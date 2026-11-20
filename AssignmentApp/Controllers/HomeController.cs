using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AssignmentApp.Models;

namespace AssignmentApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var questions = new List<QuestionAnswer>
        {
            new QuestionAnswer
            {
                Number = 1,
                Topic = "Architecture",
                Question = "What is the fundamental difference between Server-Side Rendering (SSR/MVC) and a Decoupled Web API architecture?",
                Options = "A) SSR returns JSON payloads, whereas a Web API compiles .cshtml Razor views on the server[1].\nB) SSR compiles HTML views on the server and sends fully rendered markup to the browser, whereas a Web API acts as a stateless data provider returning raw JSON[1].\nC) SSR only works with mobile applications, whereas Web APIs are restricted to desktop web browsers[1].\nD) SSR requires client-side routing in React, whereas Web APIs manage HTML layouts directly on the server[1].",
                Answer = "B",
                AnswerText = "SSR compiles HTML views on the server and sends fully rendered markup to the browser, whereas a Web API acts as a stateless data provider returning raw JSON.",
                Explanation = "Server-Side Rendering (SSR) in traditional ASP.NET Core MVC processes and evaluates Razor templates (.cshtml) on the web server, returning complete HTML pages ready for display. A Decoupled Web API architecture, conversely, separates presentation from data: the server acts purely as a stateless provider returning raw structured data (typically JSON), while client-side applications (such as React, Vue, or mobile apps) handle routing and UI rendering."
            },
        };
        return View(questions);
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

