using FINAL_PROJECT.Models;
using FINAL_PROJECT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINAL_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }


        [HttpGet]
        
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeRepository.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetEmployee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var employee = await employeeRepository.GetEmployee(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
       
        public async Task<IActionResult> PostEmployee([FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var EmployeeId = await employeeRepository.PostEmployee(model);
                    if (EmployeeId > 0)
                    {
                        return Ok(EmployeeId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await employeeRepository.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutEmployee([FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepository.PutEmployee(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}
