using System;
using System.Windows.Forms;

namespace Conversion
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000034B0 File Offset: 0x000016B0
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
