using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee =   _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound();
            
            return Ok(employee);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            var createdEmployee = _employeeService.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var updatedEmployee = _employeeService.UpdateEmployee(id, employee);
            if (updatedEmployee == null) 
                return NotFound();

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var success = _employeeService.DeleteEmployee(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
