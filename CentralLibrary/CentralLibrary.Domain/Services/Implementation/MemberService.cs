using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralLibrary.Domain.EnvironmentConfig;
using CentralLibrary.Domain.Exceptions;
using CentralLibrary.Domain.Model;
using CentralLibrary.Domain.PersistenceInterfaces;
using CentralLibrary.Domain.Services.Interface;

namespace CentralLibrary.Domain.Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly IEnvironmentConfig _environmentConfig;
        private readonly IMemberWriteRepository _memberWriteRepository;
        private readonly IMemberReadRepository _memberReadRepository;
        public MemberService(IEnvironmentConfig environmentConfig, IMemberReadRepository memberReadRepository, IMemberWriteRepository memberWriteRepository)
        {
            _environmentConfig = environmentConfig;
            _memberReadRepository = memberReadRepository;
            _memberWriteRepository = memberWriteRepository;
        }


        public int RegisterMember(Member newMember)
        {
            int test = _memberReadRepository.GetMemberRentCountByJmbg("1234567891033");
            Member fromDatabase = _memberReadRepository.GetByJmbg(newMember.Jmbg);
            if (fromDatabase != null) throw new RentalNumberException("Member with given jmbg already exists");
            newMember.CurrentRentals = 0;
            newMember.MemberNumber = _memberReadRepository.GetCount() + 1;
            _memberWriteRepository.Add(newMember);
            return newMember.MemberNumber;
        }

        public IEnumerable<Member> GetAll()
        {
            return _memberReadRepository.GetAll().ToList();
        }

        public void AddRent(int memberNUmber)
        {
            Member member = _memberReadRepository.GetByMemberNumber(memberNUmber);
            if (member == null) throw new NotFoundException("Member not found");
            if (member.CurrentRentals > 2) throw new RentalNumberException("Member already has 3 rentals");
            member.CurrentRentals++;
            _memberWriteRepository.Update(member);
        }

        public void ReturnRented(int memberNumber)
        {
            Member member = _memberReadRepository.GetByMemberNumber(memberNumber);
            if (member == null) throw new NotFoundException("Member not found");
            if (member.CurrentRentals < 1) throw new RentalNumberException("Member has no rented books");
            member.CurrentRentals--;
            _memberWriteRepository.Update(member);
        }
    }
}
