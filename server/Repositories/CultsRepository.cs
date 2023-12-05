using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instacult_v2.Repositories
{
    public class CultsRepository
    {
        private readonly IDbConnection _db;

        public CultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Cult CreateCult(Cult cultData)
        {
            string sql = @"
            INSERT INTO 
            cults(description, name, coverImg, leaderId, fee, invitationRequired)
            VALUES(@Description, @Name, @CoverImg, @LeaderId, @Fee, @InvitationRequired);

            SELECT
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON accounts.id = cults.leaderId
            WHERE cults.id = LAST_INSERT_ID()
            ;";
            Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
            {
                cult.Leader = profile;
                return cult;
            }, cultData).FirstOrDefault();
            return cult;
        }

        internal List<Cult> GetAllCults()
        {
            string sql = @"
            SELECT
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON accounts.id = cults.leaderId
            ;";
            List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
            {
                cult.Leader = profile;
                return cult;
            }).ToList();
            return cults;
        }

        internal Cult GetOneCult(int cultId)
        {
            string sql = @"
            SELECT
            cults.*,
            accounts.*
            FROM cults
            JOIN accounts ON accounts.id = cults.leaderId
            WHERE cults.id = @cultId
            ;";
            Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
            {
                cult.Leader = profile;
                return cult;
            }, new { cultId }).FirstOrDefault();
            return cult;
        }

        internal void UpdateCultMemberCount(Cult cult)
        {
            string sql = @"
            UPDATE cults
            SET
            name = @name,
            coverImg = @coverImg,
            fee = @fee,
            description = @description,
            memberCount = @memberCount,
            invitationRequired = @invitationRequired
            WHERE id = @id
            ;";
            _db.Execute(sql, cult);
        }
    }
}