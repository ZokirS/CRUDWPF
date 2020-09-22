using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using WpfApp1.Forms;
using WpfApp1.Models;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext  _context;
        private Staff SelectedStaff;
               
        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            StaffDataGrid.ItemsSource = null;
            StaffDataGrid.ItemsSource = _context.Staffs.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow create = new CreateWindow();
            this.Visibility = Visibility.Hidden;
            UpdateDataGrid();
            create.ShowDialog();
            
                }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStaff is null)
            {
                MessageBox.Show("Please select row");
                return;
            }
            var staff1 = _context.Staffs.FirstOrDefault(s => s.Id == SelectedStaff.Id);
            UpdateWindow w1 = new UpdateWindow(staff1);
            
            w1.ShowDialog();
        }

        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStaff is null)
            {
                MessageBox.Show("Please select row");
                return;
            }
            var staff1 = _context.Staffs.FirstOrDefault(s => s.Id == SelectedStaff.Id);
            Staff staffNew = new Staff()
            {
                FirstName = staff1.FirstName,
                LastName = staff1.LastName,
                Gender = staff1.Gender
            };
            _context.Staffs.Add(staffNew);
            _context.SaveChanges();
            UpdateDataGrid();
        }

        public void Update(Staff staff)
        {
            var staffToUpdate = _context.Staffs.FirstOrDefault(s => s.Id == staff.Id);
            _context.SaveChanges();
            UpdateDataGrid();
        }

        private void StaffDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedStaff = StaffDataGrid.SelectedItem as Staff;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStaff is null)
            {
                MessageBox.Show("Please select row");
                return;
            }
            var staff1 = _context.Staffs.FirstOrDefault(s => s.Id == SelectedStaff.Id);
            _context.Staffs.Remove(staff1);
            _context.SaveChanges();
            UpdateDataGrid();
        }
    }
}
