using CentralLibrary.Domain.Model;
using CentralLibrary.Domain.PersistenceInterfaces;
using CentralLibrary.Persistence.EfStructures;
using CentralLibrary.Persistence.Repositories.Base.Implementation;

namespace CentralLibrary.Persistence.Repositories.Implementation
{
    public class MemberWriteRepository : BaseWriteRepository<Member>, IMemberWriteRepository
    {
        public MemberWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
