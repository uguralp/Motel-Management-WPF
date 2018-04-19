using System.Collections.Generic;

namespace MM.Model
{
    /// <summary>
    /// SuiteRoom
    /// </summary>
    public class SuiteRoom : RoomType
    {
        /// <summary>
        /// SuiteRoom
        /// </summary>
        public SuiteRoom()
        {
            this.Rooms = new List<Room>();
            this.Price = 70.0m;
        }

        public SuiteRoom(string roomTypeName, List<Room> listRoom)
        {
            this.RoomTypeName = roomTypeName;
            this.Rooms = listRoom;
            this.Price = 70.0m;
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
