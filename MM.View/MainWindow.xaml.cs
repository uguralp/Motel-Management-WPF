using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MM.Model;
using MM.Utilities;

namespace MM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region VARIABLES

        private Reservation currentReservation;

        #endregion

        #region PROPERTIES

        private List<RoomType> roomTypes;
        public List<RoomType> RoomTypes { get => roomTypes; set => roomTypes = value; }

        /// <summary>
        /// reservationList
        /// </summary>
        private ReservationList reservationList;

        /// <summary>
        /// ReservationList
        /// </summary>
        public ReservationList ReservationList { get => reservationList; set => reservationList = value; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

        #region BINDING DATA FOR ALL CONTROLS 

        /// <summary>
        /// Init
        /// </summary>
        private void Init()
        {
            // Initialize variable holding the current reservations
            currentReservation = new Reservation();

            // Initialize list of reservations
            ReservationList = new ReservationList();

            // Read data from XML
            ReadDataFromXML();

            // Display XML data to grid
            DisplayListToGrid();

            // Init data for list of room types and room numbers
            InitRoomType();                       

            // Enable/Disable UPDATE, DELETE, SAVE buttons
            EnableButtonWhenRegister();

            Clear();

            // Set data context
            DataContext = this;

        }

        #endregion

        #region INITIALIZE DATA FOR SCREEN

        /// <summary>
        /// InitRoomType
        /// </summary>
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

        /// <summary>
        /// FilterRoomType
        /// </summary>
        private void FilterRoomType()
        {
            //var result = roomTypes.Where(p => !ReservationList.Reservations.Any(p2 => p2.RoomType. == p.RoomTypeID));
            //var result = roomTypes.Where(p => !ReservationList.Reservations.Contains(p));
        }

        /// <summary>
        /// Clear
        /// </summary>
        private void Clear()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtNumOfAdult.Text = string.Empty;
            txtNumOfChild.Text = string.Empty;
            lblSearchResult.Content = string.Empty;
            cboCheckIn.Text = DateTime.Now.ToShortDateString();
            cboCheckOut.Text = DateTime.Now.ToShortDateString();
            txtFirstName.Focus();
        }

        #endregion

        #region VALIDATION
        /// <summary>
        /// ForceValidation
        /// </summary>
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

        /// <summary>
        /// ReadDataFromXML
        /// </summary>
        private void ReadDataFromXML()
        {
            Utilities.XMLController.ReadXML(ref this.reservationList);
        }

        /// <summary>
        /// DisplayXMLToGrid
        /// </summary>
        private void DisplayListToGrid(string textToFilter = "", bool isSearchAll = true)
        {
            if (reservationList != null)
            {
                int searchFound = 0;

                textToFilter = textToFilter.ToLower().Trim();

                var query = from reservation in reservationList.Reservations
                            where
                            (
                                (
                                    textToFilter != ""
                                    &&
                                    (
                                        reservation.Guest.FirstName.ToLower().Contains(textToFilter)
                                            || reservation.Guest.LastName.ToLower().Contains(textToFilter)
                                            || reservation.Guest.Address.ToLower().Contains(textToFilter)
                                            || reservation.Guest.PhoneNumber.Contains(textToFilter)
                                            || reservation.NumberOfAdult.Equals(textToFilter)
                                            || reservation.NumberOfChild.Equals(textToFilter)
                                            || reservation.RoomType.ToLower().Contains(textToFilter)
                                            || reservation.RoomNumber.Equals(textToFilter)
                                            || reservation.CheckIn.Equals(textToFilter)
                                            || reservation.CheckOut.Equals(textToFilter)
                                    )
                                )
                                ||
                                (
                                    isSearchAll == true
                                )
                            )
                            select reservation;

                grdReservation.ItemsSource = query.ToList();
                searchFound = query.ToList().Count;

                if (!isSearchAll)
                {
                    if (searchFound > 0)
                    {
                        lblSearchResult.Content = "There are " + searchFound + " records has been found";
                    }
                    else
                    {
                        lblSearchResult.Content = "There are no records";
                    }
                }                
            }
            else
            {
                lblSearchResult.Content = "No data";
            }
        }

        #endregion

        #region ENABLE/DISABLE BUTTONS
        /// <summary>
        /// EnableButtonWhenRegister
        /// </summary>
        private void EnableButtonWhenRegister()
        {
            btnRegister.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            ToggleInputControls(true);
        }

        /// <summary>
        /// EnableButtonWhenUpdate
        /// </summary>
        private void EnableButtonWhenUpdate()
        {
            btnRegister.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = true;
            ToggleInputControls(false);
        }

        /// <summary>
        /// ToggleInputControls
        /// </summary>
        /// <param name="isTurnOn"></param>
        private void ToggleInputControls(bool isTurnOn)
        {
            HeaderInput.IsEnabled = isTurnOn;
        }

        #endregion

        #endregion

        #region EVENTS

        /// <summary>
        /// Window_Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Window_Loaded error \n" + ex.Message, 
                                    this.Title, 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnRegister_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool isInvalid = false;

            try
            {
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

                    reservation.CheckIn = DateTime.Parse(cboCheckIn.Text).ToShortDateString();
                    reservation.CheckOut = DateTime.Parse(cboCheckOut.Text).ToShortDateString();
                    reservation.NumberOfAdult = int.Parse(txtNumOfAdult.Text);
                    reservation.NumberOfChild = int.Parse(txtNumOfChild.Text);
                    reservation.RoomType = ((RoomType)lstRoomType.SelectedValue).RoomTypeName;
                    reservation.RoomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;                    

                    ReservationList.Reservations.Add(reservation);
                    XMLController.WriteToXML(ReservationList);
                    grdReservation.ItemsSource = ReservationList.Reservations;

                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnRegister_Click Error \n" + ex.Message, 
                    this.Title, 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// grdReservation_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdReservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                EnableButtonWhenUpdate();

                currentReservation = grdReservation.SelectedItem as Reservation;

                if (currentReservation != null)
                {
                    RoomType reservedRoomType = roomTypes.First(r => r.RoomTypeName.ToString().Equals(currentReservation.RoomType));
                    Room reservedRoom = reservedRoomType.Rooms.First(r => r.RoomNumber == currentReservation.RoomNumber);

                    txtFirstName.Text = currentReservation.Guest.FirstName;
                    txtLastName.Text = currentReservation.Guest.LastName;
                    txtAddress.Text = currentReservation.Guest.Address;
                    txtPhoneNumber.Text = currentReservation.Guest.PhoneNumber;
                    txtNumOfAdult.Text = currentReservation.NumberOfAdult.ToString();
                    txtNumOfChild.Text = currentReservation.NumberOfChild.ToString();
                    lstRoomType.SelectedItem = reservedRoomType;
                    cboRoomNumber.SelectedItem = reservedRoom;
                    cboCheckIn.Text = currentReservation.CheckIn.ToString();
                    cboCheckOut.Text = currentReservation.CheckOut.ToString();

                    // Validate again to clear all previous errors
                    ForceValidation();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("grdReservation_SelectionChanged Error \n" + ex.Message, 
                    this.Title, 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grdReservation.UnselectAll();
                EnableButtonWhenRegister();
                Clear();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCancel_Click Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// updateClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                btnRegister.IsEnabled = false;
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                ToggleInputControls(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateClicked Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isInvalid = false;

            try
            {
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
                    Reservation selectedReservation = ReservationList.Reservations.FirstOrDefault(i => i.ReservationID == currentReservation.ReservationID);
                    if (selectedReservation != null)
                    {
                        selectedReservation.Guest.FirstName = txtFirstName.Text;
                        selectedReservation.Guest.LastName = txtLastName.Text;
                        selectedReservation.Guest.Address = txtAddress.Text;
                        selectedReservation.Guest.PhoneNumber = txtPhoneNumber.Text;
                        selectedReservation.NumberOfAdult = int.Parse(txtNumOfAdult.Text);
                        selectedReservation.NumberOfChild = int.Parse(txtNumOfChild.Text);

                        selectedReservation.RoomType = ((RoomType)lstRoomType.SelectedValue).RoomTypeName;
                        selectedReservation.RoomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;
                        selectedReservation.CheckIn = DateTime.Parse(cboCheckIn.Text).ToShortDateString();
                        selectedReservation.CheckOut = DateTime.Parse(cboCheckOut.Text).ToShortDateString();
                    }

                    //ReservationList.Add(reservation);
                    XMLController.WriteToXML(ReservationList);
                    grdReservation.ItemsSource = ReservationList.Reservations;
                    grdReservation.Items.Refresh();

                    //btnCancel_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSave_Click Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// deleteClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteClicked(object sender, RoutedEventArgs e)
        {
             try
            {
                if (MessageBox.Show("Do you really want to delete the selected reservation?"
                    , this.Title
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    
                    ReservationList.Remove(currentReservation);
                    XMLController.WriteToXML(ReservationList);
                    grdReservation.ItemsSource = ReservationList.Reservations;
                    grdReservation.Items.Refresh();

                    btnCancel_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteClicked Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayListToGrid(txtSearch.Text, false);
                DataContext = this;
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "NonVehicleKind":
                        MessageBox.Show("The vehicle kind does not exist"
                                            , this.Title, MessageBoxButton.OK
                                            , MessageBoxImage.Exclamation);
                        break;

                    default:
                        MessageBox.Show(ex.Message
                                            , this.Title
                                            , MessageBoxButton.OK
                                            , MessageBoxImage.Exclamation);
                        break;
                }
            }
        }
        #endregion


    }
}
