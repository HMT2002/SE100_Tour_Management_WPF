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
    /// Interaction logic for AddLocationForTour.xaml
    /// </summary>
    public partial class AddLocationForTour : Window
    {

        string ID;
        public decimal tong_GIA = 0;

        public ObservableCollection<Diadiem> ListAllDiadiem = new ObservableCollection<Diadiem>();
        public ObservableCollection<Diadiem> ListGroupDiadiem = new ObservableCollection<Diadiem>();

        public AddLocationForTour()
        {
            this.DataContext = this;
            InitializeComponent();
            ID = "HKOIJ";
        }

        public AddLocationForTour(string id)
        {
            this.DataContext = this;

            InitializeComponent();
            ID = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var resultGroup = (from dd in DataProvider.Ins.DB.Diadiems
                               join tb_belong in DataProvider.Ins.DB.TbDiadiemDuliches on dd.Id equals tb_belong.Iddiadiem
                               where tb_belong.Idtour == ID && tb_belong.IsDeleted == false
                               select dd)
                         .ToList();
            var resultAll = (from dd in DataProvider.Ins.DB.Diadiems
                             where dd.IsDeleted == false
                             select dd)
                         .ToList();

            ListAllDiadiem = new ObservableCollection<Diadiem>(resultAll);
            ListGroupDiadiem = new ObservableCollection<Diadiem>(resultGroup);

            lstBxAllLocation.ItemsSource = ListAllDiadiem;
            lstBxTourLocation.ItemsSource = ListGroupDiadiem;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tb_dd in DataProvider.Ins.DB.TbDiadiemDuliches.Where(x => x.Idtour == ID))
            {
                tb_dd.IsDeleted = true;
            }

            foreach (Diadiem Diadiem in ListGroupDiadiem)
            {
                string random1 = Converter.Instance.RandomString2(5);
                while (DataProvider.Ins.DB.TbDiadiemDuliches.Where(x => x.Id == random1).FirstOrDefault() != null)
                {
                    random1 = Converter.Instance.RandomString2(5);
                }
                tong_GIA += (decimal)Diadiem.Gia;

                DataProvider.Ins.DB.TbDiadiemDuliches.Add(new TbDiadiemDulich() { Id = random1, Iddiadiem = Diadiem.Id, Idtour = ID, IsDeleted = false });


            }

            DataProvider.Ins.DB.SaveChanges();

            this.Close();
        }

        private void lstBxAllLocation_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            Diadiem dd = (Diadiem)item;
            if (item != null)
            {
                if (dd == null)
                {
                    return;
                }
                if (ListGroupDiadiem.Contains(dd))
                {
                    return;
                }
                ListGroupDiadiem.Add(dd);

            }
        }

        private void lstBxTourLocation_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            Diadiem dd = (Diadiem)item;
            if (item != null)
            {
                if (dd == null)
                {
                    return;
                }
                ListGroupDiadiem.Remove(dd);

            }
        }
    }
}
