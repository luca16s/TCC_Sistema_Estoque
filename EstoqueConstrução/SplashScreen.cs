using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMSplashScreen : Form
    {
        public FRMSplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void TMRSplash_Tick(object sender, EventArgs e)
        {
            PGBSplash.Increment(1);
            if (PGBSplash.Value == 100)
            {
                TMRSplash.Stop();
            }
        }
    }
}
