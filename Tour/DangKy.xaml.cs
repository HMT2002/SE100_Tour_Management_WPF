using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using Tour.Model;
using Tour.Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tour
{
    /// <summary>
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {


        private bool checkMale = true;
        private bool checkFemale = true;

        public bool CheckMale { get => checkMale; set => checkMale = value; }
        public bool CheckFemale { get => checkFemale; set => checkFemale = value; }

        private ObservableCollection<Model.Tour> listAllTour = new ObservableCollection<Model.Tour>();
        public ObservableCollection<Model.Tour> ListAllTour { get => listAllTour; set => listAllTour = value; }

        private ObservableCollection<Doan> listDoan = new ObservableCollection<Doan>();
        public ObservableCollection<Doan> ListDoan { get => listDoan; set => listDoan = value; }


        private Model.Tour selectedTour = new Model.Tour();
        public Model.Tour SelectedTour { get => selectedTour; set => selectedTour = value; }

        private Doan selectedGroup = new Doan();
        public Doan SelectedGroup { get => selectedGroup; set => selectedGroup = value; }

        private DateTime startdate = DateTime.Now;
        public DateTime Startdate { get => startdate; set => startdate = value; }


        public DangKy()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public void ShowAll()
        {
            var tours = (from tour in DataProvider.Ins.DB.Tours
                         join doan in DataProvider.Ins.DB.Doans on tour.Id equals doan.Idtour
                         where tour.IsDeleted == false && doan.IsDeleted == false
                         select tour
                ).ToList();

            ListAllTour = new ObservableCollection<Model.Tour>(tours);

            cbbxTour.ItemsSource = ListAllTour;

            cbbxTour.SelectedIndex = -1;
            Clear();
        }

        public void Clear()
        {
            txtbxCMND.Text = txtbxAddress.Text = txtbxEmail.Text = txtbxPhone.Text = txtbxName.Text = "";
            rdbtnMale.IsChecked = true;
            rdbtnDomestic.IsChecked = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ShowAll();
            Clear();

        }

        private void reset()
        {
            txtbxDuration.Text = txtbxPrice.Text = txtbxDiscount.Text = txtbxSum.Text = "";
            Startdate = DateTime.Now;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bntGotoTicketDatabase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bntCreate_Click(object sender, RoutedEventArgs e)
        {
            string gender = "Male";
            if (rdbtnMale.IsChecked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if (CheckData())
            {
                try
                {
                    string randomcode = Converter.Instance.RandomString2(5);
                    while (DataProvider.Ins.DB.Khachhangs.Where(x => x.Id == randomcode).FirstOrDefault() != null)
                    {
                        randomcode = Converter.Instance.RandomString2(5);
                    }
                    string idkhach = randomcode;
                    var khachhang = new Khachhang()
                    {
                        Id = idkhach,
                        Tenkh = txtbxName.Text,
                        Cmnd = txtbxCMND.Text,
                        Gioitinh = gender,
                        Diachi = txtbxAddress.Text,
                        Sdt = txtbxPhone.Text,
                        IsDeleted = false,
                    };
                    DataProvider.Ins.DB.Khachhangs.Add(khachhang);

                    randomcode = Converter.Instance.RandomString2(5);
                    var ve = new Ve()
                    {
                        Id = randomcode,
                        Idkhach = idkhach,
                        Iddoan = SelectedGroup.Id,
                        Ngaymua = DateTime.Today,
                        Gia = Convert.ToDecimal(txtbxPrice.Text),
                        IsDeleted = false,
                    };
                    DataProvider.Ins.DB.Ves.Add(ve);
                    DataProvider.Ins.DB.SaveChanges();
                    ShowAll();
                }
                catch (Exception ex)
                {

                }
                Clear();

            }


        }

        public bool CheckData()
        {


            if (txtbxName.Text.Trim().CompareTo(string.Empty) == 0 || txtbxAddress.Text.Trim().CompareTo(string.Empty) == 0 || txtbxCMND.Text.Trim().CompareTo(string.Empty) == 0 || selectedGroup == null || selectedTour == null||txtbxPhone.Text.Trim().CompareTo(string.Empty) == 0 ||txtbxEmail.Text.Trim().CompareTo(string.Empty) == 0)
            {
                MessageBox.Show("Please fill in all the information", "Information");
                return false;
            }
            return true;
        }

        private void cbbxTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cbbxTour.SelectedIndex;

            var doans = (from tour in DataProvider.Ins.DB.Tours
                                  join doan in DataProvider.Ins.DB.Doans on tour.Id equals doan.Idtour
                                  where tour.Id == SelectedTour.Id && tour.IsDeleted == false && doan.IsDeleted == false
                                  select doan
                            ).ToList();

            ListDoan = new ObservableCollection<Doan>(doans);

            cbbxGroup.ItemsSource = ListDoan;

            cbbxGroup.SelectedIndex = -1;
            reset();
            txtbxPrice.Text = SelectedTour.Gia.ToString();

        }

        private void cbbxGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Startdate = (DateTime)SelectedGroup.Ngaykhoihanh;
            datepickStart.SelectedDate = Startdate;
            txtbxDuration.Text = ((DateTime)SelectedGroup.Ngayketthuc - (DateTime)SelectedGroup.Ngaykhoihanh).TotalDays.ToString();
        }

        private void bntClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextInputNumericOnly(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
            {
                e.Handled = true ;
            }
        }
    }
}
