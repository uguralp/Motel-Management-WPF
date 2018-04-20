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

        /// <summary>
        /// ExtraService
        /// </summary>
        public override string ExtraService()
        {
            return ", Lunch, Laundry";
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
