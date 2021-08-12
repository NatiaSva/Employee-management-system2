using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xioma_app1
{
    public partial class Form1 : Form
    {
        XiomaDataEntities db;
        private string inputValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new XiomaDataEntities();
            userInfoBindingSource.DataSource = db.UserInfoes.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddEdit frm = new frmAddEdit(null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    userInfoBindingSource.DataSource = db.UserInfoes.ToList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (userInfoBindingSource.Current == null)
                return;
            using (frmAddEdit frm = new frmAddEdit(userInfoBindingSource.Current as UserInfo))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    userInfoBindingSource.DataSource = db.UserInfoes.ToList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userInfoBindingSource.Current != null)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.UserInfoes.Remove(userInfoBindingSource.Current as UserInfo);
                    userInfoBindingSource.RemoveCurrent();
                    db.SaveChanges();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            inputValue = textBox1.Text;

            if (inputValue.Length != 0)
            {
                userInfoBindingSource.DataSource = db.UserInfoes.Where(x => x.FirstName.Contains(textBox1.Text) || x.LastName.Contains(textBox1.Text) || x.DateOfBirth.ToString().Contains(textBox1.Text) ||
                x.Role.Contains(textBox1.Text)|| x.Department.Contains(textBox1.Text)|| x.DateOfEntry.ToString().Contains(textBox1.Text) || x.Address.Contains(textBox1.Text)|| x.Id.ToString().Contains(textBox1.Text)).ToList();
            }
            else
            {
                MessageBox.Show("Please insert the value into the  text box to find a specific record");
                userInfoBindingSource.DataSource = db.UserInfoes.ToList();

            }
        }
    }
}
