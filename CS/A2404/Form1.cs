using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DXSample;

namespace A2404 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            InitData();
        }

        #region Data initialization
        private void InitData() {
            if (null != XpoDefault.Session.FindObject<Role>(new BinaryOperator("RoleName", "Manager"))) return;
            string[] firstName = { "John", "Ben", "Mark", "William" };
            string[] lastName = { "Adams", "Clayborn", "Smith", "Watson" };
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) {
                User user = new User();
                user.Name = string.Format("{0} {1}", firstName[rnd.Next(0, 4)], lastName[rnd.Next(0, 4)]);
                user.Save();
            }
            Role manager = new Role();
            manager.RoleName = "Manager";
            manager.Save();
            Role programmer = new Role();
            programmer.RoleName = "Programmer";
            programmer.Save();
            XPCollection<User> users = new XPCollection<User>();
            XPCollection<Role> roles = new XPCollection<Role>();
            foreach (User user in users) user.Roles.Add(user.Oid % 4 == 0 ? roles[0] : roles[1]);
            XpoDefault.Session.Save(users);
            XpoDefault.Session.Save(roles);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e) {
            dataGridView1.DataSource = new XPCollection(typeof(User));
        }

        private void button2_Click(object sender, EventArgs e) {
            Role manager = XpoDefault.Session.FindObject<Role>(new BinaryOperator("RoleName", "Manager"));
            dataGridView1.DataSource = new XPCollection(typeof(User), new ContainsOperator("Roles", new BinaryOperator("This", manager)));
        }

        private void button3_Click(object sender, EventArgs e) {
            dataGridView1.DataSource = new XPCollection(typeof(User), new ContainsOperator("Roles", new BinaryOperator("RoleName", "Programmer")));
        }

        private void button4_Click(object sender, EventArgs e) {
            dataGridView1.DataSource = new XPCollection(typeof(User), new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] {
                new ContainsOperator("Roles", new BinaryOperator("RoleName", "Programmer")),
                new BinaryOperator("Name", "%Smith%", BinaryOperatorType.Like) }));
        }
    }
}