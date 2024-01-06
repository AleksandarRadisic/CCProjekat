using System.Collections.Generic;
using CentralLibrary.Domain.Model;

namespace CentralLibrary.Domain.Services.Interface
{
    public interface IMemberService
    {
        public int RegisterMember(Member newMember);
        public IEnumerable<Member> GetAll();
        void AddRent(int memberNUmber);
        void ReturnRented(int memberNumber);
    }
}
