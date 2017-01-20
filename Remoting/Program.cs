using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Remoting
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpChannel tcpChannel = new TcpChannel(9999);
			ChannelServices.RegisterChannel(tcpChannel, false);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(SharedDatabase), "SharedDatabase", WellKnownObjectMode.SingleCall);
			Console.WriteLine("Press ENTER to quit");
			Console.ReadLine();
		}
	}
}
