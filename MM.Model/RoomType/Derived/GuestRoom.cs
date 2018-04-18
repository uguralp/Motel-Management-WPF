using System.Collections.Generic;

namespace MM.Model
{
    /// <summary>
    /// GuestRoom
    /// </summary>
    public class GuestRoom : RoomType
    {
        /// <summary>
        /// GuestRoom
        /// </summary>
        public GuestRoom()
        {
            this.Rooms = new List<Room>();
        }

        public GuestRoom(string roomTypeName, List<Room> listRoom)
        {
            this.RoomTypeName = roomTypeName;
            this.Rooms = listRoom;
            this.Price = 35.0m;
        }

        /// <summary>
        /// ExtraService
        /// </summary>
        public override string ExtraService()
        {
            return "ExtraService for Double Room";
        }

        public override decimal GetPrice()
        {
            return 35.0m;
        }
    }
}
