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
using WpfApp1.Models;

namespace WpfApp1.Forms
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        private  AppDbContext _context;
        public Staff Staff { get; set; }
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        MainWindow main1 = new MainWindow();

        public CreateWindow()
        {

            InitializeComponent();

        }
       
        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            _context = new AppDbContext();
            Staff list = new Staff()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Gender = genderComboBox.Text
            };
            

            _context.Staffs.Add(list);
            _context.SaveChanges();
            main1.Activate();
            main1.UpdateDataGrid();
            main1.Show();
            this.Hide();
        }
       
    }
}
