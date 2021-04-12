namespace ProjectCars.Model.DTO.Search
{
    public class SearchRoleDto : BaseSearch
    {
        public string RoleName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "name-asc";
    }
}