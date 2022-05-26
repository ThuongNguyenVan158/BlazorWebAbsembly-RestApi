using WebApp.Model.Dtos;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICRUDEmployeeService employeeService;
        public EmployeeController(ICRUDEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            try
            {
                var listEmployee = await employeeService.GetAsync();


                if (listEmployee == null)
                {
                    return NoContent();
                }
                else
                {

                    return Ok(listEmployee);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(Guid id)
        {
            try
            {
                var employee = await employeeService.GetAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Post([FromBody] EmployeeDto employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }
                await employeeService.CreateAsync(employee);

                return CreatedAtAction("Get", new { id = employee.Id }, employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EmployeeDto employee)
        {
            if(id!= employee.Id || employee == null)
            {
                return BadRequest();
            }
            try
            {
                var item = await employeeService.GetAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                await employeeService.UpdateAsync(id,employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var item = await employeeService.GetAsync(id);
                if(item == null)
                {
                    return NotFound();
                }
                await employeeService.RemoveAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
