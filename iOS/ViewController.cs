﻿using System;
		
using UIKit;
using CoreBluetooth;
using CoreFoundation;

namespace Choir.iOS
{
	public partial class ViewController : UIViewController
	{
		string deviceName = UIDevice.CurrentDevice.Name;
		ChoirCBCentralManagerDelegate del;
		CBCentralManager manager;
		CBPeripheralManager peripheral;
		ChoirCBPeripheralManagerDelegate peripheralManagerDelegate;

		public ViewController (IntPtr handle) : base (handle)
		{
			del = new ChoirCBCentralManagerDelegate();
			manager = new CBCentralManager (del, DispatchQueue.CurrentQueue);
			peripheralManagerDelegate = new ChoirCBPeripheralManagerDelegate ();
			peripheral = new CBPeripheralManager (peripheralManagerDelegate, DispatchQueue.CurrentQueue);
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif

			Scanner.AccessibilityIdentifier = "Bluetooth Init";
			Scanner.TouchUpInside += delegate {
				del.ScanForBroadcasters(manager, Scanner);
			};

			var options = new StartAdvertisingOptions ();

			peripheral.StartAdvertising (options);

			if (peripheral.Advertising)
				Console.WriteLine ("Advertising");

			//manager.ConnectedPeripheral += (s, e) => {
			//	var activePeripheral = e.Peripheral;
			//	System.Console.WriteLine ("Connected to " + activePeripheral.Name);


			//	if (activePeripheral.Delegate == null) {
			//		activePeripheral.Delegate = new ChoirCBCentralPeripheralDelegate ();
					//Begins asynchronous discovery of services
			//		activePeripheral.DiscoverServices ();
			//	}
			//};

			//Connect to peripheral, triggering call to ConnectedPeripheral event handled above 
			//mgr.ConnectPeripheral (myPeripheral);
		}

		public override void DidReceiveMemoryWarning ()
		{		
			Console.WriteLine ("DidReceiveMemoryWarning()");

			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
