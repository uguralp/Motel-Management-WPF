using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MM.Model
{
    /// <summary>
    /// Reservation
    /// </summary>
    [Serializable]
    public class Reservation : IDisposable, IDataErrorInfo, INotifyPropertyChanged
    {
        private Guid reservationID;
        private Guest guest;
        private int numberOfAdult;
        private int numberOfChild;
        //private string roomType;
        //private Room room;
        private string checkIn;
        private string checkOut;
        private RoomType roomType;
        private decimal totalPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Reservation
        /// </summary>
        public Reservation()
        {
            reservationID = Guid.NewGuid();
            Guest = new Guest();
        }

        /// <summary>
        /// Reservation
        /// </summary>
        /// <param name="numberOfAdult"></param>
        /// <param name="numberOfChild"></param>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        public Reservation(int numberOfAdult, int numberOfChild, string checkIn, string checkOut)
        {
            this.numberOfAdult = numberOfAdult;
            this.numberOfChild = numberOfChild;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        /// <summary>
        /// ReservationID
        /// </summary>
        public Guid ReservationID { get => reservationID; set => reservationID = value; }

        /// <summary>
        /// NumberOfAdult
        /// </summary>
        public int NumberOfAdult { get => numberOfAdult; set => numberOfAdult = value; }

        /// <summary>
        /// NumberOfChild
        /// </summary>
        public int NumberOfChild { get => numberOfChild; set => numberOfChild = value; }

        /// <summary>
        /// CheckIn
        /// </summary>
        public string CheckIn
        {
            get
            {
                return checkIn;
            }
            set
            {
                checkIn = value;
                NotifyPropertyChanged("CheckIn");
                NotifyPropertyChanged("CheckOut");
            }            
        }

        /// <summary>
        /// CheckOut
        /// </summary>
        public string CheckOut
        {
            get
            {
                return checkOut;
            }
            set
            {
                checkOut = value;
                NotifyPropertyChanged("CheckIn");
                NotifyPropertyChanged("CheckOut");
            }
        }

        /// <summary>
        /// Guest
        /// </summary>
        public Guest Guest { get => guest; set => guest = value; }

        ///// <summary>
        ///// RoomType
        ///// </summary>
        //public string RoomType { get => roomType; set => roomType = value; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error => throw new NotImplementedException();

        //public Room Room { get => room; set => room = value; }

        public RoomType RoomType { get => roomType; set => roomType = value; }
        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                //if (roomType.Price != null)
                //{
                //    DateTime dateCheckIn = DateTime.Parse(CheckIn);
                //    DateTime dateCheckOut = DateTime.Parse(CheckOut);

                //    totalPrice = roomType.Price * (decimal)(dateCheckOut - dateCheckIn).TotalDays;
                //}
                //else
                //{
                //    totalPrice = 0;
                //}

                totalPrice = value;
            }
        }

        /// <summary>
        /// IsValidCheckInCheckOut
        /// </summary>
        /// <returns></returns>
        private bool IsValidCheckInCheckOut()
        {
            bool compareResult = true;

            if (checkIn != null && checkOut != null)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime checkInValue, checkOutValue;

                checkInValue = DateTime.Parse(checkIn, new CultureInfo("en-CA"));
                checkOutValue = DateTime.Parse(checkOut, new CultureInfo("en-CA"));

                compareResult = checkOutValue >= checkInValue;
            }

            return compareResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "CheckIn" && !IsValidCheckInCheckOut())
                    result = "Check in must be before Check out";
                else if (columnName == "CheckOut" && !IsValidCheckInCheckOut())
                    result = "Check out must be after Check in";



                return result;
            }
        }
    }
}
