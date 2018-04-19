
namespace MM.Model
{
    /// <summary>
    /// Room
    /// </summary>
    public class Room
    {
        private int roomNumber;
        private bool isCheckedOut;

        /// <summary>
        /// RoomNumber
        /// </summary>
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

        /// <summary>
        /// IsReserved
        /// </summary>
        public bool IsCheckedOut { get => isCheckedOut; set => isCheckedOut = value; }

        /// <summary>
        /// Room
        /// </summary>
        public Room()
        {
            this.isCheckedOut = false;
        }
    }
}
