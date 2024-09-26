namespace RealEstateManagmentSystem.Models
{
    public class LeaseAgreement
    {
        public LeaseAgreement() { }
        public LeaseAgreement(Property property, Tenant tenant, DateTime startDate, DateTime endDate, string price) 
        { 
            Property = property;
            Tenant = tenant;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
        }

        public int Id {  get; set; }
        public Property Property { get; set; }
        public Tenant Tenant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Price {  get; set; }
    }
}
