namespace Core.Domain.Models
{
    public class JobApplicant : IJobApplicant
    {
        public string Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
