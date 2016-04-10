using System.Windows.Forms;

namespace Resettlement
{
	public static class StartAndFinishProgram
	{
	    private static void Main()
	    {
	        //Запуск формы
	        Application.EnableVisualStyles();
	        Application.SetCompatibleTextRenderingDefault(false);
	        var ui = new UserInterface();
	        Application.Run(ui);
	    }
	}
}
