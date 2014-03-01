using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRunner
{
    public class ServiceWrapper
    {
        public string Path { get; set; }

        public ServiceBase Service { get; set; }
    }
}
