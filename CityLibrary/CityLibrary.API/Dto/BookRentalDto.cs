namespace CityLibrary.API.Dto
{
    public class BookRentalDto
    {
        public string Title { get; set; }
        public string Writer { get; set; }
        public string ISBN { get; set; }
        public int MemberNumber { get; set; }
    }
}
