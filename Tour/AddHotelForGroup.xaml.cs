using System;
using System.Collections.Generic;
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

namespace Tour
{
    /// <summary>
    /// Interaction logic for AddHotelForGroup.xaml
    /// </summary>
    /// 


    public partial class AddHotelForGroup : Window
    {
    string ID;

        public AddHotelForGroup()
        {
            InitializeComponent();

        }

        public AddHotelForGroup(string id)
        {
            InitializeComponent();
            ID = id;
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var result2 = (from ks in DataProvider.Ins.DB.Khachsans
                           join tb_belong in DataProvider.Ins.DB.TbKhachsans on ks.Id equals tb_belong.Idkhachsan
                           where tb_belong.Id == ID && tb_belong.IsDeleted == false
                           select ks)
                         .ToList();
            var result = (from ks in DataProvider.Ins.DB.Ves
                          where ks.IsDeleted == false
                          select ks)
                         .ToList();

            lstViewAllKhachSan.ItemsSource = result;

        }
    }
}
