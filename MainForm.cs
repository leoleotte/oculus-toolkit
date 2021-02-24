using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace Oculus_Toolkit
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				CheckOculusService();
			} catch (Exception exp)
			{
				ShowErrorDialog(exp);
			}
		}

		private void CheckOculusService()
		{
			var ctl = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == "OVRService");
			if (ctl != null)
				throw new Exception("Oculus service was not found! ('OVRService')");
		}

		private void ShowErrorDialog(Exception exception)
		{
			Debug.WriteLine(exception.ToString());

			MessageBox.Show(exception.Message, "Error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
