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
        public int analogValue(string newPacket, int indexOfAnalog)
        {
            string[] voltage;
            voltage = new string[5];
            for (int i = 0; i < 5; i++) 
            {
                //Read Pin
                voltage[i] = $"{newPacket.Substring(6 + (i*4), 4)}";
            }
            int value = Convert.ToInt32(voltage[indexOfAnalog]);
            return value;
        }

        public double averageVoltage(int voltageToAverage)
        {
            int totalVal = 0;
            for(int i = 0; i < 9;i++)
            {
              totalVal += voltageToAverage;
            }
            double avgValue = totalVal / 8;
            double voltValue = (3.3 * avgValue) / 4095;
            return voltValue;
        }

        /* public string GetCurrent(double an1, double shuntResistorAnalogValue)
         {
             //get difference between values
             //divide by 100 ohm
             //return value.ToString();
         }

         public string GetLEDCurrent(double an1, double shuntResistorAnalog)
         {
             //needs to eleminate negative values caused by noise
             //get average value of specified shunt resistor
             //divide by 100 ohm
             //return value.ToString();
         }

         public string GetVoltageString(double analogValue)
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
