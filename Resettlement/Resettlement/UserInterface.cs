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
        
//        private void greedy_btn_Click(object sender, EventArgs e)
//        {
//            var dataHAlg = PreparationBeforeAlgorithm();
//            PerformHeuristicAlgorithm(dataHAlg);
//        }

//        private void fullSearch_btn_Click(object sender, EventArgs e)
//        {
//            var dataCAlg = PreparationBeforeAlgorithm();
//            PerformComprehensiveSearch(dataCAlg);
//        }

        private void generalCase_btn_Click(object sender, EventArgs e)
        {
            var dataGeneralAlg = PreparationBeforeAlgorithm();
            
        }
    }
}
