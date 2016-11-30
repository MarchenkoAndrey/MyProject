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
            var dataHAlg =  PrepareDataBeforeAlgorithm(new DataAlgorithm());
            PerformHeuristicAlgorithm(dataHAlg);
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            var dataCAlg = PrepareDataBeforeAlgorithm(new DataAlgorithm());
            PerformComprehensiveSearch(dataCAlg);
        }

//        private void generalCase_btn_Click(object sender, EventArgs e)
//        {
//            var dataGeneralAlg = PreparationBeforeAlgorithm();
//            
//        }
    }
}
