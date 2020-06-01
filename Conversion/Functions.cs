using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Conversion
{
	// Token: 0x02000003 RID: 3
	internal class Functions
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002264 File Offset: 0x00000464
		public static string ConvertArgs(string argstring)
		{
			string[] array = argstring.Replace("(", "").Replace(")", "").Split(new char[]
			{
				','
			});
			string text = "";
			foreach (string text2 in array)
			{
				string text3 = text2.Trim();
				bool flag = new Regex("\".+\"").IsMatch(text3);
				if (flag)
				{
					text += string.Format("pushstring({0})\r\n", text3);
				}
				else
				{
					bool flag2 = double.TryParse(text3, out Functions.Ignored<double>.Ignore);
					if (flag2)
					{
						text += string.Format("pushnumber({0})\r\n", text3);
					}
					else
					{
						bool flag3 = bool.TryParse(text3, out Functions.Ignored<bool>.Ignore);
						if (flag3)
						{
							text += string.Format("pushboolean(\"{0}\")\r\n", text3);
						}
					}
				}
			}
			return text;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002350 File Offset: 0x00000550
		public static string ConvertString(string input)
		{
			string[] array = input.Split("\r\n".ToCharArray());
			string text = "";
			foreach (string text2 in array)
			{
				string[] array3 = text2.Split(new char[]
				{
					'.'
				});
				bool flag = text2.Contains("=");
				if (flag)
				{
					string[] array4 = text2.Split(new char[]
					{
						'='
					})[0].Trim().Split(new char[]
					{
						'.'
					});
					string[] array5 = text2.Split(new char[]
					{
						'='
					})[1].Trim().Split(new char[]
					{
						'.'
					});
					bool flag2 = false;
					string argstring = "";
					foreach (string text3 in array5)
					{
						bool flag3 = array5.Length == 1;
						if (flag3)
						{
							flag2 = true;
							argstring = text3;
							break;
						}
						bool flag4 = text3 == "";
						if (flag4)
						{
							text += "\b\r\n";
						}
						else
						{
							bool flag5 = text3.Contains(':') && text3 == array5.First<string>();
							if (flag5)
							{
								string[] array7 = text3.Split(new char[]
								{
									':'
								});
								foreach (string text4 in array7)
								{
									bool flag6 = text4 == array7.First<string>();
									if (flag6)
									{
										text += string.Format("getglobal(\"{0}\")\r\n", Regex.Replace(text4, "\\(([^)]*)\\)", ""));
									}
									else
									{
										text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text4, "\\(([^)]*)\\)", ""));
									}
									bool flag7 = text4.Contains("()");
									if (flag7)
									{
										text += "pushvalue(-2)\r\npcall(1,1,0)\r\n";
									}
									else
									{
										bool flag8 = Regex.IsMatch(text4, "\\(([^)]*)\\)");
										if (flag8)
										{
											text = text + "pushvalue(-2)\r\n" + Functions.ConvertArgs(Regex.Match(text4, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text4, "\\(([^)]*)\\)").ToString().Split(new char[]
											{
												','
											}).Length + 1);
										}
									}
								}
							}
							else
							{
								bool flag9 = text3.Contains(':');
								if (flag9)
								{
									string[] array9 = text3.Split(new char[]
									{
										':'
									});
									foreach (string text5 in array9)
									{
										text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text5, "\\(([^)]*)\\)", ""));
										bool flag10 = text5.Contains("()");
										if (flag10)
										{
											text += "pushvalue(-2)\r\npcall(1,1,0)\r\n";
										}
										else
										{
											bool flag11 = Regex.IsMatch(text5, "\\(([^)]*)\\)");
											if (flag11)
											{
												text = text + "pushvalue(-2)\r\n" + Functions.ConvertArgs(Regex.Match(text5, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text5, "\\(([^)]*)\\)").ToString().Split(new char[]
												{
													','
												}).Length + 1);
											}
										}
									}
								}
								else
								{
									bool flag12 = text3 == array5.First<string>();
									if (flag12)
									{
										text += string.Format("getglobal(\"{0}\")\r\n", Regex.Replace(text3, "\\(([^)]*)\\)", ""));
									}
									else
									{
										text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text3, "\\(([^)]*)\\)", ""));
									}
									bool flag13 = text3.Contains("()");
									if (flag13)
									{
										text += "pcall(1,1,0)\r\n";
									}
									else
									{
										bool flag14 = Regex.IsMatch(text3, "\\(([^)]*)\\)");
										if (flag14)
										{
											text = text + Functions.ConvertArgs(Regex.Match(text3, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text3, "\\(([^)]*)\\)").ToString().Split(new char[]
											{
												','
											}).Length);
										}
									}
								}
							}
						}
					}
					int num = 0;
					foreach (string text6 in array4)
					{
						bool flag15 = text6 == "";
						if (flag15)
						{
							text += "\b\r\n";
						}
						else
						{
							num++;
							bool flag16 = text6 == array4.Last<string>();
							if (flag16)
							{
								bool flag17 = flag2;
								if (flag17)
								{
									text = text + Functions.ConvertArgs(argstring) + string.Format("setfield(-2, \"{0}\")\r\n", array4.Last<string>().Trim());
								}
								else
								{
									text = text + string.Format("pushvalue(-{0})\r\n", num) + string.Format("setfield(-2, \"{0}\")\r\n", array4.Last<string>().Trim());
								}
							}
							else
							{
								bool flag18 = text6.Contains(':') && text6 == array4.First<string>();
								if (flag18)
								{
									string[] array12 = text6.Split(new char[]
									{
										':'
									});
									foreach (string text7 in array12)
									{
										bool flag19 = text7 == array12.First<string>();
										if (flag19)
										{
											text += string.Format("getglobal(\"{0}\")\r\n", Regex.Replace(text7, "\\(([^)]*)\\)", ""));
										}
										else
										{
											text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text7, "\\(([^)]*)\\)", ""));
										}
										bool flag20 = text7.Contains("()");
										if (flag20)
										{
											text += "pushvalue(-2)\r\npcall(1,1,0)\r\n";
										}
										else
										{
											bool flag21 = Regex.IsMatch(text7, "\\(([^)]*)\\)");
											if (flag21)
											{
												text = text + "pushvalue(-2)\r\n" + Functions.ConvertArgs(Regex.Match(text7, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text7, "\\(([^)]*)\\)").ToString().Split(new char[]
												{
													','
												}).Length + 1);
											}
										}
									}
								}
								else
								{
									bool flag22 = text6.Contains(':');
									if (flag22)
									{
										string[] array14 = text6.Split(new char[]
										{
											':'
										});
										foreach (string text8 in array14)
										{
											text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text8, "\\(([^)]*)\\)", ""));
											bool flag23 = text8.Contains("()");
											if (flag23)
											{
												text += "pushvalue(-2)\r\npcall(1,1,0)\r\n";
											}
											else
											{
												bool flag24 = Regex.IsMatch(text8, "\\(([^)]*)\\)");
												if (flag24)
												{
													text = text + "pushvalue(-2)\r\n" + Functions.ConvertArgs(Regex.Match(text8, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text8, "\\(([^)]*)\\)").ToString().Split(new char[]
													{
														','
													}).Length + 1);
												}
											}
										}
									}
									else
									{
										bool flag25 = text6 == array4.First<string>();
										if (flag25)
										{
											text += string.Format("getglobal(\"{0}\")\r\n", Regex.Replace(text6, "\\(([^)]*)\\)", ""));
										}
										else
										{
											text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text6, "\\(([^)]*)\\)", ""));
										}
										bool flag26 = text6.Contains("()");
										if (flag26)
										{
											text += "pcall(1,1,0)\r\n";
										}
										else
										{
											bool flag27 = Regex.IsMatch(text6, "\\(([^)]*)\\)");
											if (flag27)
											{
												text = text + Functions.ConvertArgs(Regex.Match(text6, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text6, "\\(([^)]*)\\)").ToString().Split(new char[]
												{
													','
												}).Length);
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					foreach (string text9 in array3)
					{
						bool flag28 = text9 == "";
						if (flag28)
						{
							text += "\b\r\n";
						}
						else
						{
							bool flag29 = text9.Contains(':') && text9 == array3.First<string>();
							if (flag29)
							{
								string[] array17 = text9.Split(new char[]
								{
									':'
								});
								foreach (string text10 in array17)
								{
									bool flag30 = text10 == array17.First<string>();
									if (flag30)
									{
										text += string.Format("getglobal(\"{0}\")\r\n", Regex.Replace(text10, "\\(([^)]*)\\)", ""));
									}
									else
									{
										text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text10, "\\(([^)]*)\\)", ""));
									}
									bool flag31 = text10.Contains("()");
									if (flag31)
									{
										text += "pushvalue(-2)\r\npcall(1,1,0)\r\n";
									}
									else
									{
										bool flag32 = Regex.IsMatch(text10, "\\(([^)]*)\\)");
										if (flag32)
										{
											text = text + "pushvalue(-2)\r\n" + Functions.ConvertArgs(Regex.Match(text10, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text10, "\\(([^)]*)\\)").ToString().Split(new char[]
											{
												','
											}).Length + 1);
										}
									}
								}
							}
							else
							{
								bool flag33 = text9.Contains(':');
								if (flag33)
								{
									string[] array19 = text9.Split(new char[]
									{
										':'
									});
									foreach (string text11 in array19)
									{
										text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text11, "\\(([^)]*)\\)", ""));
										bool flag34 = text11.Contains("()");
										if (flag34)
										{
											text += "pushvalue(-2)\r\npcall(1,1,0)\r\n";
										}
										else
										{
											bool flag35 = Regex.IsMatch(text11, "\\(([^)]*)\\)");
											if (flag35)
											{
												text = text + "pushvalue(-2)\r\n" + Functions.ConvertArgs(Regex.Match(text11, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text11, "\\(([^)]*)\\)").ToString().Split(new char[]
												{
													','
												}).Length + 1);
											}
										}
									}
								}
								else
								{
									bool flag36 = text9 == array3.First<string>();
									if (flag36)
									{
										text += string.Format("getglobal(\"{0}\")\r\n", Regex.Replace(text9, "\\(([^)]*)\\)", ""));
									}
									else
									{
										text += string.Format("getfield(-1, \"{0}\")\r\n", Regex.Replace(text9, "\\(([^)]*)\\)", ""));
									}
									bool flag37 = text9.Contains("()");
									if (flag37)
									{
										text += "pcall(1,1,0)\r\n";
									}
									else
									{
										bool flag38 = Regex.IsMatch(text9, "\\(([^)]*)\\)");
										if (flag38)
										{
											text = text + Functions.ConvertArgs(Regex.Match(text9, "\\(([^)]*)\\)").ToString()) + string.Format("pcall({0},1,0)\r\n", Regex.Match(text9, "\\(([^)]*)\\)").ToString().Split(new char[]
											{
												','
											}).Length);
										}
									}
								}
							}
						}
					}
				}
			}
			return text;
		}

		// Token: 0x02000009 RID: 9
		public static class Ignored<T>
		{
			// Token: 0x0400000E RID: 14
			[ThreadStatic]
			public static T Ignore;
		}
	}
}
