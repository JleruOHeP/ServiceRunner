using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using ServiceRunner;

namespace TestServiceRunner
{
	[TestFixture]
	public class ServiceHelperTest
	{
		[Test]
		public void LoadConfigTest()
		{
			ServiceHelper.LoadAppConfig(@"D:\Projects\ServiceRunner\FakeService\app.config");

            Assert.That(ConfigurationManager.AppSettings["TimerInterval"], Is.EqualTo("1000"));
		}
	}
}
