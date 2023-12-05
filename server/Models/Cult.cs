using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace Instacult_v2.Models
{
    public class Cult : RepoItem<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImg { get; set; }
        public int MemberCount { get; set; }
        public int Fee { get; set; }
        public Boolean InvitationRequired { get; set; }
        public string LeaderId { get; set; }
        public Profile Leader { get; set; }
    }
}