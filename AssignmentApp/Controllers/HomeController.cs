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
                Number = 9,
                Topic = "REST & HTTP",
                Question = "In ASP.NET Core Web API, what wrapper type allows action methods to return either a strongly typed domain object or standard HTTP status result helpers (such as Ok() , NotFound() )?",
                Options = "A) Task<IActionResult>\nB) ActionResult<T>\nC) IActionResult\nD) HttpResponseMessage",
                Answer = "B",
                AnswerText = "ActionResult<T>",
                Explanation = "ASP.NET Core provides ActionResult<T> as a hybrid return type wrapper. Because of implicit type conversion operators, an action method can return either an instance of type T (which ASP.NET Core automatically serializes to JSON with a 200 OK) or any ActionResult (such as NotFound(), BadRequest(), or CreatedAtAction()). This provides compile-time type checking and OpenAPI/Swagger schema documentation while retaining HTTP status code flexibility."
            },
            new QuestionAnswer
            {
                Number = 8,
                Topic = "REST & HTTP",
                Question = "Which HTTP verb is safe and idempotent, intended exclusively for retrieving resource data without altering server state?",
                Options = "A) POST[3]\nB) PUT[3]\nC) GET[1][3]\nD) DELETE[3]",
                Answer = "C",
                AnswerText = "GET",
                Explanation = "In HTTP, a method is 'safe' if its semantics are read-only and do not cause state changes on the server. A method is 'idempotent' if making multiple identical requests has the same intended effect as a single request. GET is both safe and idempotent. (PUT and DELETE are idempotent but not safe; POST is neither)."
            },
            new QuestionAnswer
            {
                Number = 7,
                Topic = "Controllers",
                Question = "What is the primary function of the [Route(\"api/[controller]\")] attribute in ASP.NET Core?",
                Options = "A) It connects the controller directly to an Entity Framework database context[2].\nB) It maps incoming URI request paths to the controller class using the class name token[1][2].\nC) It encrypts all incoming JSON payloads[2].\nD) It enables Cross-Origin Resource Sharing (CORS) for external React apps[2].",
                Answer = "B",
                AnswerText = "It maps incoming URI request paths to the controller class using the class name token.",
                Explanation = "In ASP.NET Core attribute routing, [Route(\"api/[controller]\")] defines the base route template for all actions in the controller. The [controller] token is dynamically replaced at startup with the controller's class name minus the 'Controller' suffix (e.g., CoursesController resolves to api/courses)."
            },
            new QuestionAnswer
            {
                Number = 6,
                Topic = "REST & HTTP",
                Question = "Which of the following endpoint URIs follows RESTful resource-oriented naming best practices?",
                Options = "A) GET /api/getAllCourses[3]\nB) GET /api/courses[3]\nC) POST /api/createNewCourseRecord[3]\nD) POST /api/deleteCourseById?id=5[3]",
                Answer = "B",
                AnswerText = "GET /api/courses",
                Explanation = "RESTful API design emphasizes resource-oriented URIs using plural nouns (e.g., /api/courses) to represent entities. HTTP verbs (such as GET, POST, PUT, DELETE) communicate the intended action. Embedding RPC verbs or action names in URIs (such as getAllCourses or createNewCourseRecord) violates RESTful principles."
            },
            new QuestionAnswer
            {
                Number = 5,
                Topic = "Status Codes",
                Question = "When a DELETE request successfully removes a resource from the server and returns no content in the response body, which HTTP status code is standard?",
                Options = "A) 200 OK[3]\nB) 201 Created[3]\nC) 204 No Content[3]\nD) 400 Bad Request[3]",
                Answer = "C",
                AnswerText = "204 No Content",
                Explanation = "HTTP status code 204 No Content indicates that the request has succeeded, but that the client does not need to navigate away from its current page or parse a response body. It is the standard RESTful status code for DELETE operations that complete without returning an entity in the response body."
            },
            new QuestionAnswer
            {
                Number = 4,
                Topic = "Status Codes",
                Question = "Which HTTP status code should an API return after successfully creating a new resource via a POST request, along with a Location header pointing to the new URI?",
                Options = "A) 200 OK[3]\nB) 201 Created[1][3]\nC) 204 No Content[3]\nD) 404 Not Found[3]",
                Answer = "B",
                AnswerText = "201 Created",
                Explanation = "According to HTTP/1.1 and REST conventions, an HTTP POST that results in the successful creation of a new resource should return status code 201 Created. The response must include a Location header containing the URI of the newly created resource (typically returned in ASP.NET Core via CreatedAtAction or CreatedAtRoute)."
            },
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









