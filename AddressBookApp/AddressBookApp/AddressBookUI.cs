using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBookApp
{
    public partial class AddressBookAppUI : Form
    {
        public AddressBookAppUI()
        {
            InitializeComponent();
        }
        AddressBook anAddressBook = new AddressBook();
        Address anAddress;

        private void saveButton_Click(object sender, EventArgs e)
        {

            anAddress = new Address();
            anAddress.FirstName = firstNameTextBox.Text;
            anAddress.LastName = lastNameTextBox.Text;
            anAddress.Email = emailTextBox.Text;
            anAddress.PhoneNo = phoneNoTextBox.Text;

            bool varify=anAddressBook.CheckEmailAddress(emailTextBox.Text);

            if (varify)
            {
                bool check = anAddressBook.AddAddress(anAddress);

                if (check)
                {
                    MessageBox.Show("Address with this email already exists.");

                }
                else
                {
                    MessageBox.Show("Address saved successfully");
                    addressListDataGridView.DataSource = null;
                    addressListDataGridView.DataSource = anAddressBook.GetAllAddress();
                }
            }
            else
            {
                MessageBox.Show("Email address is not valid\nIt must contail only one @ and at least one(.)");
            }


        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

            if (firstNameRadioButton.Checked == true)
            {
                searchAddressDataGridView.DataSource = null;
                searchAddressDataGridView.DataSource = anAddressBook.GetSelectedFirstName(searchTextBox.Text);
            }
            else if (lastNameRadioButton.Checked == true)
            {
                searchAddressDataGridView.DataSource = null;
                searchAddressDataGridView.DataSource = anAddressBook.GetSelectedLastName(searchTextBox.Text);
            }
            else if (emailRadioButton.Checked == true)
            {
                searchAddressDataGridView.DataSource = null;
                searchAddressDataGridView.DataSource = anAddressBook.GetSelectedEmail(searchTextBox.Text);
            }
            else if (phoneNoRadioButton.Checked == true)
            {
                searchAddressDataGridView.DataSource = null;
                searchAddressDataGridView.DataSource = anAddressBook.GetSelectedPhoneNo(searchTextBox.Text);
            }
        }

        private void searchAddressDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            firstNameTextBox.Text = searchAddressDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            lastNameTextBox.Text = searchAddressDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            emailTextBox.Text = searchAddressDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            phoneNoTextBox.Text = searchAddressDataGridView.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void updateButton_Click_1(object sender, EventArgs e)
        {
            int n = anAddressBook.GetIndexOfSectedAddress(emailTextBox.Text);

            if (n == -1)
            {
                MessageBox.Show("Email address can not be changed");
            }
            else
            {

                anAddressBook.UpdateAddress(n, firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text, phoneNoTextBox.Text);
                addressListDataGridView.DataSource = null;
                addressListDataGridView.DataSource = anAddressBook.GetAllAddress();
                MessageBox.Show("Updated succeesfully");
            }
        }
      
    }
}
