using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Tour.Model;
using Tour.Utils;

namespace Tour
{
    /// <summary>
    /// Interaction logic for AddHotelForGroup.xaml
    /// </summary>
    /// 
    public partial class AddHotelForGroup : Window
    {
        string ID;
        public decimal tong_GIA = 0;

        public ObservableCollection<Khachsan> ListAllKhachSan = new ObservableCollection<Khachsan>();
        public ObservableCollection<Khachsan> ListGroupKhachSan = new ObservableCollection<Khachsan>();



        private Khachsan _SelectedAllKhachSan;
        public Khachsan SelectedAllKhachSan
        {
            get => _SelectedAllKhachSan;
            set
            {
                _SelectedAllKhachSan = value;

            }
        }

        private Khachsan _SelectedGroupKhachSan;
        public Khachsan SelectedGroupKhachSan
        {
            get => _SelectedGroupKhachSan;
            set
            {
                _SelectedGroupKhachSan = value;
            }
        }

        public AddHotelForGroup()
        {
            this.DataContext = this;

            InitializeComponent();
            ID = "FDSPQ";


        }

        public AddHotelForGroup(string id)
        {
            this.DataContext = this;

            InitializeComponent();

            ID = id;
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tb_ks in DataProvider.Ins.DB.TbKhachsans.Where(x => x.Iddoan == ID))
            {
                tb_ks.IsDeleted = true;
            }

            foreach (Khachsan khachsan in ListGroupKhachSan)
            {
                string random1 = Converter.Instance.RandomString2(5);
                while (DataProvider.Ins.DB.TbKhachsans.Where(x => x.Id == random1).FirstOrDefault() != null)
                {
                    random1 = Converter.Instance.RandomString2(5);
                }
                tong_GIA += (decimal)khachsan.Gia;

                DataProvider.Ins.DB.TbKhachsans.Add(new TbKhachsan() { Id = random1, Idkhachsan = khachsan.Id, Iddoan = ID, IsDeleted = false });


            }

            DataProvider.Ins.DB.SaveChanges();

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var resultGroup = (from ks in DataProvider.Ins.DB.Khachsans
                           join tb_belong in DataProvider.Ins.DB.TbKhachsans on ks.Id equals tb_belong.Idkhachsan
                           where tb_belong.Iddoan == ID && tb_belong.IsDeleted == false
                           select ks)
                         .ToList();
            var resultAll = (from ks in DataProvider.Ins.DB.Khachsans
                          where ks.IsDeleted == false
                          select ks)
                         .ToList();

            ListAllKhachSan = new ObservableCollection<Khachsan>(resultAll);
            ListGroupKhachSan = new ObservableCollection<Khachsan>(resultGroup);

            lstBxAllKhachSan.ItemsSource = ListAllKhachSan;
            lstBxGroupKhachSan.ItemsSource = ListGroupKhachSan;
        }


        private void lstBxAllKhachSan_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            Khachsan ks = (Khachsan)item;
            if (item != null)
            {
                if (ks == null)
                {
                    return;
                }
                if (ListGroupKhachSan.Contains(ks))
                {
                    return;
                }
                ListGroupKhachSan.Add(ks);

            }

        }

        private void lstBxGroupKhachSan_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            Khachsan ks = (Khachsan)item;
            if (item != null)
            {
                if (ks == null)
                {
                    return;
                }
                ListGroupKhachSan.Remove(ks);

            }
        }
    }
}
