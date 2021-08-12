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
    public partial class frmAddEdit : Form
    {
        XiomaDataEntities db;
        public frmAddEdit(UserInfo obj)
        {
            InitializeComponent();
            db = new XiomaDataEntities();
            if (obj == null)
            {

                userInfoBindingSource.DataSource = new UserInfo();
                db.UserInfoes.Add(userInfoBindingSource.Current as UserInfo);

            }
            else
            {
                userInfoBindingSource.DataSource = obj;
                db.UserInfoes.Attach(userInfoBindingSource.Current as UserInfo);
            }
        }

        private void frmAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please insert all fields", "Message", MessageBoxButtons.OK);
                    e.Cancel = true;
                    return;
                }
                db.SaveChanges();
                e.Cancel = false;
            }
            e.Cancel = false;
        }
    }
}
