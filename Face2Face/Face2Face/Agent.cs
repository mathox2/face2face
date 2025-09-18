using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Face2Face
{
    public partial class Agent : Form
    {
        public Agent()
        {
            InitializeComponent();
        }

        private void Agent_Load(object sender, EventArgs e)
        {
            lblJ1.Text = gameMaster.pseudoJ1;
            lblJ2.Text = gameMaster.pseudoJ2;
        }
    }
}
