using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MM.Model
{
    /// <summary>
    /// RoomTypeName
    /// </summary>
    public enum RoomTypeName
    {
        Guest,
        Single,
        Double,
        Twin,
        Adjoining,
        Suite,
        King,
        Queen
    }

    /// <summary>
    /// RoomType
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(DoubleRoom))]
    [XmlInclude(typeof(GuestRoom))]
    [XmlInclude(typeof(KingRoom))]
    [XmlInclude(typeof(QueenRoom))]
    [XmlInclude(typeof(SingleRoom))]
    [XmlInclude(typeof(SuiteRoom))]
    public abstract class RoomType
    {
        private int roomTypeID;
        private string roomTypeName;
        private List<Room> rooms;

        /// <summary>
        /// RoomTypeID
        /// </summary>
        public int RoomTypeID { get => roomTypeID; set => roomTypeID = value; }

        /// <summary>
        /// RoomTypeName
        /// </summary>
        public string RoomTypeName { get => roomTypeName; set => roomTypeName = value; }

        /// <summary>
        /// Rooms
        /// </summary>
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        /// <summary>
        /// Laundry
        /// </summary>
        public abstract void Laundry();

        /// <summary>
        /// DryCleaning
        /// </summary>
        public abstract void DryCleaning();

        /// <summary>
        /// Fitness
        /// </summary>
        public abstract void Fitness();
    }
}
