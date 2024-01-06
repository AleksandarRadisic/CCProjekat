using System;
using System.Collections.Generic;
using System.Linq;
using CentralLibrary.Domain.Model;
using CentralLibrary.Domain.PersistenceInterfaces;
using CentralLibrary.Persistence.EfStructures;
using CentralLibrary.Persistence.Repositories.Base.Implementation;

namespace CentralLibrary.Persistence.Repositories.Implementation
{
    public class MemberReadRepository : BaseReadRepository<Guid, Member>, IMemberReadRepository
    {
        public MemberReadRepository(AppDbContext context) : base(context)
        {
        }

        public Member GetByJmbg(string jmbg)
        {
            return GetSet().FirstOrDefault(m => m.Jmbg == jmbg);
        }

        public int GetCount()
        {
            return GetSet().Count();
        }

        public int GetMemberRentCountByJmbg(string jmbg)
        {
            var query = GetSet().Where(m => m.Jmbg == jmbg);
            if (query.Any()) return query.Select(m => m.CurrentRentals).FirstOrDefault();
            return -1;
        }

        public IEnumerable<Member> GetAll()
        {
            return GetSet().ToList();
        }

        public Member GetByMemberNumber(int dtoMemberNumber)
        {
            return GetSet().FirstOrDefault(m => m.MemberNumber == dtoMemberNumber);
        }
    }
}
