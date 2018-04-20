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
            this.Price = 50.0m;
        }

        /// <summary>
        /// ExtraService
        /// </summary>
        public override string ExtraService()
        {
            return ", Lunch";
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Service() + ExtraService();
        }
    }
}
