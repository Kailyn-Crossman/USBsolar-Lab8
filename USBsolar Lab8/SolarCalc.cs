using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace USBsolar_Lab8
{
    internal class SolarCalc
    {
        public double avgAnalogValue(string newPacket, int indexOfAnalog)
        {
            string[] voltage;
            double voltageReading = 0;
            voltage = new string[5];
            for (int i = 0; i < 7; i++){
                for (int e = 0; e < 5; e++)
                {
                    //Read Pin
                    voltage[e] = $"{newPacket.Substring(6 + (e * 4), 4)}";
                }
                voltageReading += Convert.ToInt32(voltage[indexOfAnalog]);
            }
            voltageReading = voltageReading / 6;
            return voltageReading;
        }

        public double analogToVoltage(double voltage)
        {
            
            double voltValue = (3.3 * voltage) / 4095;
            return voltValue;
        }

         public string GetCurrent(double an1, double shuntResistorAnalogValue)
         {
            //get difference between values
            double voltDif = shuntResistorAnalogValue - an1;
            //divide by 100 ohm
            double current = (voltDif / 100) * 100;
           
             return current.ToString("0.000" + "A");
         }

         public string GetLEDCurrent(double an1, double shuntResistorAnalog)
         {
            //needs to eleminate negative values caused by noise
            double voltDif = an1 - shuntResistorAnalog;
            double current = 0;
            if (voltDif < 0)
            {
                voltDif = 0;
            } else
            {
                //divide by 100 ohm
                current = (voltDif / 100) * 100;
            }

            return current.ToString("0.000" + "A");
             
         }

         /*public string GetVoltageString(double analogValue)
         {
             //Just get it i guess
         }



         public string ParseSolarData(string newPacket)
         {
             //call average voltage
             //parse the solar data into an array of analog voltage readings
             //average in a for loop
             //average voltage readings using sliding window average
         }*/
    }
}
