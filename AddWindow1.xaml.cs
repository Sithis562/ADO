using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1
{
    /// <summary>
    /// Логика взаимодействия для AddWindow1.xaml
    /// </summary>
    public partial class AddWindow1 : Window
    {
        public AddWindow1()
        {
            InitializeComponent();
        }

        public AddWindow1(DataRow row) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                row["LastName"] = txtLastName.Text;
                row["FirstName"] = txtFirstName.Text;
                row["Patronymic"] = txtPatronymic.Text;
                row["PhoneNumber"] = txtPhoneNumber.Text;
                row["Email"] = txtEmail.Text;
                this.DialogResult = !false;
            };

        }
    }
}
