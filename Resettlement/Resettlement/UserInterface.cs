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
        
        private void greedy_btn_Click(object sender, EventArgs e)
        {
            var dataHAlg = new InputDataAlg();
            PerformHAlg(dataHAlg);
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            var dataCAlg = new InputDataAlg();
            PerformComprehensiveSearch(dataCAlg);
        }

//        private void generalCase_btn_Click(object sender, EventArgs e)
//        {
//            var dataGeneralAlg = PreparationBeforeAlgorithm();
//            
//        }
    }
}
