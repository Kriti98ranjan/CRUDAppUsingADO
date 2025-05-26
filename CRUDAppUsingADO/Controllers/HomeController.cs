using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDAppUsingADO.Models;

namespace CRUDAppUsingADO.Controllers;

public class HomeController : Controller
{
    // get the data access layer class...(readonly means only get the data)
    private readonly EmployeeDataAccessLayer dal;



    //create constructor  initialize the object...
    public HomeController()
    {
        dal = new EmployeeDataAccessLayer();
    }



    // create a action method for get all employees...
    public IActionResult Index()
    {
        List<Employees> emps = dal.getAllEmployees();
        return View(emps);
    }


    
    //create a action method for add/create employees...
    public IActionResult Create()
    {
       
        return View();
    }



    [HttpPost]
    [ValidateAntiForgeryToken] //we use this token for form submission secure....
    public IActionResult Create(Employees emp)
    {
        try
        {
            dal.AddEmployee(emp);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }


    public IActionResult Edit(int Id)
    {
        Employees emp = dal.getEmployeeByID(Id);
        return View(emp);
    }


    [HttpPost]
    [ValidateAntiForgeryToken] 
    public IActionResult Edit(Employees emp)
    {
        try
        {
            dal.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }




    public IActionResult Details(int Id)
    {
        Employees emp = dal.getEmployeeByID(Id);
        return View(emp);
    }



    public IActionResult Delete(int Id)
    {
        Employees emp = dal.getEmployeeByID(Id);
        return View(emp);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Employees emp)
    {
        try
        {
            dal.DeleteEmployee(emp.Id);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
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
