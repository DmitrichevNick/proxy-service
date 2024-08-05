using Microsoft.AspNetCore.Mvc;
using ProxyService.Application.DTOs;
using ProxyService.Application.Services;
using Task = ProxyService.Domain.Entities.Task;

namespace ProxyService.Web.Controllers{
    public class HelloWorldController : Controller 
    { 
        // 
        // GET: /HelloWorld/ 
 
        public string Index() 
        { 
            return "This is my <b>default</b> action..."; 
        } 
 
        // 
        // GET: /HelloWorld/Welcome/ 
 
        public string Welcome() 
        { 
            return "This is the Welcome action method..."; 
        } 
    } 
}
