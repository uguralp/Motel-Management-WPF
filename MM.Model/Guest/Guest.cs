
namespace MM.Model
{
    public class Guest
    {
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
