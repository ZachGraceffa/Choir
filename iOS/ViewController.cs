using System;
		
using UIKit;
using CoreBluetooth;
using CoreFoundation;

namespace Choir.iOS
{
	public partial class ViewController : UIViewController
	{
		ChoirCBCentralManagerDelegate del;
		CBCentralManager manager;

		public ViewController (IntPtr handle) : base (handle)
		{
			del = new ChoirCBCentralManagerDelegate();
			manager = new CBCentralManager (del, DispatchQueue.CurrentQueue);
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
		}

		public override void DidReceiveMemoryWarning ()
		{		
			Console.WriteLine ("DidReceiveMemoryWarning()");

			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
