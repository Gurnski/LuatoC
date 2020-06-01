using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;
using MetroFramework.Forms;

namespace Conversion
{
	// Token: 0x02000004 RID: 4
	public partial class MainForm : MetroForm
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002F1C File Offset: 0x0000111C
		public MainForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002F34 File Offset: 0x00001134
		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002F37 File Offset: 0x00001137
		private void materialRaisedButton1_Click(object sender, EventArgs e)
		{
			this.fastColoredTextBox1.Text = Functions.ConvertString(this.fastColoredTextBox1.Text);
		}
	}
}
