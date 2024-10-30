using Microsoft.AspNetCore.Mvc;
using UserActivityAPI.Models;
using UserActivityAPI.Services.IServices;

namespace UserActivityAPI.Controllers
{
    [Route("api/Status")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class StatusController : ControllerBase

    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;  
        }

        /// <summary>
        /// Get list of status.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(List<Status>))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public IActionResult GetStatusAll()
        {
            var objList = _statusService.GetAllStatus();   

            return Ok(objList);  
        }

        /// <summary>
        /// Get individual status
        /// </summary>
        /// <param name="statusid"> The is of status </param>
        /// <returns></returns>
        [HttpGet("{statusid:int}", Name = "GetStatus")]
        public IActionResult GetStatus(int statusid)
        {
            var obj  = _statusService.GetStatusById(statusid);
            if (obj == null)
            {
                return NotFound();  
            }
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult CreateStatus([FromBody] Status status)
        {
            if (status == null)
            {
                return BadRequest(ModelState);
            }

            if(_statusService.StatusExists(status.StatusName))
            {
                ModelState.AddModelError("", "Status Exists!");
                return StatusCode(404, ModelState); 
            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (!_statusService.AddStatusAsync(status))
            {
                ModelState.AddModelError("", $"Somthing went wrong when saving the record {status.StatusName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetStatus", new { statusid = status.StatusId} , status);
        }

        [HttpPatch("{statusid:int}", Name = "Updatestatus")]
        public IActionResult Updatestatus(int statusid, [FromBody] Status status)
        {
            if (status == null || statusid != status.StatusId)
            {
                return BadRequest(ModelState);
            }

            if (!_statusService.UpdateStatusAsync(status))
            {
                ModelState.AddModelError("", $"Somthing went wrong when Updating the record {status.StatusName}");
                return StatusCode(500, ModelState);
            }

            return NoContent(); 
        }

        [HttpDelete("{statusid:int}", Name = "DeleteStatus")]
        public IActionResult DeleteStatus(int statusid)
        {
            if (_statusService.StatusExists(statusid))
            {
                return NotFound();
            }

            var statusobj = _statusService.GetStatusById(statusid); 
            if (!_statusService.DeleteStatusAsync(statusobj))
            {
                ModelState.AddModelError("", $"Somthing went wrong when deleting the record {statusobj.StatusName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
