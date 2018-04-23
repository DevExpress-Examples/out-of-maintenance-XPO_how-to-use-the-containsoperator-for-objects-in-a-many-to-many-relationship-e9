using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Windows.Forms;
using A2404;

namespace DXSample {
    public class Program {
        [STAThread]
        static void Main() {
            XpoDefault.ConnectionString = AccessConnectionProvider.GetConnectionString(@"..\..\data.mdb");
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}