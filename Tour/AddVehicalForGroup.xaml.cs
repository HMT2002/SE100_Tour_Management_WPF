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
    /// Interaction logic for AddVehicalForGroup.xaml
    /// </summary>
    public partial class AddVehicalForGroup : Window
    {
        string ID;
        public decimal tong_GIA = 0;

        public ObservableCollection<Phuongtien> ListAllPhuongtien = new ObservableCollection<Phuongtien>();
        public ObservableCollection<Phuongtien> ListGroupPhuongtien = new ObservableCollection<Phuongtien>();


        public AddVehicalForGroup()
        {
            this.DataContext = this;
            InitializeComponent();
            this.ID = "FDSPQ";
        }

        public AddVehicalForGroup(string id)
        {
            this.DataContext = this;
            InitializeComponent();
            this.ID = id;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var resultGroup = (from pt in DataProvider.Ins.DB.Phuongtiens
                               join tb_belong in DataProvider.Ins.DB.TbPhuongtiens on pt.Id equals tb_belong.Idphuongtien
                               where tb_belong.Iddoan == this.ID && tb_belong.IsDeleted == false
                               select pt)
                         .ToList();
            var resultAll = (from pt in DataProvider.Ins.DB.Phuongtiens
                             where pt.IsDeleted == false
                             select pt)
                         .ToList();

            ListAllPhuongtien = new ObservableCollection<Phuongtien>(resultAll);
            ListGroupPhuongtien = new ObservableCollection<Phuongtien>(resultGroup);

            lstBxAllPhuongTien.ItemsSource = ListAllPhuongtien;
            lstBxGroupPhuongTien.ItemsSource = ListGroupPhuongtien;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tb_pt in DataProvider.Ins.DB.TbPhuongtiens.Where(x => x.Iddoan == ID))
            {
                tb_pt.IsDeleted = true;
            }

            foreach (Phuongtien Phuongtien in ListGroupPhuongtien)
            {
                string random1 = Converter.Instance.RandomString2(5);
                while (DataProvider.Ins.DB.TbPhuongtiens.Where(x => x.Id == random1).FirstOrDefault() != null)
                {
                    random1 = Converter.Instance.RandomString2(5);
                }
                tong_GIA += (decimal)Phuongtien.Gia;

                DataProvider.Ins.DB.TbPhuongtiens.Add(new TbPhuongtien() { Id = random1, Idphuongtien = Phuongtien.Id, Iddoan = ID, IsDeleted = false });


            }

            DataProvider.Ins.DB.SaveChanges();

            this.Close();
        }

        private void lstBxGroupPhuongTien_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            Phuongtien pt = (Phuongtien)item;
            if (item != null)
            {
                if (pt == null)
                {
                    return;
                }
                ListGroupPhuongtien.Remove(pt);

            }
        }

        private void lstBxAllPhuongTien_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            Phuongtien pt = (Phuongtien)item;
            if (item != null)
            {
                if (pt == null)
                {
                    return;
                }
                if (ListGroupPhuongtien.Contains(pt))
                {
                    return;
                }
                ListGroupPhuongtien.Add(pt);

            }
        }
    }
}
