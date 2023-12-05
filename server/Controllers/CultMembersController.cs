using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Instacult_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultMembersController : ControllerBase
    {
        private readonly CultMembersService _cultMembersService;

        private readonly Auth0Provider _a0;
        public CultMembersController(CultMembersService cultMembersService, Auth0Provider a0)
        {
            _cultMembersService = cultMembersService;
            _a0 = a0;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cultist>> CreateCultMember([FromBody] CultMember cultMemberData)
        {
            try
            {
                Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
                cultMemberData.AccountId = userInfo.Id;
                Cultist cultMember = _cultMembersService.CreateCultMember(cultMemberData);
                return Ok(cultMember);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{cultMemberId}")]
        [Authorize]
        public async Task<ActionResult<string>> LeaveCult(int cultMemberId)
        {
            try
            {
                Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
                string message = _cultMembersService.LeaveCult(cultMemberId, userInfo.Id);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}