using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        //
        //GET: /HelloWorld/
        //in this the index method returns a string with a message that's hard-coded in the controller class
       /* public string Index()
        {
            return "This is my default action...";
        }*/

        //
        //GET: /HelloWorld/Welcome/

        /*public string Welcome()
        {
            return "This is the Welcome action method...";
        }*/

        //
        //GET: /HelloWorld/Welcome/
        //Requires using System.Text.Encodings.Web;
        //this code passes some parameter information from the URL to the controller
        //eg https://localhost:44305/HelloWorld/Welcome?name=Rick&numtimes=4 the ? here is the separator followed by the query string the & character separates the field-value pairs
        //uses HtmlEncoder.Default.Encode to protect the app from malicious input(namely JavaScript)
        //uses Interpolated Strings in $"Hello {name}, NumTimes is: {numTimes}"
        /*public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }*/


        //https://localhost:44305/HelloWorld/Welcome/3?name=Rick  (Hello Rick,ID is 3)
      /* public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }*/

        //In the above examples the controller have been doing both the view-controller work, the controller
        //the controller is running html directly it will become difficult to maintain the code and is breaking srp 
        //so will use a separate razor view template file to generate the HTML response

        /*
         In this section you modify the HelloWorldController class to use Razor view files to 
        cleanly encapsulate the process of generating HTML responses to a client.
         
         */

        //Modify this controller class to use Razor view files to cleanly encapsulate the process of generating HTML responses to a client
        public IActionResult Index()
        {
            return View();
        }
        //the above code calls the controller's View method

        //changing the Welcome method to add a Message and NumTimes value to the ViewData dictionary.
        //The ViewData dictionary is a dynamic object, which means any  type can be used.
        //The ViewData dictionary object contains data that will be passed to the view.

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
