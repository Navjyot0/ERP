namespace WebAPI_JWT_Auth_Angular.Models.DTO
{
    public class UserDTO
    {
        public UserDTO(string fullName, string email, string userName, DateTime dateCreated)
        {
            this.FullName = fullName;
            this.Email = email;
            this.UserName = userName;
            this.DateCreated = dateCreated;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Token { get; set; }
    }
}
