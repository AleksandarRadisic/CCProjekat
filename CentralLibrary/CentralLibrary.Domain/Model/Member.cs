using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralLibrary.Domain.Model
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Jmbg { get; set; }
        public int MemberNumber { get; set; }
        public int CurrentRentals { get; set; }
    }
}
