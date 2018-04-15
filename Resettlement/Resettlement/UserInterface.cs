using System;
using System.Windows.Forms;

namespace Resettlement
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }
        
        private void dynam_btn_Click(object sender, EventArgs e)
        {
            var dataDAlg = new InputDataAlg();
            PerformDAlg(dataDAlg);
        }

        private void greedy_btn_Click(object sender, EventArgs e)
        {
            var dataHAlg = new InputDataAlg();
            PerformHAlg(dataHAlg);
        }

        private void corridor_btn_Click(object sender, EventArgs e)
        {
            var dataGAlg = new InputGeneralDataAlg();
            //PerformHAlg(dataGAlg);
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            var dataCAlg = new InputDataAlg();
            PerformComprehensiveSearch(dataCAlg);
        }
    }
}
