using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace FakeService
{
    public partial class FakeService : ServiceBase
    {
        public FakeService()
        {
            InitializeComponent();
        }

        private Timer _timer;

        protected override void OnStart(string[] args)
        {
            var interval = int.Parse(ConfigurationManager.AppSettings["TimerInterval"]);

            _timer = new Timer(interval);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            if (_timer != null)
                _timer.Stop();
        }
    }
}
