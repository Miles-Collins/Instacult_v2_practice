using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult_v2.Services
{
    public class CultMembersService
    {
        private readonly CultMembersRepository _cultMemberRepo;
        private readonly CultsService _cultsService;

        public CultMembersService(CultMembersRepository cultMemberRepo, CultsService cultsService)
        {
            _cultMemberRepo = cultMemberRepo;
            _cultsService = cultsService;
        }

        internal Cultist CreateCultMember(CultMember cultMemberData)
        {
            Cultist cultMember = _cultMemberRepo.CreateCultMember(cultMemberData);
            Cult cult = _cultsService.GetOneCult(cultMember.CultId);

            cult.MemberCount++;
            _cultsService.UpdateCultMemberCount(cult);
            return cultMember;
        }

        internal string LeaveCult(int cultMemberId, string userId)
        {
            CultMember cultMember = this.GetCultMember(cultMemberId);
            Cult cult = _cultsService.GetOneCult(cultMember.CultId);
            if (userId != cult.LeaderId)
            {
                throw new Exception("Stick around a little longer....");
            }
            _cultMemberRepo.LeaveCult(cultMemberId);
            cult.MemberCount--;
            _cultsService.UpdateCultMemberCount(cult);
            return ("They are no longer with us!");
        }

        internal CultMember GetCultMember(int cultMemberId)
        {
            CultMember cultMember = _cultMemberRepo.GetCultMember(cultMemberId) ?? throw new Exception($"Did not find Member at [ID] {cultMemberId}");
            return cultMember;
        }

        internal List<Cultist> GetCultist(int cultId)
        {
            _cultsService.GetOneCult(cultId);
            List<Cultist> cultist = _cultMemberRepo.GetCultist(cultId);
            return cultist;
        }
    }
}