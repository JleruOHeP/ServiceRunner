using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServiceRunner
{
    public class ServiceHelper
    {
        public static string StopService(ServiceBase service)
        {
            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop", BindingFlags.Instance | BindingFlags.NonPublic);

            var result = string.Format("Stopping {0}...\r\n", service.ServiceName);
            onStopMethod.Invoke(service, null);

            result += "Stopped\r\n";

            return result;
        }

        public static string StartService(ServiceWrapper service)
        {
            LoadAppConfig(service.Path);

            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic);

            var result = string.Format("Starting {0}...\r\n", service.Service.ServiceName);
            onStartMethod.Invoke(service.Service, new object[] { new string[] { } });

            result += "Started\r\n";

            return result;
        }

        public static void LoadAppConfig(string path)
        {
            var newConfigDoc = new XmlDocument();
            newConfigDoc.Load(path);
            newConfigDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlNode node in newConfigDoc.SelectSingleNode("configuration").ChildNodes)
            {
                ConfigurationManager.RefreshSection(node.Name);
            }
        }
    }
}
