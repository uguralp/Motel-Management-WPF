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
        Suite
    }

    /// <summary>
    /// RoomType
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(DoubleRoom))]
    [XmlInclude(typeof(GuestRoom))]
    [XmlInclude(typeof(SingleRoom))]
    [XmlInclude(typeof(SuiteRoom))]
    public abstract class RoomType
    {
        private string roomTypeName;
        private decimal price;
        private List<Room> rooms;

        /// <summary>
        /// RoomTypeName
        /// </summary>
        public string RoomTypeName { get => roomTypeName; set => roomTypeName = value; }

        /// <summary>
        /// Rooms
        /// </summary>
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get => price; set => price = value; }

        public abstract decimal GetPrice();

        /// <summary>
        /// Service
        /// </summary>
        public string Service()
        {
            return "Laundry";
        }

        /// <summary>
        /// ExtraService
        /// </summary>
        public abstract string ExtraService();

    }
}
