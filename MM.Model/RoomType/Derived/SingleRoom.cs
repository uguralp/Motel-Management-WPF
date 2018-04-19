using System.Collections.Generic;

namespace MM.Model
{
    /// <summary>
    /// SingleRoom
    /// </summary>
    public class SingleRoom : RoomType
    {
        /// <summary>
        /// SingleRoom
        /// </summary>
        public SingleRoom()
        {
            this.Rooms = new List<Room>();
        }

        public SingleRoom(string roomTypeName, List<Room> listRoom)
        {
            this.RoomTypeName = roomTypeName;
            this.Rooms = listRoom;
            this.Price = 50.0m;
        }

        /// <summary>
        /// ExtraService
        /// </summary>
        public override string ExtraService()
        {
            return "ExtraService for Single Room";
        }

        public override decimal GetPrice()
        {
            return 50.0m;
        }
    }
}
