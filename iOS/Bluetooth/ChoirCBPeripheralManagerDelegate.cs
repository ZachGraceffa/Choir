using System;
using CoreBluetooth;
using Foundation;

namespace Choir.iOS
{
	public class ChoirCBPeripheralManagerDelegate : NSObject, ICBPeripheralManagerDelegate
	{
		//public IntPtr Handle {
		//	[Preserve]
		//	get;
		//	private set;
		//}

		public ChoirCBPeripheralManagerDelegate ()
		{
			//Handle = "A0176292-276B-4DDA-B32B-BD9BC51FF33D";
		}

		public void StateUpdated (CBPeripheralManager peripheral)
		{
			if (peripheral.State == CBPeripheralManagerState.PoweredOn) {
			}
		}

		public void AdvertisingStarted(CBPeripheralManager peripheral)
		{
			//TODO something here
		}

		//new public void Dispose ()
		//{
			//TODO do something here
		//}
	}
}

