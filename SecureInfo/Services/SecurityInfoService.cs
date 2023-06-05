using Microsoft.Win32;
using SecureInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


using System.Management;
using NetFwTypeLib;
using WUApiLib;

namespace SecureInfo.Services
{
    class SecurityInfoService
    {
        public List<FirewallRule> GetFirewallRules()
        {
            List<FirewallRule> firewallRules = new List<FirewallRule>();


            Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(type);

            foreach (INetFwRule rule in fwPolicy.Rules)
            {
                firewallRules.Add( new FirewallRule
                {
                    Name = rule.Name,
                    Description = rule.Description,
                    Enabled = rule.Enabled,
                    Direction = rule.Direction.ToString(),
                    Protocol =  rule.Protocol,
                    LocalAddresses= rule.LocalAddresses,
                    RemoteAddresses= rule.RemoteAddresses,
                    LocalPorts= rule.LocalPorts,
                    RemotePorts= rule.RemotePorts,
                    ApplicationName= rule.ApplicationName
                });
                
            }
            return firewallRules;
        }
        

        public List<Update> GetUpdates()
        {
            int timeoutSeconds = 10;
            var cts = new CancellationTokenSource();
            var updates = new List<Update>();
            cts.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

            try
            {

                var updateSession = new UpdateSession();
                var updateSearcher = updateSession.CreateUpdateSearcher();
                var count = updateSearcher.GetTotalHistoryCount();
                var history = updateSearcher.QueryHistory(0, count);

               for (int i = 0; i < count; ++i)
               {
                   updates.Add(new Update()
                   {
                       Title = history[i].Title,
                       ClientApplicationID = history[i].ClientApplicationID,
                       Date = history[i].Date,
                       Description = history[i].Description,
                       SupportUrl = history[i].SupportUrl

                   });
               } 
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show("Updates not founded!");
            }
            return updates;
        }
        public List<AntiVirusProduct> GetAntivirucesInformation()
        {

            var antiviruses = new List<AntiVirusProduct>();
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection data = wmiData.Get();

            foreach (ManagementObject virusChecker in data)
            {               
               var antivirus = new AntiVirusProduct();              
               antivirus.instanceGuid = virusChecker["instanceGuid"].ToString();
               antivirus.displayName = virusChecker["displayName"].ToString();
               antivirus.pathToSignedProductExe = virusChecker["pathToSignedProductExe"].ToString();
               antivirus.pathToSignedReportingExe = virusChecker["pathToSignedReportingExe"].ToString();
               antivirus.productState = Convert.ToUInt32(virusChecker["productState"].ToString());
               antivirus.timestamp = virusChecker["timestamp"].ToString();

               antiviruses.Add(antivirus);
            }



            return antiviruses;
        }
        public SystemInfo GetOSInfo()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            SystemInfo systemInfo = new SystemInfo();
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject m in searcher.Get())
            {                
                systemInfo.Caption = m["Caption"].ToString();
                systemInfo.Version = m["Version"].ToString();
                systemInfo.CSName =  m["CSName"].ToString();
                systemInfo.OSArchitecture =  m["OSArchitecture"].ToString();
                systemInfo.RegisteredUser = m["RegisteredUser"].ToString();
                systemInfo.SerialNumber = m["SerialNumber"].ToString();
                
            }
            return systemInfo;
        }
        public HardwareInfo GetHardwareInfo()
        {
            return new HardwareInfo
            {
                PhysicalMemory = GetPhysicalMemory(),
                ProcessorInformation = GetProcessorInformation(),
                GPU = GetGPU(),
                BIOScaption = GetBIOScaption(),
                MACAddress = GetMACAddress()
            };
        }

        private static string GetGPU()
        {
            string gpu = "";
            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    gpu =  obj["Name"].ToString();

                }
            }
            return gpu;
        }

        private static string GetPhysicalMemory()
        {
            ManagementScope osmanagesys = new ManagementScope();
            ObjectQuery myobjQry = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            ManagementObjectSearcher oFinder = new ManagementObjectSearcher(osmanagesys, myobjQry);
            ManagementObjectCollection oCollection = oFinder.Get();
            long liveMSize = 0;
            long livecap = 0;
            foreach (ManagementObject obj in oCollection)
            {
                livecap = Convert.ToInt64(obj["Capacity"]);
                liveMSize += livecap;
            }
            liveMSize = (liveMSize / 1024) / 1024;
            return liveMSize.ToString() + "MB";
        }
        private static string GetProcessorInformation()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    return processor_name.GetValue("ProcessorNameString").ToString();
                }
            }
            return "*";

        }
        private static string GetComputerName()
        {
            ManagementClass mancl = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection manageobcl = mancl.GetInstances();
            string info = string.Empty;
            foreach (ManagementObject myObj in manageobcl)
            {
                info = (string)myObj["Name"];
            }
            return info;
        }
        private static string GetCPUManufacturer()
        {
            string robotCpu = string.Empty;
            ManagementClass managemnt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection objCol = managemnt.GetInstances();

            foreach (ManagementObject obj in objCol)
            {
                if (robotCpu == string.Empty)
                {
                    robotCpu = obj.Properties["Manufacturer"].Value.ToString();
                }
            }
            return robotCpu;
        }
        private static string GetBIOScaption()
        {
            ManagementObjectSearcher finder = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject wmi in finder.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();
                }
                catch { }
            }
            return "BIOS Caption: Unknown";
        }
        private static string GetBoardMaker()
        {
            ManagementObjectSearcher finder = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in finder.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "Board Maker: Unknown";
        }
        private static string GetMACAddress()
        {
            ManagementClass mancl = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection manageobcl = mancl.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject myObj in manageobcl)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)myObj["IPEnabled"] == true) MACAddress = myObj["MacAddress"].ToString();
                }
                myObj.Dispose();
            }

            return MACAddress;
        }

        public SecurityInfoService()
        {

        }
    }
}
