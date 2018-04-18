using System;
using System.Collections.Generic;

namespace MM.Model
{
    /// <summary>
    /// KingRoom
    /// </summary>
    public class KingRoom : RoomType
    {
        /// <summary>
        /// KingRoom
        /// </summary>
        public KingRoom()
        {
            this.Rooms = new List<Room>();
        }

        /// <summary>
        /// DryCleaning
        /// </summary>
        public override void DryCleaning()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fitness
        /// </summary>
        public override void Fitness()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Laundry
        /// </summary>
        public override void Laundry()
        {
            throw new NotImplementedException();
        }

    }
}
