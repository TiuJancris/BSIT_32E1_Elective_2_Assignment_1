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
                Number = 3,
                Topic = "Validation",
                Question = "Which framework attribute automatically triggers an HTTP 400 Bad Request response when incoming request payloads fail structural model validation?",
                Options = "A) [Route][2]\nB) [HttpGet][3]\nC) [ApiController][1][2]\nD) [FromQuery][2]",
                Answer = "C",
                AnswerText = "[ApiController]",
                Explanation = "Applying the [ApiController] attribute to a controller class activates built-in API behaviors in ASP.NET Core. One of its primary benefits is automatic HTTP 400 Bad Request responses (formatted using ProblemDetails) whenever model validation fails (ModelState.IsValid == false), eliminating boilerplate validation checks in action methods."
            },
            new QuestionAnswer
            {
                Number = 2,
                Topic = "Controllers",
                Question = "Why do Web API controllers in ASP.NET Core inherit from ControllerBase instead of Controller ?",
                Options = "A) ControllerBase supports Razor View rendering using View() and ViewData[2].\nB) ControllerBase provides essential HTTP handling and routing without carrying unnecessary HTML view rendering overhead[1][2].\nC) Controller is obsolete in .NET 8 and cannot handle HTTP POST requests[1].\nD) ControllerBase automatically creates SQLite database files on application startup[2].",
                Answer = "B",
                AnswerText = "ControllerBase provides essential HTTP handling and routing without carrying unnecessary HTML view rendering overhead.",
                Explanation = "In ASP.NET Core, the Controller class inherits from ControllerBase and adds view engine support (such as View(), PartialView(), ViewData, and ViewBag). Because a Web API is decoupled and returns serialized data (JSON/XML) rather than HTML views, Web API controllers inherit directly from ControllerBase to avoid the overhead of the Razor view rendering pipeline."
            },
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



