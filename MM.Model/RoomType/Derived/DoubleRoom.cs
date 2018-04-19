using System.Collections.Generic;

namespace MM.Model
{
    /// <summary>
    /// DoubleRoom
    /// </summary>
    public class DoubleRoom : RoomType
    {
        /// <summary>
        /// DoubleRoom
        /// </summary>
        public DoubleRoom()
        {
            this.Rooms = new List<Room>();
            this.Price = 60.0m;
        }

        public DoubleRoom(string roomTypeName, List<Room> listRoom)
        {
            this.RoomTypeName = roomTypeName;
            this.Rooms = listRoom;
            this.Price = 60.0m;
        }

        /// <summary>
        /// ExtraService
        /// </summary>
        public override string ExtraService()
        {
            return "ExtraService for Double Room";
        }

        public override string ToString()
        {
            return this.Service() + "," + ExtraService();
        }

    }
}
