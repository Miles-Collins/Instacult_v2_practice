using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult_v2.Services
{
    public class CultsService
    {
        private readonly CultsRepository _cultsRepo;

        public CultsService(CultsRepository cultsRepo)
        {
            _cultsRepo = cultsRepo;
        }

        internal Cult CreateCult(Cult cultData)
        {
            Cult cult = _cultsRepo.CreateCult(cultData);
            return cult;
        }

        internal List<Cult> GetAllCults(string userId)
        {
            List<Cult> cults = _cultsRepo.GetAllCults();
            List<Cult> filtered = cults.FindAll(cult => cult.InvitationRequired == false || cult.LeaderId == userId);
            return filtered;
        }

        internal Cult GetOneCult(int cultId)
        {
            Cult cult = _cultsRepo.GetOneCult(cultId) ?? throw new Exception($"No Cult at [ID] {cultId}");
            return cult;
        }

        internal void UpdateCultMemberCount(Cult cult)
        {
            _cultsRepo.UpdateCultMemberCount(cult);
        }
    }
}