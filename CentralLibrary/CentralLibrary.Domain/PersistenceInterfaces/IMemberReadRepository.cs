using System;
using System.Collections.Generic;
using CentralLibrary.Domain.Model;
using CentralLibrary.Domain.PersistenceInterfaces.Base;

namespace CentralLibrary.Domain.PersistenceInterfaces
{
    public interface IMemberReadRepository : IBaseReadRepository<Guid, Member>
    {
        public Member GetByJmbg(string jmbg);
        public int GetCount();
        public int GetMemberRentCountByJmbg(string jmbg);
        public IEnumerable<Member> GetAll();
        Member GetByMemberNumber(int dtoMemberNumber);
    }
}
