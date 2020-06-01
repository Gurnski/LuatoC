namespace Conversion
{
	// Token: 0x02000004 RID: 4
	public partial class MainForm : global::MetroFramework.Forms.MetroForm
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002F58 File Offset: 0x00001158
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002F90 File Offset: 0x00001190
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Conversion.MainForm));
			this.fastColoredTextBox1 = new global::FastColoredTextBoxNS.FastColoredTextBox();
			this.materialRaisedButton1 = new global::MaterialSkin.Controls.MaterialRaisedButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.fastColoredTextBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.fastColoredTextBox1.AutoCompleteBracketsList = new char[]
			{
				'(',
				')',
				'{',
				'}',
				'[',
				']',
				'"',
				'"',
				'\'',
				'\''
			};
			this.fastColoredTextBox1.AutoScrollMinSize = new global::System.Drawing.Size(27, 14);
			this.fastColoredTextBox1.BackBrush = null;
			this.fastColoredTextBox1.CharHeight = 14;
			this.fastColoredTextBox1.CharWidth = 8;
			this.fastColoredTextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.fastColoredTextBox1.DisabledColor = global::System.Drawing.Color.FromArgb(100, 180, 180, 180);
			this.fastColoredTextBox1.Font = new global::System.Drawing.Font("Courier New", 9.75f);
			this.fastColoredTextBox1.IsReplaceMode = false;
			this.fastColoredTextBox1.Language = global::FastColoredTextBoxNS.Language.Lua;
			this.fastColoredTextBox1.Location = new global::System.Drawing.Point(9, 63);
			this.fastColoredTextBox1.Name = "fastColoredTextBox1";
			this.fastColoredTextBox1.Paddings = new global::System.Windows.Forms.Padding(0);
			this.fastColoredTextBox1.SelectionColor = global::System.Drawing.Color.FromArgb(60, 0, 0, 255);
			this.fastColoredTextBox1.ServiceColors = (global::FastColoredTextBoxNS.ServiceColors)componentResourceManager.GetObject("fastColoredTextBox1.ServiceColors");
			this.fastColoredTextBox1.Size = new global::System.Drawing.Size(312, 226);
			this.fastColoredTextBox1.TabIndex = 0;
			this.fastColoredTextBox1.Zoom = 100;
			this.materialRaisedButton1.Depth = 0;
			this.materialRaisedButton1.Location = new global::System.Drawing.Point(9, 295);
			this.materialRaisedButton1.MouseState = global::MaterialSkin.MouseState.HOVER;
			this.materialRaisedButton1.Name = "materialRaisedButton1";
			this.materialRaisedButton1.Primary = true;
			this.materialRaisedButton1.Size = new global::System.Drawing.Size(312, 42);
			this.materialRaisedButton1.TabIndex = 1;
			this.materialRaisedButton1.Text = "convert";
			this.materialRaisedButton1.UseVisualStyleBackColor = true;
			this.materialRaisedButton1.Click += new global::System.EventHandler(this.materialRaisedButton1_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(143, 29);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(155, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Super-Duper-Early-Version";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(169, 41);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(96, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "Cannot do Math!";
			this.pictureBox1.Location = new global::System.Drawing.Point(299, 323);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(98, 34);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(331, 347);
			base.Controls.Add(this.materialRaisedButton1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.fastColoredTextBox1);
			base.MaximizeBox = false;
			base.Name = "MainForm";
			base.ShowIcon = false;
			base.Style = global::MetroFramework.MetroColorStyle.Purple;
			this.Text = "Lua > C";
			base.Theme = global::MetroFramework.MetroThemeStyle.Dark;
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			((global::System.ComponentModel.ISupportInitialize)this.fastColoredTextBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000004 RID: 4
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000005 RID: 5
		private global::FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;

		// Token: 0x04000006 RID: 6
		private global::MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
