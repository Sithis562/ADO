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
    /// Логика взаимодействия для AddWnidow2.xaml
    /// </summary>
    public partial class AddWnidow2 : Window
    {
        public AddWnidow2()
        {
            InitializeComponent();
        }

        public AddWnidow2(DataRow row) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                row["Email"] = txtEmail.Text;
                row["ItemId"] = Convert.ToInt32(txtItemId.Text);
                row["ItemName"] = txtItemName.Text;
                this.DialogResult = !false;
            };

        }
    }
}
