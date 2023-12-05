using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult_v2.Models
{
    public class Cultist : Profile
    {
        public int CultMemberId { get; set; }
        public int CultId { get; set; }
    }
}