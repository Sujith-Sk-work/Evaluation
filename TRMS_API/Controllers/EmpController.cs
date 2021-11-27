using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;
using TRMS_API.Repository;

namespace TRMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        //Repository injection
        IEmpRepository repo;

        public EmpController(IEmpRepository repo)
        {
            this.repo = repo;
        }

        //Methods
        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            try
            {

                var emp = await repo.GetAllEmp();
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Get an employee
        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmp(int id)
        {
            var emp = await repo.GetEmp(id);
            try
            {
                if (emp == null)
                {
                    return NotFound("No User found");
                }
                return Ok(emp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Add Employee
        [HttpPost]

        public async Task<IActionResult> AddEmp([FromBody] TblEmployee model)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await repo.AddEmp(model);
                    if (id > 0)
                    {
                        return Ok(id);
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

        //Update employee
        [HttpPut]

        public async Task<IActionResult> UpdateUser([FromBody] TblEmployee model)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    await repo.UpdateEmp(model);

                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        //Delete an Employee
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var emp = await repo.DeleteEmp(id);
            try
            {
                if (emp == 0)
                {
                    return NotFound("No User found");
                }
                return Ok(emp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       //AddLoginDetails
       [HttpPost("addLoginDetails")]

        public async Task<IActionResult> AddLogin([FromBody] TblLogin model)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await repo.AddLogin(model);
                    if (id > 0)
                    {
                        return Ok(id);
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
    }
}
