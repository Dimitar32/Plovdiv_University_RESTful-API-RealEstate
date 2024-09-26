namespace RealEstateManagmentSystem.Models
{
    public class Tenant
    {
        public Tenant() { }
        public Tenant(string name, string phone, string email) 
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
