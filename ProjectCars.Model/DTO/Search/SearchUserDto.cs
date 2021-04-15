namespace ProjectCars.Model.DTO.Search
{
    public class SearchUserDto : BaseSearch
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "lastName-asc";
    }
}