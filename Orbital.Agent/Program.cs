// See https://aka.ms/new-console-template for more information

using System.Net.NetworkInformation;

var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

foreach (var networkInterface in networkInterfaces)
{
    // 只获取物理接口的 MAC 地址
    if (networkInterface.NetworkInterfaceType is NetworkInterfaceType.Ethernet or NetworkInterfaceType.Wireless80211)
    {
        var macAddress = networkInterface.GetPhysicalAddress();
        var macAddressString = BitConverter.ToString(macAddress.GetAddressBytes());

        Console.WriteLine(macAddressString);
    }
}