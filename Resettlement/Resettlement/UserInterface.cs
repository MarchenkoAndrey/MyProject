using System;
using System.Windows.Forms;
using Resettlement.CorridorModel;

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
            var dataDAlg = new InputSectionDataAlg();
            PerformDAlg(dataDAlg);
        }

        private void greedy_btn_Click(object sender, EventArgs e)
        {
            var dataHAlg = new InputSectionDataAlg();
            PerformHAlg(dataHAlg);
        }

        private void corridor_btn_Click(object sender, EventArgs e)
        {
            var buildingPrepared = PrepareCorridorModel.ToPrepareCorridorModel();
            var buildingCreated = PerformCorridorModel.ToPerformCorridorModel(buildingPrepared);
            PrintCorridorModel.ToPrintCorridorModel(buildingCreated);
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            var dataCAlg = new InputSectionDataAlg();
            PerformComprehensiveSearch(dataCAlg);
        }
    }
}
