﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrOCR
{
	[Description("Provides a user control that allows the user to edit HTML page.")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class AdvRichTextBox : UserControl
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void InitializeComponent()
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			this.font_宋体 = new ToolStripMenuItem();
			this.font_楷体 = new ToolStripMenuItem();
			this.font_黑体 = new ToolStripMenuItem();
			this.font_微软雅黑 = new ToolStripMenuItem();
			this.font_新罗马 = new ToolStripMenuItem();
			this.zh_jp = new ToolStripMenuItem();
			this.zh_ko = new ToolStripMenuItem();
			this.zh_en = new ToolStripMenuItem();
			this.mode_顶置 = new ToolStripMenuItem();
			this.mode_正常 = new ToolStripMenuItem();
			this.mode_合并 = new ToolStripMenuItem();
			this.topmost = new ToolStripButton();
			this.languagle = new ToolStripDropDownButton();
			this.mode = new ToolStripDropDownButton();
			this.Fontstyle = new ToolStripDropDownButton();
			this.toolStripToolBar = new HelpRepaint.ToolStripEx();
			this.toolStripButtonclose = new ToolStripButton();
			this.toolStripButtonBold = new ToolStripButton();
			this.toolStripButtonParagraph = new ToolStripButton();
			this.toolStripButtonFind = new ToolStripButton();
			this.toolStripButtonColor = new HelpRepaint.ColorPicker();
			this.toolStripSeparatorFont = new ToolStripSeparator();
			this.toolStripButtonFence = new ToolStripButton();
			this.toolStripButtonSplit = new ToolStripButton();
			this.toolStripButtoncheck = new ToolStripButton();
			this.toolStripButtonIndent = new ToolStripButton();
			this.toolStripSeparatorFormat = new ToolStripSeparator();
			this.toolStripButtonLeft = new ToolStripButton();
			this.toolStripButtonMerge = new ToolStripButton();
			this.toolStripButtonVoice = new ToolStripButton();
			this.toolStripButtonFull = new ToolStripButton();
			this.toolStripSeparatorAlign = new ToolStripSeparator();
			this.toolStripButtonspace = new ToolStripButton();
			this.toolStripButtonR_arow = new ToolStripButton();
			this.toolStripButtonSend = new ToolStripButton();
			this.toolStripButtonTrans = new ToolStripButton();
			this.toolStripButtonNote = new ToolStripButton();
			this.richTextBox1 = new RichTextBoxEx();
			this.toolStripToolBar.SuspendLayout();
			base.SuspendLayout();
			this.toolStripSeparatorFont.ForeColor = Color.White;
			this.toolStripToolBar.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStripToolBar.Location = new Point(0, 0);
			this.toolStripToolBar.Name = "toolStripToolBar";
			this.toolStripToolBar.RenderMode = ToolStripRenderMode.System;
			this.toolStripToolBar.Size = new Size(600, 25);
			this.toolStripToolBar.TabIndex = 1;
			this.toolStripToolBar.Click += this.toolStripToolBar_Click;
			this.toolStripToolBar.Text = "Tool Bar";
			this.toolStripToolBar.BackColor = Color.White;
			this.toolStripToolBar.Renderer = new HelpRepaint.MenuItemRenderer();
			this.toolStripButtonBold.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonBold.Image = (Image)componentResourceManager.GetObject("toolStripButtonBold.Image");
			this.toolStripButtonBold.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonBold.Name = "toolStripButtonBold";
			this.toolStripButtonBold.Size = new Size(23, 22);
			this.toolStripButtonBold.Text = "加粗";
			this.toolStripButtonBold.Click += this.toolStripButtonBold_Click;
			this.toolStripButtonParagraph.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonParagraph.Image = (Image)componentResourceManager.GetObject("toolStripButtonParagraph.Image");
			this.toolStripButtonParagraph.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonParagraph.Name = "toolStripButtonParagraph";
			this.toolStripButtonParagraph.Size = new Size(23, 22);
			this.toolStripButtonParagraph.Text = "依据位置自动分段\r\n仅支持搜狗接口\r\n适合段落识别\r\n图片越清晰越准确\r\n准确度98%以上";
			this.toolStripButtonParagraph.Click += this.toolStripButtonParagraph_Click;
			this.toolStripButtonParagraph.MouseDown += this.toolStripButtonParagraph_keydown;
			this.toolStripButtonFind.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonFind.Image = (Image)componentResourceManager.GetObject("toolStripButtonFind.Image");
			this.toolStripButtonFind.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonFind.Name = "toolStripButtonFind";
			this.toolStripButtonFind.Size = new Size(23, 22);
			this.toolStripButtonFind.Text = "查找\\替换";
			this.toolStripButtonFind.Click += this.toolStripButtonFind_Click;
			this.toolStripButtonColor.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonColor.Image = (Image)componentResourceManager.GetObject("toolStripButtonColor.Image");
			this.toolStripButtonColor.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonColor.Name = "toolStripButtonColor";
			this.toolStripButtonColor.Size = new Size(23, 22);
			this.toolStripButtonColor.Text = "字体颜色";
			this.toolStripButtonColor.Click += this.toolStripButtonColor_Click;
			this.toolStripButtonLeft.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonLeft.Image = (Image)componentResourceManager.GetObject("toolStripButtonLeft.Image");
			this.toolStripButtonLeft.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonLeft.Name = "toolStripButtonLeft";
			this.toolStripButtonLeft.Size = new Size(23, 22);
			this.toolStripButtonLeft.Text = "左对齐";
			this.toolStripButtonLeft.Click += this.toolStripButtonLeft_Click;
			this.toolStripButtonMerge.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge.Image");
			this.toolStripButtonMerge.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonMerge.Name = "toolStripButtonMerge";
			this.toolStripButtonMerge.Size = new Size(23, 22);
			this.toolStripButtonMerge.Text = "将文本合并成一段";
			this.toolStripButtonMerge.Click += this.toolStripButtonMerge_Click;
			this.toolStripButtonMerge.MouseDown += this.toolStripButtonMerge_keydown;
			this.toolStripButtonVoice.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonVoice.Image = (Image)componentResourceManager.GetObject("toolStripButtonVoice.Image");
			this.toolStripButtonVoice.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonVoice.Name = "toolStripButtonVoice";
			this.toolStripButtonVoice.Size = new Size(23, 22);
			this.toolStripButtonVoice.Text = "朗读";
			this.toolStripButtonVoice.Click += this.toolStripButtonVoice_Click;
			this.toolStripButtonFull.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonFull.Image = (Image)componentResourceManager.GetObject("toolStripButtonFull.Image");
			this.toolStripButtonFull.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonFull.Name = "toolStripButtonFull";
			this.toolStripButtonFull.Size = new Size(23, 22);
			this.toolStripButtonFull.Text = "两端对齐";
			this.toolStripButtonFull.Click += this.toolStripButtonFull_Click;
			this.toolStripButtonspace.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonspace.Image = (Image)componentResourceManager.GetObject("toolStripButtonspace.Image");
			this.toolStripButtonspace.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonspace.Name = "toolStripButtonLine";
			this.toolStripButtonspace.Size = new Size(23, 22);
			this.toolStripButtonspace.Text = "首行缩进";
			this.toolStripButtonspace.Click += this.toolStripButtonspace_Click;
			this.toolStripButtonFence.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonFence.Image = (Image)componentResourceManager.GetObject("toolStripButtonFence.Image");
			this.toolStripButtonFence.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonFence.Name = "toolStripButtonformat";
			this.toolStripButtonFence.Size = new Size(23, 22);
			this.toolStripButtonFence.Text = "截图时自动分栏\r\n多选区时无效\r\n单击显示分栏示意图";
			this.toolStripButtonFence.Click += this.toolStripButtonFence_Click;
			this.toolStripButtonFence.MouseDown += this.toolStripButtonFence_keydown;
			this.toolStripButtonSend.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSend.Image = (Image)componentResourceManager.GetObject("toolStripButtonSend.Image");
			this.toolStripButtonSend.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonSend.Name = "toolStripButtonSend";
			this.toolStripButtonSend.Size = new Size(23, 22);
			this.toolStripButtonSend.Text = "复制/发送";
			this.toolStripButtonSend.Click += this.toolStripButtonSend_Click;
			this.toolStripButtonSplit.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit.Image");
			this.toolStripButtonSplit.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonSplit.Name = "toolStripButtonSplit";
			this.toolStripButtonSplit.Size = new Size(23, 22);
			this.toolStripButtonSplit.Text = "按图片中的行进行拆分";
			this.toolStripButtonSplit.Click += this.toolStripButtonSplit_Click;
			this.toolStripButtonSplit.MouseDown += this.toolStripButtonSplit_keydown;
			this.toolStripButtoncheck.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtoncheck.Image = (Image)componentResourceManager.GetObject("toolStripButtoncheck.Image");
			this.toolStripButtoncheck.ImageTransparentColor = Color.Magenta;
			this.toolStripButtoncheck.Name = "toolStripButtoncheck";
			this.toolStripButtoncheck.Size = new Size(23, 22);
			this.toolStripButtoncheck.Text = "检查文本是否有错别字";
			this.toolStripButtoncheck.Click += this.toolStripButtoncheck_Click;
			this.toolStripButtoncheck.MouseDown += this.toolStripButtoncheck_keydown;
			this.toolStripButtonTrans.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonTrans.Image = (Image)componentResourceManager.GetObject("toolStripButtonTrans.Image");
			this.toolStripButtonTrans.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonTrans.Name = "toolStripButtonTrans";
			this.toolStripButtonTrans.Size = new Size(23, 22);
			this.toolStripButtonTrans.Text = "翻译";
			this.toolStripButtonTrans.Click += this.toolStripButtonTrans_Click;
			this.toolStripButtonTrans.MouseDown += this.toolStripButtontrans_keydown;
			this.toolStripButtonNote.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonNote.Image = (Image)componentResourceManager.GetObject("toolStripButtonNote.Image");
			this.toolStripButtonNote.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonNote.Name = "toolStripButtonTrans";
			this.toolStripButtonNote.Size = new Size(23, 22);
			this.toolStripButtonNote.Text = "记录窗体";
			this.toolStripButtonNote.Click += this.toolStripButtonNote_Click;
			this.toolStripButtonclose.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonclose.Image = (Image)componentResourceManager.GetObject("toolStripButtonclose.Image");
			this.toolStripButtonclose.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonclose.Name = "toolStripButtonclose";
			this.toolStripButtonclose.Size = new Size(23, 22);
			this.toolStripButtonclose.Text = "关闭";
			this.toolStripButtonclose.Click += this.toolStripButtonclose_Click;
			this.languagle.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.languagle.Image = (Image)componentResourceManager.GetObject("languagle.Image");
			this.languagle.ImageTransparentColor = Color.Magenta;
			this.languagle.Name = "toolStripButtonclose";
			this.languagle.Size = new Size(23, 22);
			this.languagle.Text = "选择翻译语言\r\n支持自动检测\r\n可以双向翻译";
			this.zh_en.Text = "中⇆英";
			this.zh_en.ForeColor = Color.Red;
			this.zh_en.Click += this.zh_en_Click;
			this.zh_jp.Text = "中⇆日";
			this.zh_jp.ForeColor = Color.Black;
			this.zh_jp.Click += this.zh_jp_Click;
			this.zh_ko.Text = "中⇆韩";
			this.zh_ko.ForeColor = Color.Black;
			this.zh_ko.Click += this.zh_ko_Click;
			this.languagle.DropDownItems.Add(this.zh_en);
			this.languagle.DropDownItems.Add(this.zh_jp);
			this.languagle.DropDownItems.Add(this.zh_ko);
			this.languagle.AutoSize = false;
			((ToolStripDropDownMenu)this.languagle.DropDown).ShowImageMargin = false;
			this.languagle.DropDown.BackColor = Color.White;
			this.languagle.DropDown.AutoSize = false;
			if (Program.factor == 1f)
			{
				this.languagle.DropDown.AutoSize = false;
			}
			else
			{
				this.languagle.DropDown.AutoSize = true;
			}
			this.languagle.DropDown.Width = Convert.ToInt32(55f);
			this.languagle.DropDown.Height = Convert.ToInt32(70f);
			this.languagle.ShowDropDownArrow = false;
			this.topmost.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.topmost.Image = (Image)componentResourceManager.GetObject("mode.Image");
			this.topmost.ImageTransparentColor = Color.Magenta;
			this.topmost.Name = "toolStripButtonclose";
			this.topmost.Size = new Size(23, 22);
			this.topmost.Text = "顶置";
			this.topmost.MouseDown += this.topmost_keydown;
			this.Fontstyle.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.Fontstyle.Image = (Image)componentResourceManager.GetObject("Fontstyle.Image");
			this.Fontstyle.ImageTransparentColor = Color.Magenta;
			this.Fontstyle.Name = "toolStripButtonclose";
			this.Fontstyle.Size = new Size(23, 22);
			this.Fontstyle.Text = "字体";
			this.Fontstyle.AutoSize = false;
			((ToolStripDropDownMenu)this.Fontstyle.DropDown).ShowImageMargin = false;
			this.Fontstyle.DropDown.BackColor = Color.White;
			this.Fontstyle.DropDown.AutoSize = false;
			if (Program.factor == 1f)
			{
				this.Fontstyle.DropDown.AutoSize = false;
			}
			else
			{
				this.Fontstyle.DropDown.AutoSize = true;
			}
			this.Fontstyle.DropDown.Width = Convert.ToInt32(123f);
			this.Fontstyle.DropDown.Height = Convert.ToInt32(115f);
			this.Fontstyle.ShowDropDownArrow = false;
			this.font_宋体.Text = "宋体";
			this.font_宋体.ForeColor = Color.Black;
			this.font_宋体.Click += this.font_宋体c;
			this.font_黑体.Text = "黑体";
			this.font_黑体.ForeColor = Color.Black;
			this.font_黑体.Click += this.font_黑体c;
			this.font_楷体.Text = "楷体";
			this.font_楷体.ForeColor = Color.Black;
			this.font_楷体.Click += this.font_楷体c;
			this.font_微软雅黑.Text = "微软雅黑";
			this.font_微软雅黑.ForeColor = Color.Black;
			this.font_微软雅黑.Click += this.font_微软雅黑c;
			this.font_新罗马.Text = "Time New Roman";
			this.font_新罗马.ForeColor = Color.Red;
			this.font_新罗马.Click += this.font_新罗马c;
			this.Fontstyle.DropDownItems.Add(this.font_宋体);
			this.Fontstyle.DropDownItems.Add(this.font_黑体);
			this.Fontstyle.DropDownItems.Add(this.font_楷体);
			this.Fontstyle.DropDownItems.Add(this.font_微软雅黑);
			this.Fontstyle.DropDownItems.Add(this.font_新罗马);
			this.richTextBox1.Location = new Point(32, 13);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new Size(603, 457);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.DetectUrls = true;
			this.richTextBox1.HideSelection = false;
			this.richTextBox1.Text = "";
			this.richTextBox1.BorderStyle = BorderStyle.None;
			this.richTextBox1.Dock = DockStyle.Fill;
			this.richTextBox1.Multiline = true;
			this.richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
			this.richTextBox1.KeyDown += this.richTextBox1_KeyDown;
			this.richTextBox1.LinkClicked += this.richTextBox1_LinkClicked;
			this.richTextBox1.MouseDown += this.richtextbox1_MouseDown;
			this.richTextBox1.AllowDrop = true;
			this.richTextBox1.MouseEnter += this.Form1_MouseEnter;
			this.richTextBox1.DragEnter += this.Form1_DragEnter;
			this.richTextBox1.DragDrop += this.Form1_DragDrop;
			this.richTextBox1.SelectionAlignment = HelpRepaint.TextAlign.Justify;
			this.richTextBox1.SetLine = "行高";
			this.richTextBox1.Font = new Font("Times New Roman", 16f * Program.factor, GraphicsUnit.Pixel);
			this.richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
			this.richTextBox1.TextChanged += this.richeditbox_TextChanged;
			this.richTextBox1.Cursor = Cursors.IBeam;
			this.indent_two(1);
			this.mode.Font = new Font("微软雅黑", 9f * Program.factor, FontStyle.Regular);
			this.languagle.Font = new Font("微软雅黑", 9f * Program.factor, FontStyle.Regular);
			this.Fontstyle.Font = new Font("微软雅黑", 9f * Program.factor, FontStyle.Regular);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.richTextBox1);
			base.Controls.Add(this.toolStripToolBar);
			base.Name = "richTextBox";
			base.Text = "richTextBox";
			base.Size = new Size(600, 300);
			this.toolStripToolBar.ResumeLayout(false);
			this.toolStripToolBar.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public AdvRichTextBox()
		{
			this.toolspace = true;
			this.toolFull = true;
			this.c = new AdvRichTextBox.cmd(50);
			this.Font = new Font(this.Font.Name, 9f / StaticValue.Dpifactor, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
			this.InitializeComponent();
			this.readIniFile();
			this.richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
		}

		public override string Text
		{
			get
			{
				return this.richTextBox1.Text;
			}
			set
			{
				this.richTextBox1.Font = new Font("Times New Roman", 16f * Program.factor, GraphicsUnit.Pixel);
				this.richTextBox1.Text = value;
				this.richTextBox1.Font = new Font("Times New Roman", 16f * Program.factor, GraphicsUnit.Pixel);
			}
		}

		public void toolStripButtonBold_Click(object sender, EventArgs e)
		{
			Font selectionFont = this.richTextBox1.SelectionFont;
			if (selectionFont.Bold)
			{
				Font font = new Font(selectionFont, selectionFont.Style & ~FontStyle.Bold);
				this.richTextBox1.SelectionFont = font;
			}
			else
			{
				Font font2 = new Font(selectionFont, selectionFont.Style | FontStyle.Bold);
				this.richTextBox1.SelectionFont = font2;
			}
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonParagraph_Click(object sender, EventArgs e)
		{
		}

		public void toolStripButtonFind_Click(object sender, EventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			ReplaceForm replaceForm = new ReplaceForm(this);
			if (this.txt_flag == "天若幽心")
			{
				replaceForm.Text = "识别替换";
				replaceForm.Location = base.PointToScreen(new Point((base.Width - replaceForm.Width) / 2, (base.Height - replaceForm.Height) / 2));
			}
			else
			{
				replaceForm.Text = "翻译替换";
				replaceForm.Location = base.PointToScreen(new Point((base.Width - replaceForm.Width) / 2, (base.Height - replaceForm.Height) / 2));
			}
			replaceForm.Show(this);
		}

		public void toolStripButtonColor_Click(object sender, EventArgs e)
		{
			this.richTextBox1.SelectionColor = this.toolStripButtonColor.SelectedColor;
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonFence_Click(object sender, EventArgs e)
		{
			if (!File.Exists("cvextern.dll"))
			{
				MessageBox.Show("请从蓝奏网盘中下载cvextern.dll大小约25m，点击确定自动弹出网页。\r\n将下载后的文件与 天若.exe 这个文件放在一起。");
				Process.Start("https://www.lanzous.com/i1ab3vg");
				return;
			}
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			if (File.Exists("Data\\分栏预览图.jpg"))
			{
				Process process = new Process();
				process.StartInfo.FileName = "Data\\分栏预览图.jpg";
				process.StartInfo.Arguments = "rundl132.exe C://WINDOWS//system32//shimgvw.dll,ImageView";
				process.Start();
				process.Close();
			}
		}

		public void toolStripButtonSplit_Click(object sender, EventArgs e)
		{
			this.richTextBox1.Text = StaticValue.v_Split;
			Application.DoEvents();
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtoncheck_Click(object sender, EventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			new Thread(new ThreadStart(this.错别字检查API)).Start();
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonIndent_Click(object sender, EventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonLeft_Click(object sender, EventArgs e)
		{
			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionAlignment = HelpRepaint.TextAlign.Left;
			this.richTextBox1.Select(0, 0);
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonMerge_Click(object sender, EventArgs e)
		{
			string text = this.richTextBox1.Text.TrimEnd(new char[] { '\n' }).TrimEnd(new char[] { '\r' }).TrimEnd(new char[] { '\n' });
			if (text.Split(Environment.NewLine.ToCharArray()).Length > 1)
			{
				string[] array = text.Split(Environment.NewLine.ToCharArray());
				string text2 = "";
				for (int i = 0; i < array.Length - 1; i++)
				{
					string text3 = array[i].Substring(array[i].Length - 1, 1);
					string text4 = array[i + 1].Substring(0, 1);
					if (AdvRichTextBox.contain_en(text3) && AdvRichTextBox.contain_en(text4))
					{
						text2 = text2 + array[i] + " ";
					}
					else
					{
						text2 += array[i];
					}
				}
				string text5 = text2.Substring(text2.Length - 1, 1);
				string text6 = array[array.Length - 1].Substring(0, 1);
				if (AdvRichTextBox.contain_en(text5) && AdvRichTextBox.contain_en(text6))
				{
					text2 = text2 + array[array.Length - 1] + " ";
				}
				else
				{
					text2 += array[array.Length - 1];
				}
				this.richTextBox1.Text = text2;
			}
			Application.DoEvents();
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonVoice_Click(object sender, EventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			HelpWin32.SendMessage(StaticValue.mainhandle, 786, 518);
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonFull_Click(object sender, EventArgs e)
		{
			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionAlignment = HelpRepaint.TextAlign.Justify;
			this.richTextBox1.Select(0, 0);
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonspace_Click(object sender, EventArgs e)
		{
			if (this.toolspace)
			{
				this.richTextBox1.SelectAll();
				this.indent_two(0);
				this.richTextBox1.Select(0, 0);
				this.toolspace = false;
			}
			else
			{
				this.richTextBox1.SelectAll();
				this.indent_two(1);
				this.richTextBox1.Select(0, 0);
				this.toolspace = true;
			}
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripButtonSend_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(this.richTextBox1.Text);
			HelpWin32.SendMessage(HelpWin32.GetForegroundWindow(), 786, 530);
			HelpWin32.keybd_event(Keys.ControlKey, 0, 0U, 0U);
			HelpWin32.keybd_event(Keys.V, 0, 0U, 0U);
			HelpWin32.keybd_event(Keys.V, 0, 2U, 0U);
			HelpWin32.keybd_event(Keys.ControlKey, 0, 2U, 0U);
			FmFlags fmFlags = new FmFlags();
			fmFlags.Show();
			fmFlags.DrawStr("已复制");
		}

		public ContextMenuStrip ContextMenuStrip1
		{
			get
			{
				return this.richTextBox1.ContextMenuStrip;
			}
			set
			{
				this.richTextBox1.ContextMenuStrip = value;
			}
		}

		public string Text_flag
		{
			set
			{
				this.txt_flag = value;
				if (this.txt_flag == "天若幽心")
				{
					this.toolStripToolBar.Items.AddRange(new ToolStripItem[]
					{
						this.topmost, this.Fontstyle, this.toolStripButtonBold, this.toolStripButtonColor, this.toolStripButtonLeft, this.toolStripButtonFull, this.toolStripButtonspace, this.toolStripButtonVoice, this.toolStripButtonFind, this.toolStripButtonSend,
						this.toolStripButtonNote, this.toolStripButtonParagraph, this.toolStripButtonFence, this.toolStripButtonSplit, this.toolStripButtonMerge, this.toolStripButtoncheck, this.toolStripButtonTrans
					});
					return;
				}
				this.toolStripToolBar.Items.AddRange(new ToolStripItem[]
				{
					this.languagle, this.Fontstyle, this.toolStripButtonBold, this.toolStripButtonColor, this.toolStripButtonLeft, this.toolStripButtonFull, this.toolStripButtonspace, this.toolStripButtonVoice, this.toolStripButtonFind, this.toolStripButtonSend,
					this.toolStripButtonclose
				});
			}
		}

		public void toolStripButtonclose_Click(object sender, EventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			HelpWin32.SendMessage(HelpWin32.GetForegroundWindow(), 786, 511);
		}

		public void toolStripButtonTrans_Click(object sender, EventArgs e)
		{
			HelpWin32.SendMessage(StaticValue.mainhandle, 786, 512);
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		public void toolStripToolBar_Click(object sender, EventArgs e)
		{
		}

		private void zh_en_Click(object sender, EventArgs e)
		{
			this.zh_en.ForeColor = Color.Red;
			this.zh_jp.ForeColor = Color.Black;
			this.zh_ko.ForeColor = Color.Black;
			StaticValue.zh_en = true;
			StaticValue.zh_jp = false;
			StaticValue.zh_ko = false;
			HelpWin32.SendMessage(StaticValue.mainhandle, 786, 512);
		}

		private void zh_jp_Click(object sender, EventArgs e)
		{
			this.zh_en.ForeColor = Color.Black;
			this.zh_jp.ForeColor = Color.Red;
			this.zh_ko.ForeColor = Color.Black;
			StaticValue.zh_en = false;
			StaticValue.zh_jp = true;
			StaticValue.zh_ko = false;
			HelpWin32.SendMessage(StaticValue.mainhandle, 786, 512);
		}

		private void zh_ko_Click(object sender, EventArgs e)
		{
			this.zh_en.ForeColor = Color.Black;
			this.zh_jp.ForeColor = Color.Black;
			this.zh_ko.ForeColor = Color.Red;
			StaticValue.zh_en = false;
			StaticValue.zh_jp = false;
			StaticValue.zh_ko = true;
			HelpWin32.SendMessage(StaticValue.mainhandle, 786, 512);
		}

		public void font_宋体c(object sender, EventArgs e)
		{
			this.font_宋体.ForeColor = Color.Red;
			this.font_黑体.ForeColor = Color.Black;
			this.font_楷体.ForeColor = Color.Black;
			this.font_微软雅黑.ForeColor = Color.Black;
			this.font_新罗马.ForeColor = Color.Black;
			string text = this.richTextBox1.Text;
			this.richTextBox1.Text = "";
			Font font = new Font("宋体", 16f * Program.factor, GraphicsUnit.Pixel);
			this.richTextBox1.Font = font;
			this.richTextBox1.Text = text;
		}

		public void font_黑体c(object sender, EventArgs e)
		{
			this.font_宋体.ForeColor = Color.Black;
			this.font_黑体.ForeColor = Color.Red;
			this.font_楷体.ForeColor = Color.Black;
			this.font_微软雅黑.ForeColor = Color.Black;
			this.font_新罗马.ForeColor = Color.Black;
			string text = this.richTextBox1.Text;
			this.richTextBox1.Text = "";
			Font font = new Font("黑体", 16f * Program.factor, GraphicsUnit.Pixel);
			this.richTextBox1.Font = font;
			this.richTextBox1.Text = text;
		}

		public void font_楷体c(object sender, EventArgs e)
		{
			this.font_宋体.ForeColor = Color.Black;
			this.font_黑体.ForeColor = Color.Black;
			this.font_楷体.ForeColor = Color.Red;
			this.font_微软雅黑.ForeColor = Color.Black;
			this.font_新罗马.ForeColor = Color.Black;
			string text = this.richTextBox1.Text;
			this.richTextBox1.Text = "";
			Font font = new Font("STKaiti", 16f * Program.factor, GraphicsUnit.Pixel);
			this.richTextBox1.Font = font;
			this.richTextBox1.Text = text;
		}

		public void font_微软雅黑c(object sender, EventArgs e)
		{
			this.font_宋体.ForeColor = Color.Black;
			this.font_黑体.ForeColor = Color.Black;
			this.font_楷体.ForeColor = Color.Black;
			this.font_微软雅黑.ForeColor = Color.Red;
			this.font_新罗马.ForeColor = Color.Black;
			string text = this.richTextBox1.Text;
			this.richTextBox1.Text = "";
			Font font = new Font("微软雅黑", 16f * Program.factor, GraphicsUnit.Pixel);
			this.richTextBox1.Font = font;
			this.richTextBox1.Text = text;
		}

		public void font_新罗马c(object sender, EventArgs e)
		{
			this.font_宋体.ForeColor = Color.Black;
			this.font_黑体.ForeColor = Color.Black;
			this.font_楷体.ForeColor = Color.Black;
			this.font_微软雅黑.ForeColor = Color.Black;
			this.font_新罗马.ForeColor = Color.Red;
			string text = this.richTextBox1.Text;
			this.richTextBox1.Text = "";
			Font font = new Font("Times New Roman", 16f * Program.factor, GraphicsUnit.Pixel);
			this.richTextBox1.Font = font;
			this.richTextBox1.Text = text;
		}

		public void indent_two(int fla)
		{
			Font font = new Font(this.Font.Name, 9f * Program.factor, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
			Graphics graphics = base.CreateGraphics();
			SizeF sizeF = graphics.MeasureString("中", font);
			this.richTextBox1.SelectionIndent = (int)sizeF.Width * 2 * fla;
			this.richTextBox1.SelectionHangingIndent = -(int)sizeF.Width * 2 * fla;
			graphics.Dispose();
		}

		private void richeditbox_TextChanged(object sender, EventArgs e)
		{
			this.c.execute(this.richTextBox1.Text);
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		public string SelectText
		{
			get
			{
				return this.richTextBox1.SelectedText;
			}
		}

		private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			if (e.Control && e.KeyCode == Keys.V)
			{
				e.SuppressKeyPress = true;
				this.richTextBox1.Paste(DataFormats.GetFormat(DataFormats.Text));
			}
			if (e.Control && e.KeyCode == Keys.Z)
			{
				this.c.undo();
				this.richTextBox1.Text = this.c.Record;
			}
			if (e.Control && e.KeyCode == Keys.Y)
			{
				this.c.redo();
				this.richTextBox1.Text = this.c.Record;
			}
			if (e.Control && e.KeyCode == Keys.F)
			{
				ReplaceForm replaceForm = new ReplaceForm(this);
				if (this.txt_flag == "天若幽心")
				{
					replaceForm.Text = "识别替换";
					replaceForm.Location = base.PointToScreen(new Point((base.Width - replaceForm.Width) / 2, (base.Height - replaceForm.Height) / 2));
				}
				else
				{
					replaceForm.Text = "翻译替换";
					replaceForm.Location = base.PointToScreen(new Point((base.Width - replaceForm.Width) / 2, (base.Height - replaceForm.Height) / 2));
				}
				replaceForm.Show(this);
			}
		}

		public string Find
		{
			set
			{
				new Thread(new ThreadStart(this.错别字检查API)).Start();
				HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			}
		}

		public void 错别字检查API()
		{
			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionColor = Color.Black;
			this.richTextBox1.Select(0, 0);
			try
			{
				JArray jarray = JArray.Parse(((JObject)JsonConvert.DeserializeObject(this.Post_Html("http://www.cuobiezi.net/api/v1/zh_spellcheck/client/pos/json", "{\"check_mode\": \"value2\",\"content\": \"" + this.richTextBox1.Text + "\", \"content2\": \"value1\",  \"doc_type\": \"value2\",\"method\": \"value2\",\"return_format\": \"value2\",\"username\": \"tianruoyouxin\"}")))["Cases"].ToString());
				for (int i = 0; i < jarray.Count; i++)
				{
					JObject jobject = JObject.Parse(jarray[i].ToString());
					int num = 0;
					int length = this.richTextBox1.Text.Length;
					for (int num2 = this.richTextBox1.Find(jobject["Error"].ToString(), num, length, RichTextBoxFinds.None); num2 != -1; num2 = this.richTextBox1.Find(jobject["Error"].ToString(), num, length, RichTextBoxFinds.None))
					{
						this.richTextBox1.SelectionColor = Color.Red;
						num = num2 + jobject["Error"].ToString().Length;
					}
				}
				this.richTextBox1.Select(0, 0);
			}
			catch
			{
				this.richTextBox1.Select(0, 0);
			}
		}

		public string Post_Html(string url, string post_str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(post_str);
			string text = "";
			HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
			httpWebRequest.Method = "POST";
			httpWebRequest.Timeout = 3000;
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.Headers.Add("Accept-Encoding: gzip, deflate");
			httpWebRequest.Headers.Add("Accept-Language: zh-CN,en,*");
			try
			{
				using (Stream requestStream = httpWebRequest.GetRequestStream())
				{
					requestStream.Write(bytes, 0, bytes.Length);
				}
				Stream responseStream = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
				text = streamReader.ReadToEnd();
				responseStream.Close();
				streamReader.Close();
				httpWebRequest.Abort();
			}
			catch
			{
			}
			return text;
		}

		public void richtextbox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			}
		}

		public void toolStripButtonNote_Click(object sender, EventArgs e)
		{
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
			HelpWin32.SendMessage(StaticValue.mainhandle, 786, 520);
			HelpWin32.SetForegroundWindow(StaticValue.mainhandle);
		}

		private void Form1_MouseEnter(object sender, EventArgs e)
		{
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				StaticValue.image_OCR = Image.FromFile((e.Data.GetData(DataFormats.FileDrop, false) as string[])[0]);
				HelpWin32.SendMessage(StaticValue.mainhandle, 786, 580);
			}
			catch (Exception)
			{
				MessageBox.Show("文件格式不正确！", "提醒");
			}
		}

		public static bool contain_en(string str)
		{
			return Regex.IsMatch(str, "[a-zA-Z]");
		}

		public void TextBox1TextChanged(object sender, EventArgs e)
		{
			this.c.execute(this.richTextBox1.Text);
		}

		public new string Hide
		{
			set
			{
				this.richTextBox1.Focus();
				this.mode.HideDropDown();
				this.Fontstyle.HideDropDown();
				this.languagle.HideDropDown();
			}
		}

		public void toolStripButtonSplit_keydown(object sender, MouseEventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Right)
			{
				if (!this.splitcolor)
				{
					this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit_2.Image");
					this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge.Image");
					this.splitcolor = true;
					this.mergecolor = false;
					StaticValue.set_拆分 = true;
					StaticValue.set_合并 = false;
					IniHelp.SetValue("工具栏", "拆分", "True");
					IniHelp.SetValue("工具栏", "合并", "False");
					return;
				}
				if (this.splitcolor)
				{
					this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge.Image");
					this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit.Image");
					this.splitcolor = false;
					this.mergecolor = false;
					StaticValue.set_拆分 = false;
					StaticValue.set_合并 = false;
					IniHelp.SetValue("工具栏", "合并", "False");
					IniHelp.SetValue("工具栏", "拆分", "False");
				}
			}
		}

		public void toolStripButtonMerge_keydown(object sender, MouseEventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Right)
			{
				if (!this.mergecolor)
				{
					this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge_2.Image");
					this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit.Image");
					this.splitcolor = false;
					this.mergecolor = true;
					StaticValue.set_拆分 = false;
					StaticValue.set_合并 = true;
					IniHelp.SetValue("工具栏", "合并", "True");
					IniHelp.SetValue("工具栏", "拆分", "False");
					return;
				}
				if (this.mergecolor)
				{
					this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge.Image");
					this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit.Image");
					this.splitcolor = false;
					this.mergecolor = false;
					StaticValue.set_拆分 = false;
					StaticValue.set_合并 = false;
					IniHelp.SetValue("工具栏", "合并", "False");
					IniHelp.SetValue("工具栏", "拆分", "False");
				}
			}
		}

		public void topmost_keydown(object sender, MouseEventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Left)
			{
				if (!this.topmost_flag)
				{
					this.topmost.Image = (Image)componentResourceManager.GetObject("main.Image");
					StaticValue.v_topmost = true;
					this.topmost_flag = true;
					IniHelp.SetValue("工具栏", "顶置", "True");
					HelpWin32.SendMessage(StaticValue.mainhandle, 600, 725);
					return;
				}
				this.topmost.Image = (Image)componentResourceManager.GetObject("mode.Image");
				StaticValue.v_topmost = false;
				this.topmost_flag = false;
				IniHelp.SetValue("工具栏", "顶置", "False");
				HelpWin32.SendMessage(StaticValue.mainhandle, 600, 725);
			}
		}

		public void readIniFile()
		{
			string value = IniHelp.GetValue("工具栏", "顶置");
			if (IniHelp.GetValue("工具栏", "顶置") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "顶置", "False");
			}
			try
			{
				this.topmost_flag = bool.Parse(value);
			}
			catch
			{
				IniHelp.SetValue("工具栏", "顶置", "True");
				this.topmost_flag = true;
			}
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (this.topmost_flag)
			{
				this.topmost.Image = (Image)componentResourceManager.GetObject("main.Image");
				StaticValue.v_topmost = true;
			}
			if (!this.topmost_flag)
			{
				this.topmost.Image = (Image)componentResourceManager.GetObject("mode.Image");
				StaticValue.v_topmost = false;
			}
			if (IniHelp.GetValue("工具栏", "合并") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "合并", "False");
			}
			this.mergecolor = bool.Parse(IniHelp.GetValue("工具栏", "合并"));
			if (IniHelp.GetValue("工具栏", "拆分") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "拆分", "False");
			}
			this.splitcolor = bool.Parse(IniHelp.GetValue("工具栏", "拆分"));
			if (IniHelp.GetValue("工具栏", "检查") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "检查", "False");
			}
			this.checkcolor = bool.Parse(IniHelp.GetValue("工具栏", "检查"));
			if (IniHelp.GetValue("工具栏", "翻译") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "翻译", "False");
			}
			this.transcolor = bool.Parse(IniHelp.GetValue("工具栏", "翻译"));
			if (IniHelp.GetValue("工具栏", "分段") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "分段", "False");
			}
			this.Paragraphcolor = bool.Parse(IniHelp.GetValue("工具栏", "分段"));
			if (IniHelp.GetValue("工具栏", "分栏") == "发生错误")
			{
				IniHelp.SetValue("工具栏", "分栏", "False");
			}
			this.Fencecolor = bool.Parse(IniHelp.GetValue("工具栏", "分栏"));
			if (this.Fencecolor)
			{
				this.toolStripButtonFence.Image = (Image)componentResourceManager.GetObject("toolStripButtonFence2.Image");
			}
			else
			{
				this.toolStripButtonFence.Image = (Image)componentResourceManager.GetObject("toolStripButtonFence.Image");
			}
			if (this.Paragraphcolor)
			{
				this.toolStripButtonParagraph.Image = (Image)componentResourceManager.GetObject("toolStripButtonParagraph2.Image");
			}
			else
			{
				this.toolStripButtonParagraph.Image = (Image)componentResourceManager.GetObject("toolStripButtonParagraph.Image");
			}
			if (this.checkcolor)
			{
				this.toolStripButtoncheck.Image = (Image)componentResourceManager.GetObject("toolStripButtoncheck2.Image");
			}
			else
			{
				this.toolStripButtoncheck.Image = (Image)componentResourceManager.GetObject("toolStripButtoncheck.Image");
			}
			if (this.mergecolor)
			{
				this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge_2.Image");
			}
			else
			{
				this.toolStripButtonMerge.Image = (Image)componentResourceManager.GetObject("toolStripButtonMerge.Image");
			}
			if (this.splitcolor)
			{
				this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit_2.Image");
			}
			else
			{
				this.toolStripButtonSplit.Image = (Image)componentResourceManager.GetObject("toolStripButtonSplit.Image");
			}
			if (this.transcolor)
			{
				this.toolStripButtonTrans.Image = (Image)componentResourceManager.GetObject("toolStripButtonTrans2.Image");
				return;
			}
			this.toolStripButtonTrans.Image = (Image)componentResourceManager.GetObject("toolStripButtonTrans.Image");
		}

		public void saveIniFile()
		{
			IniHelp.SetValue("工具栏", "顶置", this.topmost_flag.ToString());
		}

		public void toolStripButtoncheck_keydown(object sender, MouseEventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Right)
			{
				if (!this.checkcolor)
				{
					this.toolStripButtoncheck.Image = (Image)componentResourceManager.GetObject("toolStripButtoncheck2.Image");
					this.checkcolor = true;
					IniHelp.SetValue("工具栏", "检查", "True");
					return;
				}
				if (this.checkcolor)
				{
					this.toolStripButtoncheck.Image = (Image)componentResourceManager.GetObject("toolStripButtoncheck.Image");
					this.checkcolor = false;
					IniHelp.SetValue("工具栏", "检查", "False");
				}
			}
		}

		public void toolStripButtontrans_keydown(object sender, MouseEventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Right)
			{
				if (!this.transcolor)
				{
					this.toolStripButtonTrans.Image = (Image)componentResourceManager.GetObject("toolStripButtonTrans2.Image");
					this.transcolor = true;
					IniHelp.SetValue("工具栏", "翻译", "True");
					return;
				}
				if (this.transcolor)
				{
					this.toolStripButtonTrans.Image = (Image)componentResourceManager.GetObject("toolStripButtonTrans.Image");
					this.transcolor = false;
					IniHelp.SetValue("工具栏", "翻译", "False");
				}
			}
		}

		public void toolStripButtonParagraph_keydown(object sender, MouseEventArgs e)
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Right)
			{
				if (!this.Paragraphcolor)
				{
					this.toolStripButtonParagraph.Image = (Image)componentResourceManager.GetObject("toolStripButtonParagraph2.Image");
					this.Paragraphcolor = true;
					IniHelp.SetValue("工具栏", "分段", "True");
					return;
				}
				if (this.Paragraphcolor)
				{
					this.toolStripButtonParagraph.Image = (Image)componentResourceManager.GetObject("toolStripButtonParagraph.Image");
					this.Paragraphcolor = false;
					IniHelp.SetValue("工具栏", "分段", "False");
				}
			}
		}

		public void toolStripButtonFence_keydown(object sender, MouseEventArgs e)
		{
			if (!File.Exists("cvextern.dll"))
			{
				MessageBox.Show("请从蓝奏网盘中下载cvextern.dll大小约25m，点击确定自动弹出网页。\r\n将下载后的文件与 天若.exe 这个文件放在一起。");
				Process.Start("https://www.lanzous.com/i1ab3vg");
				return;
			}
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvRichTextBox));
			if (e.Button == MouseButtons.Right)
			{
				if (!this.Fencecolor)
				{
					this.toolStripButtonFence.Image = (Image)componentResourceManager.GetObject("toolStripButtonFence2.Image");
					this.Fencecolor = true;
					IniHelp.SetValue("工具栏", "分栏", "True");
					return;
				}
				if (this.Fencecolor)
				{
					this.toolStripButtonFence.Image = (Image)componentResourceManager.GetObject("toolStripButtonFence.Image");
					this.Fencecolor = false;
					IniHelp.SetValue("工具栏", "分栏", "False");
				}
			}
		}

		public string Rtf
		{
			set
			{
				this.richTextBox1.Rtf = value;
			}
		}

		public string rtf
		{
			get
			{
				return this.richTextBox1.Rtf;
			}
			set
			{
				this.richTextBox1.Rtf = value;
			}
		}

		public string set_language
		{
			set
			{
				if (value == "中英")
				{
					this.zh_en.ForeColor = Color.Red;
					this.zh_jp.ForeColor = Color.Black;
					this.zh_ko.ForeColor = Color.Black;
				}
				if (value == "日语")
				{
					this.zh_en.ForeColor = Color.Black;
					this.zh_jp.ForeColor = Color.Red;
					this.zh_ko.ForeColor = Color.Black;
				}
				if (value == "韩语")
				{
					this.zh_en.ForeColor = Color.Black;
					this.zh_jp.ForeColor = Color.Black;
					this.zh_ko.ForeColor = Color.Red;
				}
			}
		}

		public IContainer components;

		public ToolStripButton toolStripButtonclose;

		public ToolStripButton toolStripButtonBold;

		public ToolStripButton toolStripButtonParagraph;

		public ToolStripButton toolStripButtonFind;

		public ToolStripSeparator toolStripSeparatorFont;

		public ToolStripButton toolStripButtonFence;

		public ToolStripButton toolStripButtonSplit;

		public ToolStripButton toolStripButtoncheck;

		public ToolStripButton toolStripButtonIndent;

		public ToolStripSeparator toolStripSeparatorFormat;

		public ToolStripButton toolStripButtonLeft;

		public ToolStripButton toolStripButtonMerge;

		public ToolStripButton toolStripButtonVoice;

		public ToolStripButton toolStripButtonFull;

		public ToolStripSeparator toolStripSeparatorAlign;

		public ToolStripButton toolStripButtonspace;

		public ToolStripButton toolStripButtonR_arow;

		public ToolStripButton toolStripButtonSend;

		public int dataUpdate;

		public bool toolspace;

		public string txt_flag;

		public ToolStripButton toolStripButtonTrans;

		public bool toolFull;

		public ToolStripDropDownButton languagle;

		public ToolStripMenuItem zh_jp;

		public ToolStripMenuItem zh_ko;

		public ToolStripMenuItem zh_en;

		public ToolStripDropDownButton mode;

		private ToolStripMenuItem mode_顶置;

		private ToolStripMenuItem mode_正常;

		private ToolStripMenuItem mode_合并;

		public ToolStripDropDownButton Fontstyle;

		private ToolStripMenuItem font_宋体;

		private ToolStripMenuItem font_楷体;

		private ToolStripMenuItem font_黑体;

		private ToolStripMenuItem font_微软雅黑;

		private ToolStripMenuItem font_新罗马;

		public HelpRepaint.ColorPicker toolStripButtonColor;

		public RichTextBoxEx richTextBox1;

		public HelpRepaint.ToolStripEx toolStripToolBar;

		private ToolStripButton toolStripButtonNote;

		private AdvRichTextBox.cmd c;

		public bool splitcolor;

		public bool mergecolor;

		public ToolStripButton topmost;

		public bool topmost_flag;

		public bool checkcolor;

		public bool transcolor;

		public bool Paragraphcolor;

		public bool Fencecolor;

		public class cmd
		{
			public cmd(int _undoCount)
			{
				this.undoCount = _undoCount + 1;
				this.undoList.Add("");
			}

			public void execute(string command)
			{
				this.temp = command;
				if (!this.und)
				{
					this.undoList.Add(command);
					if (this.undoCount != -1 && this.undoList.Count > this.undoCount)
					{
						this.undoList.RemoveAt(0);
						return;
					}
				}
				else
				{
					this.und = false;
				}
			}

			public void undo()
			{
				if (this.undoList.Count > 1)
				{
					this.und = true;
					this.redoList.Add(this.undoList[this.undoList.Count - 1]);
					this.undoList.RemoveAt(this.undoList.Count - 1);
					this.temp = this.undoList[this.undoList.Count - 1];
				}
			}

			public void redo()
			{
				if (this.redoList.Count > 0)
				{
					this.temp = this.redoList[this.redoList.Count - 1];
					this.redoList.RemoveAt(this.redoList.Count - 1);
				}
			}

			public string Record
			{
				get
				{
					return this.temp;
				}
			}

			private List<string> undoList = new List<string>();

			private List<string> redoList = new List<string>();

			private int undoCount = -1;

			private bool und;

			private string temp;
		}
	}
}
