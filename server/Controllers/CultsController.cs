using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Instacult_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultsController : ControllerBase
    {
        private readonly CultsService _cultsService;
        private readonly Auth0Provider _a0;
        private readonly CultMembersService _cultsMembersService;

        public CultsController(CultsService cultsService, Auth0Provider a0, CultMembersService cultsMembersService)
        {
            _cultsService = cultsService;
            _a0 = a0;
            _cultsMembersService = cultsMembersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cult>>> GetAllCults()
        {
            try
            {
                Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
                List<Cult> cult = _cultsService.GetAllCults(userInfo?.Id);
                return Ok(cult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{cultId}")]
        public ActionResult<Cult> GetOneCult(int cultId)
        {
            try
            {
                Cult cult = _cultsService.GetOneCult(cultId);
                return Ok(cult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{cultId}/cultMembers")]
        public ActionResult<List<Cultist>> GetCultist(int cultId)
        {
            try
            {
                List<Cultist> cultists = _cultsMembersService.GetCultist(cultId);
                return Ok(cultists);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cult>> CreateCult([FromBody] Cult cultData)
        {
            try
            {
                Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
                cultData.LeaderId = userInfo.Id;
                Cult cult = _cultsService.CreateCult(cultData);
                return Ok(cult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}