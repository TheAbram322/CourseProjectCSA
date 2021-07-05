using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR
{
    public partial class Output : Form
    {
        public Output(String inputStr, String outputStr)
        {
            InitializeComponent();
            // вывод текста в rtb
            input_rtb.Text = inputStr;
            output_rtb.Text = outputStr;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
