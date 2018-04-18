
namespace MM.Model
{
    /// <summary>
    /// Room
    /// </summary>
    public class Room
    {
        private int roomID;
        private int roomNumber;

        /// <summary>
        /// RoomID
        /// </summary>
        public int RoomID { get => roomID; set => roomID = value; }

        /// <summary>
        /// RoomNumber
        /// </summary>
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

        /// <summary>
        /// Room
        /// </summary>
        public Room() { }

        /// <summary>
        /// Room
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="RoomNumber"></param>
        public Room(int RoomID, int RoomNumber)
        {
            this.RoomID = RoomID;
            this.RoomNumber = RoomNumber;
        }
    }
}
