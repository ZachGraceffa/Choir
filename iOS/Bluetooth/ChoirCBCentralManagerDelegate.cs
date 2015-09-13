using System;
using CoreBluetooth;
using Foundation;
using System.Timers;
using UIKit;

namespace Choir.iOS
{
	public class ChoirCBCentralManagerDelegate : CBCentralManagerDelegate
	{
		CBUUID[] cbuuids = null;

		override public void UpdatedState (CBCentralManager mgr)
		{
			Console.WriteLine ("OnCentralManagerUpdatedState()");
			string message = null;

			switch (mgr.State) {
			case CBCentralManagerState.PoweredOn:
				message = "Bluetooth PoweredOn.";
				break;
			case CBCentralManagerState.Unsupported:
				message = "The platform or hardware does not support Bluetooth Low Energy.";
				break;
			case CBCentralManagerState.Unauthorized:
				message = "The application is not authorized to use Bluetooth Low Energy.";
				break;
			case CBCentralManagerState.PoweredOff:
				message = "Bluetooth is currently powered off.";
				break;
			default:
				break;
			}

			if (message != null) {
				Console.WriteLine(message);
			}
		}

		public override void DiscoveredPeripheral (CBCentralManager central, CBPeripheral peripheral, NSDictionary advertisementData, NSNumber RSSI)
		{
			Console.WriteLine ("Discovered {0}, data {1}, RSSI {2}", peripheral.Name, advertisementData, RSSI);
		}

		public void ScanForBroadcasters(CBCentralManager mgr, UIButton Scanner)
		{
			
			//Passing in null scans for all peripherals. Peripherals can be targeted by using CBUIIDs
			mgr.ScanForPeripherals (cbuuids); //Initiates async calls of DiscoveredPeripheral
		
			Scanner.SetTitle("Started scan Scan", UIControlState.Normal);
			//Timeout after 30 seconds
			var timer = new Timer (30 * 1000);
			timer.Elapsed += (sender, e) => {
				Console.WriteLine("Stopping scan");
				mgr.StopScan ();
				Console.WriteLine("Scan stopped");
				Scanner.SetTitle("Stopped Scan", UIControlState.Normal);
			};
		}
	}
}

