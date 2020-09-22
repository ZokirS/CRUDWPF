using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        MainWindow main = new MainWindow();
        AppDbContext context;
        public Staff Staff { get; set; }
        public UpdateWindow( Staff staff)
        {
            InitializeComponent();
            Staff = staff;
            FirstName.Text = staff.FirstName;
            LastName.Text = staff.LastName;
            genderComboBox.Text = staff.Gender;
        }
        

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Staff.FirstName = FirstName.Text;
            Staff.LastName = LastName.Text;
            Staff.Gender = genderComboBox.Text;

            ((MainWindow)Application.Current.MainWindow).Update(Staff);
                              
            this.Close();
        }
    }
}
