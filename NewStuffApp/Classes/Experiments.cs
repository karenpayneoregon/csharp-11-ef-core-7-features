using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NewStuffApp.Classes;
internal class Experiments
{
    public static bool IsVpnConnected()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (ni is { OperationalStatus: OperationalStatus.Up, NetworkInterfaceType: NetworkInterfaceType.Ppp }) // PPP often indicates VPN
            {
                // Additional check: sometimes VPN interfaces have names like "VPN", "Secure", etc.
                string name = ni.Name.ToLower();
                string description = ni.Description.ToLower();
                if (name.Contains("_common_"))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool IsKnownVpnClientRunning()
    {
        var knownClients = new[] { "openvpn", "nordvpn", "expressvpn", "wireguard", "protonvpn" };

        var processes = System.Diagnostics.Process.GetProcesses();
        return processes.Any(p =>
        {
            try
            {
                return knownClients.Any(c => p.ProcessName.ToLower().Contains(c));
            }
            catch
            {
                return false; // Some processes might not let you access their name
            }
        });
    }

}






