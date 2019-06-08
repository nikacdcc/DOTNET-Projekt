using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektDotNet
{
    public partial class PassPopUp : Form
    {
        public PassPopUp()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            PassPopUp.ActiveForm.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(ControlID.password != textBox1.Text)
            {
                var msgBox = MessageBox.Show("Netocni password", "Error!", MessageBoxButtons.OK);
                return;
            }
            ControlID.validated = true;
            PassPopUp.ActiveForm.Close();
            
        }
    }
    public static class ControlID
    {
        public static string password { get; set; } = "password";
        public static bool validated { get; set; } = false;
    }
}
