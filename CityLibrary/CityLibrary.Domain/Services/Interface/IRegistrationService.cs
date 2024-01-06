using CityLibrary.Domain.Model;

namespace CityLibrary.Domain.Services.Interface
{
    public interface IRegistrationService
    {
        public string RegisterMember(Member newMember);
    }
}
