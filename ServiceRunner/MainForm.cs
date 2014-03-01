using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceRunner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var service = (ServiceWrapper)cbServices.SelectedValue;

            var logs = ServiceHelper.StartService(service);
            tbLogs.AppendText(logs);

            cbServices.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var service = (ServiceWrapper)cbServices.SelectedValue;

            var logs = ServiceHelper.StopService(service.Service);
            tbLogs.AppendText(logs);

            cbServices.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var solutionFolder = Application.StartupPath.Remove(Application.StartupPath.LastIndexOf("ServiceRunner"));

            var services = new List<Tuple<string, ServiceWrapper>>();
            services.Add(new Tuple<string, ServiceWrapper>("Fake Service", new ServiceWrapper
            {
                Service = new FakeService.FakeService(),
                Path = Path.Combine(solutionFolder, @"FakeService\App.config")
            }));

            cbServices.DisplayMember = "item1";
            cbServices.ValueMember = "item2";
            cbServices.DataSource = services;
        }
    }
}
