using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDbContext mVCDbContext;

        public EmployeesController(MVCDbContext mVCDbContext)
        {
            this.mVCDbContext = mVCDbContext;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var employees = await mVCDbContext.Employees.ToListAsync();
            return View(employees);
        }
        
        
        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Phone = addEmployeeRequest.Phone,
                Department = addEmployeeRequest.Department,
                DateofBirth = addEmployeeRequest.DateofBirth,
            };

           await  mVCDbContext.Employees.AddAsync(employee);
           await  mVCDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await mVCDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = employee.Department,
                    DateofBirth = employee.DateofBirth,
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index"); 
                
         }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel Model)
        {
            var employee = await mVCDbContext.Employees.FindAsync(Model.Id);
            if (employee != null)
            {
                employee.Name = Model.Name;
                employee.Email = Model.Email;
                employee.Phone = Model.Phone;
                employee.DateofBirth = Model.DateofBirth;
                employee.Department = Model.Department;

              await  mVCDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee =await mVCDbContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                mVCDbContext.Employees.Remove(employee);
                await mVCDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
