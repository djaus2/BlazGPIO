using System;
using System.Collections.Generic;
using System.Text;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;

namespace BlazorGPIO.Shared
{
    public static class RaspberryPiDriverGPIOTester
    {
        /// <summary>
        /// Leave this pin open (unconnected) for the tests
        /// </summary>
        private const int OpenPin = 23;

        public static string Log { get; set; } = "";

        //protected static  PinNumberingScheme GetTestNumberingScheme() => PinNumberingScheme.Logical;


        public static string InputPullResistorsWork(bool state)
        {
            Log = "Start";
            try
            {
                using (GpioController controller = new GpioController(PinNumberingScheme.Logical, new RaspberryPi3Driver()))
                {
                    controller.OpenPin(OpenPin, PinMode.InputPullUp);
                    var initstate = controller.Read(OpenPin);
                    switch (state)
                    {
                        case false:
                            controller.SetPinMode(OpenPin, PinMode.InputPullDown);
                            break;
                        case true:
                            controller.SetPinMode(OpenPin, PinMode.InputPullUp);
                            break;
                    }
                    var finalstate = controller.Read(OpenPin);
                    Log = $"Pin state was read as {initstate} Was set to {state} and  then read as {finalstate}";
                }
            }
            catch (Exception ex)
            {
                Log =  ex.Source + " " +  ex.Message;
            }
            return Log;

        }
    }

}
