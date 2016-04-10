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
            PerformHeuristicAlgorithm();
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            PerformComprehensiveSearch();
        }
    }
}
