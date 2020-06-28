using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        //first thing modification in the form for adding new employee
        //rename the IActionResult method from Create() to AddOrEdit()
        //CONSTRUCTOR OF THE EMPLOYEE CONTROLLER, REMEMBER THE DEPENDENCY INJECTION 
        //INSIDE THE STARTUP, IN THE METHOD CONFIGURE SERVICES,
        //WHERE WE ADDED dBCONTEXT into this ISERVICECOLLECTION whenever we create 
        //an instance of employee controller value for this constructor parameter
        //"context"--employee context object will be passed from this IService collection
        //as the result of this dependency injection
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

       

        // GET: Employee/Create
        public IActionResult AddOrEdit(int id=0)//this method first changed
        {//we have addoredit of the type get request based on the id we know that we know that the button needs to edit
            if(id==0)
                return View(new Employee());//here we have to pass the, if id=0 then do the insert operation
            else
                return View(_context.Employee.Find(id));

            //object for the model
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmployeeId,FullName,EmpCode,Position,OfficeLocation")] Employee employee)
        {//we have the AddOrEdit of the type Post
            if (ModelState.IsValid)
            {
                if(employee.EmployeeId == 0)//if the id is zero then we will do the insert operation otherwise we have to do the update operation
                    _context.Add(employee);
                else
                    _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)//we have the delete of the type get
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            /*if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Remove(employee);
            await _context.SaveChangesAsync();

            return View(employee);*/
        }

       
    }
}
