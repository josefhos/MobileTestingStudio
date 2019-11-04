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
            var mobiles = mobileManager.LoadAllMobiles();

            ShowInConsole(mobiles);

            var mobile = mobiles.Where(x => x.System == MobileSystem.iOS).SingleOrDefault();
            mobileManager.DeleteMobile(mobile.Id);

            ShowInConsole(mobileManager.LoadAllMobiles());
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
        }
    }
}
