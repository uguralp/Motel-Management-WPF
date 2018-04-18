using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace MM.Model
{
    /// <summary>
    /// ReservationList
    /// </summary>
    [XmlRoot("ReservationList")]
    public class ReservationList
    {
        private ObservableCollection<Reservation> reservations = null;

        /// <summary>
        /// Reservations
        /// </summary>
        [XmlArray("ListOfBookedRooms")]
        [XmlArrayItem("Reservation")]
        public ObservableCollection<Reservation> Reservations { get => reservations; set => reservations = value; }

        /// <summary>
        /// ReservationList
        /// </summary>
        public ReservationList()
        {
            reservations = new ObservableCollection<Reservation>();
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Reservation this[int index]
        {
            get => reservations[index];
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get => reservations.Count;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="reservation"></param>
        public void Add(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="reservation"></param>
        public void Remove(Reservation reservation)
        {
            reservations.Remove(reservation);
        }

        /// <summary>
        /// RemoveAt
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            reservations.RemoveAt(index);
        }

    }
}
