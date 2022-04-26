// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.NetworkInformation;

 string GetDeviceInfo()
{
    string mac = string.Empty;
    string ip = string.Empty;

    foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
    {
        if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
            netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
        {
            var address = netInterface.GetPhysicalAddress();
            mac = BitConverter.ToString(address.GetAddressBytes());

            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
            if (addresses != null && addresses[0] != null)
            {
                ip = addresses[0].ToString();
                break;
            }
        }
    }

    return mac;
}
Console.WriteLine($"MACAddreess :{GetDeviceInfo()}" );
