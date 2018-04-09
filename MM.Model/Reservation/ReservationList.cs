using System.Collections.ObjectModel;

namespace MM.Model
{
    public class ReservationList
    {
        ObservableCollection<Reservation> reservations = null;

        public ReservationList()
        {
            reservations = new ObservableCollection<Reservation>();
        }

        public Reservation this[int i]
        {
            get => reservations[i];
        }

        public int Count
        {
            get => reservations.Count;
        }

        public void Add(Reservation a)
        {
            reservations.Add(a);
        }

    }
}
