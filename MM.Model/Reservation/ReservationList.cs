using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace MM.Model
{
    [XmlRoot("ReservationList")]
    public class ReservationList
    {
        private ObservableCollection<Reservation> reservations = null;

        [XmlArray("ListOfBookedRooms")]
        [XmlArrayItem("Reservation")]
        public ObservableCollection<Reservation> Reservations { get => reservations; set => reservations = value; }

        public ReservationList()
        {
            reservations = new ObservableCollection<Reservation>();
        }

        public Reservation this[int index]
        {
            get => reservations[index];
        }

        public int Count
        {
            get => reservations.Count;
        }

        public void Add(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public void RemoveAt(int index)
        {
            reservations.RemoveAt(index);
        }

    }
}
