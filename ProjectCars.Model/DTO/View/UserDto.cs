namespace ProjectCars.Model.DTO.View
{
    public class UserDto : BaseViewDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}