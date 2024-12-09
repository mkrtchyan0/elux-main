using Elux.Domain.Entities;

namespace Elux.Domain.Responses.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public static UserResponse Convert(ApplicationUser user)
        {
            return new UserResponse()
            {
                Id = user.Id,
                UserName = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsDeleted = user.IsDeleted,
            };
        }
    }
}
