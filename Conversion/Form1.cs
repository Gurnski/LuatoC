using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Conversion
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void button1_Click(object sender, EventArgs e)
		{
			this.textBox1.Text = Functions.ConvertString(this.textBox1.Text);
		}
	}
}
