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
    public class RequestController : ControllerBase
    {
        IReqRepository repo;

        //Injecting repository
        public RequestController(IReqRepository repo)
        {
            this.repo = repo;
        }


        //Get Full Request
        [HttpGet]
        public async Task<IActionResult> GetFullReq()
        {
            try
            {
                var req = await repo.GetFullReq();
                if (req != null)
                {
                    return Ok(req);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //get request
        [HttpGet("getreq")]
        public async Task<IActionResult> GetReq()
        {
            try
            {
                var req = await repo.GetReq();
                if (req != null)
                {
                    return Ok(req);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Add Request
        [HttpPost]
        public async Task<IActionResult> AddReq([FromBody] TblRequest model)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await repo.AddReq(model);
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

        //Update Req
        [HttpPut]
        public async Task<IActionResult> UpdateReq([FromBody] TblRequest model)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await repo.UpdateReq(model);
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
