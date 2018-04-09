using System;

namespace MM.Model
{
    public class Reservation
    {
        private int numberOfPeople;
        private DateTime checkIn;
        private DateTime checkOut;

        public Reservation() { }

        public Reservation(int numberOfPeople, DateTime checkIn, DateTime checkOut)
        {
            this.numberOfPeople = numberOfPeople;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        public int NumberOfPeople { get => numberOfPeople; set => numberOfPeople = value; }
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }
    }


}
