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
        private string checkIn;
        private string checkOut;
        private RoomType roomType;
        private decimal totalPrice;
        private string service;
        private int numberOfDay;

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// RaisePropertyChanged
        /// </summary>
        /// <param name="prop"></param>
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        /// <summary>
        /// Reservation
        /// </summary>
        public Reservation()
        {
            NumberOfDay = 0;
            TotalPrice = 0;
            reservationID = Guid.NewGuid();
            Guest = new Guest();
            NumberOfChild = -1;
        }

        /// <summary>
        /// ReservationID
        /// </summary>
        public Guid ReservationID { get => reservationID; set => reservationID = value; }

        /// <summary>
        /// NumberOfAdult
        /// </summary>
        public int NumberOfAdult
        {
            get
            {
                return numberOfAdult;
            }
            set
            {
                numberOfAdult = value;
                RaisePropertyChanged("NumberOfAdult");
            }
        }

        /// <summary>
        /// NumberOfChild
        /// </summary>
        public int NumberOfChild
        {
            get
            {
                return numberOfChild;
            }
            set
            {
                numberOfChild = value;
                RaisePropertyChanged("NumberOfChild");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(numberOfChild)));
            }
        }

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
                RaisePropertyChanged("CheckIn");
                RaisePropertyChanged("CheckOut");
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
                RaisePropertyChanged("CheckIn");
                RaisePropertyChanged("CheckOut");
            }
        }

        /// <summary>
        /// Guest
        /// </summary>
        public Guest Guest { get => guest; set => guest = value; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error => throw new NotImplementedException();

        /// <summary>
        /// RoomType
        /// </summary>
        public RoomType RoomType { get => roomType; set => roomType = value; }

        /// <summary>
        /// TotalPrice
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
            }
        }

        /// <summary>
        /// Service
        /// </summary>
        public string Service { get => service; set => service = value; }

        /// <summary>
        /// NumberOfDay
        /// </summary>
        public int NumberOfDay { get => numberOfDay; set => numberOfDay = value; }

        /// <summary>
        /// CalculateNumberOfDay
        /// </summary>
        public void CalculateNumberOfDay()
        {
            DateTime dateCheckIn = DateTime.Parse(CheckIn);
            DateTime dateCheckOut = DateTime.Parse(CheckOut);
            this.NumberOfDay = (int)(dateCheckOut - dateCheckIn).TotalDays + 1;
        }

        /// <summary>
        /// CalculateTotalPrice
        /// </summary>
        public void CalculateTotalPrice()
        {
            this.TotalPrice = this.NumberOfDay * this.RoomType.Price;
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

        /// <summary>
        /// Dispose
        /// </summary>
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
