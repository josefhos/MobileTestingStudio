using System;
using System.Collections.Generic;
using System.Linq;
using MobileTestingStudio.Enums;
using MobileTestingStudio.Interfaces;

namespace MobileTestingStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mobile Testing Studio!");
            var mobileManager = new MobileManager();

            // AddDummyMobiles(mobileManager);

            Console.WriteLine("Getting mobiles by OS = Android...");
            var androidMobiles = mobileManager.GetAllMobilesBySystem(MobileSystem.Android);
            ShowInConsole(androidMobiles);

            Console.WriteLine("Getting mobiles that are available...");
            var availableMobiles = mobileManager.GetConnectedMobiles();
            ShowInConsole(availableMobiles);

            //delete
            // Console.WriteLine("Deleting first Android mobile from the list.");
            // mobileManager.DeleteMobile(androidMobiles.First().Id);
            // mobileManager.StoreMobiles();
            // var androidMobilesAfterDelete = mobileManager.GetAllMobilesBySystem(MobileSystem.Android);
            // Console.WriteLine("Updated list of Android mobiles.");
            // ShowInConsole(androidMobilesAfterDelete);

            //disconnect
            var voknoMobileConnected = mobileManager.GetAllMobilesByName("vokno").First();
            Console.WriteLine($"Disconnecting mobile name Vokno\r\nId: {voknoMobileConnected.Id}; Name: {voknoMobileConnected.Name}; isAvailable: {voknoMobileConnected.IsAvailable}");
            mobileManager.DisconnectMobile(voknoMobileConnected.Id);
            mobileManager.StoreMobiles();
            var voknoMobileDisconnected = mobileManager.GetAllMobilesByName("vokno").First();
            Console.WriteLine($"State for mobile Vokno\r\nId: {voknoMobileDisconnected.Id}; Name: {voknoMobileDisconnected.Name}; isAvailable: {voknoMobileDisconnected.IsAvailable}");

            //connect back
            mobileManager.ConnectMobile(voknoMobileDisconnected.Id);
            mobileManager.StoreMobiles();
            var voknoMobileConnectedBack = mobileManager.GetAllMobilesByName("vokno").First();
            Console.WriteLine($"State for mobile Vokno\r\nId: {voknoMobileConnectedBack.Id}; Name: {voknoMobileConnectedBack.Name}; isAvailable: {voknoMobileConnectedBack.IsAvailable}");
        }

        private static void ShowInConsole(IEnumerable<IMobile> mobiles)
        {
            int position = 0;
            foreach (Mobile mobile in mobiles)
            {
                Console.WriteLine($"#{position++} Id: {mobile.Id}; Name: {mobile.Name}; " +
                    $"System and version: {mobile.System} {mobile.Version}; " +
                    $"IsAvailable?: {mobile.IsAvailable}");
            }
            Console.WriteLine("\r\n");
        }

        private static void AddDummyMobiles(MobileManager mobileManager)
        {
                mobileManager.CreateMobile(MobileSystem.Android, "Androidik", "1.0");
                mobileManager.CreateMobile(MobileSystem.iOS, "Jablko", "2.0");
                mobileManager.CreateMobile(MobileSystem.Android, "Ufoun", "1.0");
                mobileManager.CreateMobile(MobileSystem.Windows, "Vokno", "0.1");
                mobileManager.CreateMobile(MobileSystem.Android, "Droid", "1.1");
                mobileManager.StoreMobiles();
                // return mobileManager.LoadAllMobiles();
        }
    }
}
