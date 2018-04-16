using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MM.Model;
using MM.Utilities;

namespace MM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region PROPERTIES
        private List<RoomType> roomTypes;
        public List<RoomType> RoomTypes { get => roomTypes; set => roomTypes = value; }

        private ReservationList reservationList;
        public ReservationList ReservationList { get => reservationList; set => reservationList = value; }
        int rowIndex;

        #endregion

        #region CONSTRUCTOR

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

        #region BINDING DATA FOR ALL CONTROLS 

        private void Init()
        {
            // Initialize list of reservations
            ReservationList = new ReservationList();

            // Init data for list of room types and room numbers
            InitRoomType();            

            // Read data from XML
            ReadDataFromXML();

            // Display XML data to grid
            DisplayXMLToGrid();

            // Enable/Disable UPDATE, DELETE, SAVE buttons
            EnableButtonWhenRegister();

            Clear();

            // Set data context
            DataContext = this;

        }

        #endregion

        #region INITIALIZE DATA FOR SCREEN

        private void InitRoomType()
        {
            roomTypes = new List<RoomType>();

            // Create rooms type Guest
            RoomType roomTypeGuest = new GuestRoom();
            roomTypeGuest.RoomTypeID = 1;
            roomTypeGuest.RoomTypeName = RoomTypeName.Guest.ToString();

            roomTypeGuest.Rooms.Add(new Room() { RoomID = 11, RoomNumber = 101 });
            roomTypeGuest.Rooms.Add(new Room() { RoomID = 12, RoomNumber = 102 });
            roomTypeGuest.Rooms.Add(new Room() { RoomID = 13, RoomNumber = 103 });
            roomTypeGuest.Rooms.Add(new Room() { RoomID = 14, RoomNumber = 104 });
            roomTypes.Add(roomTypeGuest);

            // Create rooms type Single
            RoomType roomTypeSingle = new SingleRoom();
            roomTypeSingle.RoomTypeID = 2;
            roomTypeSingle.RoomTypeName = RoomTypeName.Single.ToString();

            roomTypeSingle.Rooms.Add(new Room() { RoomID = 21, RoomNumber = 201 });
            roomTypeSingle.Rooms.Add(new Room() { RoomID = 22, RoomNumber = 202 });
            roomTypeSingle.Rooms.Add(new Room() { RoomID = 23, RoomNumber = 203 });
            roomTypeSingle.Rooms.Add(new Room() { RoomID = 24, RoomNumber = 204 });
            roomTypes.Add(roomTypeSingle);

            // Create rooms type Double
            RoomType roomTypeDouble = new DoubleRoom();
            roomTypeDouble.RoomTypeID = 3;
            roomTypeDouble.RoomTypeName = RoomTypeName.Double.ToString();

            roomTypeDouble.Rooms.Add(new Room() { RoomID = 31, RoomNumber = 301 });
            roomTypeDouble.Rooms.Add(new Room() { RoomID = 32, RoomNumber = 302 });
            roomTypeDouble.Rooms.Add(new Room() { RoomID = 33, RoomNumber = 303 });
            roomTypeDouble.Rooms.Add(new Room() { RoomID = 34, RoomNumber = 304 });
            roomTypes.Add(roomTypeDouble);

            // Create rooms type Suite
            RoomType roomTypeSuite = new SuiteRoom();
            roomTypeSuite.RoomTypeID = 4;
            roomTypeSuite.RoomTypeName = RoomTypeName.Suite.ToString();

            roomTypeSuite.Rooms.Add(new Room() { RoomID = 41, RoomNumber = 401 });
            roomTypeSuite.Rooms.Add(new Room() { RoomID = 42, RoomNumber = 402 });
            roomTypeSuite.Rooms.Add(new Room() { RoomID = 43, RoomNumber = 403 });
            roomTypeSuite.Rooms.Add(new Room() { RoomID = 44, RoomNumber = 404 });
            roomTypes.Add(roomTypeSuite);

            //// Create rooms type King
            //RoomType roomTypeKing = new RoomType();
            //roomTypeKing.RoomTypeID = 5;
            //roomTypeKing.RoomTypeName = RoomTypeName.King;

            //roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "51", RoomNumber = 501 });
            //roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "52", RoomNumber = 502 });
            //roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "53", RoomNumber = 503 });
            //roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "53", RoomNumber = 504 });
            //roomTypes.Add(roomTypeKing);

            //// Create rooms type Queen
            //RoomType roomTypeQueen = new RoomType();
            //roomTypeQueen.RoomTypeID = 6;
            //roomTypeQueen.RoomTypeName = RoomTypeName.Queen;

            //roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "61", RoomNumber = 601 });
            //roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "62", RoomNumber = 602 });
            //roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "63", RoomNumber = 603 });
            //roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "63", RoomNumber = 604 });
            //roomTypes.Add(roomTypeQueen);

        }

        private void Clear()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtNumOfAdult.Text = string.Empty;
            txtNumOfChild.Text = string.Empty;
            cboCheckIn.Text = DateTime.Now.ToShortDateString();
            cboCheckOut.Text = DateTime.Now.ToShortDateString();
            txtFirstName.Focus();
        }
        #endregion

        #region VALIDATION

        private void ForceValidation()
        {
            txtFirstName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtLastName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAddress.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPhoneNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtNumOfAdult.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtNumOfChild.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cboCheckIn.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            cboCheckOut.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
        }

        #endregion

        #region READ/WRITE XML AND DISPLAY TO GRID

        private void ReadDataFromXML()
        {
            Utilities.XMLController.ReadXML(Common.XML_FILE_NAME, ref this.reservationList);
        }

        private void DisplayXMLToGrid()
        {
            if (reservationList != null)
            {
                var query = from reservation in reservationList.Reservations
                            select reservation;

                grdReservation.ItemsSource = query.ToList();
            }
        }

        #endregion

        #region ENABLE/DISABLE BUTTONS

        private void EnableButtonWhenRegister()
        {
            btnRegister.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }

        private void EnableButtonWhenUpdate()
        {
            btnRegister.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;            
        }


        #endregion

        #endregion

        #region EVENTS

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();

            txtFirstName.Focus();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool isInvalid = false;

            ForceValidation();

            isInvalid = Validation.GetHasError(txtFirstName)
                        || Validation.GetHasError(txtLastName)
                        || Validation.GetHasError(txtAddress)
                        || Validation.GetHasError(txtPhoneNumber)
                        || Validation.GetHasError(txtNumOfAdult)
                        || Validation.GetHasError(txtNumOfChild)
                        || Validation.GetHasError(cboCheckIn)
                        || Validation.GetHasError(cboCheckOut)
                ;

            if (!isInvalid)
            {
                Reservation reservation = new Reservation();

                reservation.Guest = new Guest()
                {
                    FirstName = txtFirstName.Text
                                                    ,
                    LastName = txtLastName.Text
                                                    ,
                    Address = txtAddress.Text
                                                    ,
                    PhoneNumber = txtPhoneNumber.Text
                };

                reservation.NumberOfAdult = int.Parse(txtNumOfAdult.Text);
                reservation.NumberOfChild = int.Parse(txtNumOfChild.Text);
                reservation.RoomType = ((RoomType)lstRoomType.SelectedValue).RoomTypeName;
                reservation.RoomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;
                reservation.CheckIn = DateTime.Parse(cboCheckIn.Text);
                reservation.CheckOut = DateTime.Parse(cboCheckOut.Text);

                ReservationList.Add(reservation);
                XMLController.WriteToXML(Common.XML_FILE_NAME, ReservationList);
                grdReservation.ItemsSource = ReservationList.Reservations;

                Clear();
            }

        }

        private void grdReservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButtonWhenUpdate();

            Reservation currentRow = grdReservation.SelectedItem as Reservation;

            var currentRowIndex = grdReservation.Items.IndexOf(grdReservation.CurrentItem);
            rowIndex = currentRowIndex;

            RoomType reservedRoomType = roomTypes.First(r => r.RoomTypeName.ToString().Equals(currentRow.RoomType));
            Room reservedRoom = reservedRoomType.Rooms.First(r => r.RoomNumber == currentRow.RoomNumber);
            
            txtFirstName.Text = currentRow.Guest.FirstName;
            txtLastName.Text = currentRow.Guest.LastName;
            txtAddress.Text = currentRow.Guest.Address;
            txtPhoneNumber.Text = currentRow.Guest.PhoneNumber;
            txtNumOfAdult.Text = currentRow.NumberOfAdult.ToString();
            txtNumOfChild.Text = currentRow.NumberOfChild.ToString();
            lstRoomType.SelectedItem = reservedRoomType;
            cboRoomNumber.SelectedItem = reservedRoom;
            cboCheckIn.Text = currentRow.CheckIn.ToString();
            cboCheckOut.Text = currentRow.CheckOut.ToString();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            EnableButtonWhenRegister();
            Clear();
                
        }


        #endregion

        private void updateClicked(object sender, RoutedEventArgs e)
        {

            bool isInvalid = false;

            ForceValidation();

            isInvalid = Validation.GetHasError(txtFirstName)
                        || Validation.GetHasError(txtLastName)
                        || Validation.GetHasError(txtAddress)
                        || Validation.GetHasError(txtPhoneNumber)
                        || Validation.GetHasError(txtNumOfAdult)
                        || Validation.GetHasError(txtNumOfChild)
                        || Validation.GetHasError(cboCheckIn)
                        || Validation.GetHasError(cboCheckOut)
                ;

            if (!isInvalid)
            {
                reservationList[rowIndex].Guest.FirstName = txtFirstName.Text;
                reservationList[rowIndex].Guest.LastName = txtLastName.Text;
                reservationList[rowIndex].Guest.Address = txtAddress.Text;
                reservationList[rowIndex].Guest.PhoneNumber = txtPhoneNumber.Text;
                reservationList[rowIndex].NumberOfAdult = int.Parse(txtNumOfAdult.Text);
                reservationList[rowIndex].NumberOfChild = int.Parse(txtNumOfChild.Text);
                reservationList[rowIndex].RoomType = ((RoomType)lstRoomType.SelectedValue).RoomTypeName;
                reservationList[rowIndex].RoomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;
                reservationList[rowIndex].CheckIn = DateTime.Parse(cboCheckIn.Text);
                reservationList[rowIndex].CheckOut = DateTime.Parse(cboCheckOut.Text);

                File.Delete("Reservation_List.xml");
                XMLController.WriteToXML(Common.XML_FILE_NAME, ReservationList);
                grdReservation.ItemsSource = ReservationList.Reservations;
                grdReservation.Items.Refresh();
                Clear();
            }

        }

        private void deleteClicked(object sender, RoutedEventArgs e)
        {
            bool isInvalid = false;

            ForceValidation();

            isInvalid = Validation.GetHasError(txtFirstName)
                        || Validation.GetHasError(txtLastName)
                        || Validation.GetHasError(txtAddress)
                        || Validation.GetHasError(txtPhoneNumber)
                        || Validation.GetHasError(txtNumOfAdult)
                        || Validation.GetHasError(txtNumOfChild)
                        || Validation.GetHasError(cboCheckIn)
                        || Validation.GetHasError(cboCheckOut)
                ;

            if (!isInvalid)
            {
                reservationList.RemoveAt(rowIndex);
                File.Delete("Reservation_List.xml");
                XMLController.WriteToXML(Common.XML_FILE_NAME, ReservationList);
                grdReservation.ItemsSource = ReservationList.Reservations;
                grdReservation.Items.Refresh();
            }
        }
    }
}
