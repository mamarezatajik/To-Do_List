using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using To_Do_website.Models;
using To_Do_Project;
using To_Do_ApiCli.Client;
using To_Do_ApiCli.Api;
using To_Do_website;

namespace To_Do_websiteControllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var todoListViewModel = GetAllTodos();
        return View(todoListViewModel);
    }

    internal To_Do_ViewModels GetAllTodos()
    {
        List<To_Do_ApiCli.Model.ToDo> todoList = new List<To_Do_ApiCli.Model.ToDo>();
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);
        var res = apiInstance.ToDoGet().ToList();
        return new To_Do_ViewModels
        {
            TodoList = res
        };
    }


    public RedirectResult Deleting(To_Do todo)
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);
        apiInstance.ToDoIdDelete(todo.TitleId);
        return Redirect("http://localhost:5172/");
    }
    public RedirectResult Adding(To_Do todo)
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);
        var x = new To_Do_ApiCli.Model.ToDo(todo.Date, todo.Plan, todo.TitleId);
        apiInstance.ToDoPost(x);    
        return Redirect("http://localhost:5172/");
    }
}