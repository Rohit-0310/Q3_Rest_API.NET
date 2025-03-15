using EmployeeManagement.DTOs;
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

        //Get Request to get all employee
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();

            //Using EmployeeDTO
            var employeeDto = employees.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                Salary = e.Salary
            });

            return Ok(employeeDto);

        }

        //Get Request With Id to get employee with Id 
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee =   _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound(new { message = "Employee not found." });

            //Using EmployeeDTOS
            var employeeDto = new EmployeeDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                Salary = employee.Salary
            };

            return Ok(employeeDto);
        }

        //Post Request to Create Employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                DateOfBirth = employeeDto.DateOfBirth,
                Position = employeeDto.Position,
                Salary = employeeDto.Salary
            };
            var createdEmployee = _employeeService.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, employeeDto);
        }

        //Update Request to Update Employee with Id 
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                DateOfBirth = employeeDto.DateOfBirth,
                Position = employeeDto.Position,
                Salary = employeeDto.Salary
            };

            var updatedEmployee = _employeeService.UpdateEmployee(id, employee);
            if (updatedEmployee == null) 
                return NotFound(new { message = "Employee not found." });

            return Ok(employeeDto);
        }

        //Delete Request to Delete Employee with ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var success = _employeeService.DeleteEmployee(id);
            if (!success) return NotFound(new { message = "Employee not found." });
            return Ok(new { message = "Employee has been deleted successfully." }); ;
        }
    }
}
