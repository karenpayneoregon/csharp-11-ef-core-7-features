namespace SwitchExpressions.Classes
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Shipment.State ShipmentStatus { get; set; }
        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}
