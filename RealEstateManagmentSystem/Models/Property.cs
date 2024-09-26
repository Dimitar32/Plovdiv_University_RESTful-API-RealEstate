namespace RealEstateManagmentSystem.Models
{
    public class Property
    {
        public Property() { }
        public Property(string address, string category, Owner owner, string status)
        {
            Adress = address;
            Category = category;
            Owner = owner;
            Status = status;
        }
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Category { get; set; }
        public Owner Owner { get; set; }
        public string Status { get; set; }
    }
}
