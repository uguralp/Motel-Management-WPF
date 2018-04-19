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
            this.Price = 35.0m;
        }

        /// <summary>
        /// ExtraService
        /// </summary>
        public override string ExtraService()
        {
            return "ExtraService for Guest Room";
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Service() + "," + ExtraService();
        }
    }
}
