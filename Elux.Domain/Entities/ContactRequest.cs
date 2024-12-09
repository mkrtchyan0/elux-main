namespace Elux.Domain.Entities
{
    public class ContactRequest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string YourMessage { get; set; }
        public bool IsRead { get; set; }
    }
}
