
namespace MM.Model
{
    /// <summary>
    /// Guest
    /// </summary>
    public class Guest
    {
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;

        /// <summary>
        /// Constructor
        /// </summary>
        public Guest() { }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get => lastName; set => lastName = value; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get => address; set => address = value; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
