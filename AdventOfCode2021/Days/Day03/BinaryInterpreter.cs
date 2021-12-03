using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public class BinaryInterpreter
    {
        private List<string> _inputs;
        private int _gammaRate;
        private int _epsilonRate;
        private int _oxygenRate;
        private int _co2Rate;

        public BinaryInterpreter(List<string> inputs)
        {
            this._inputs = inputs;
        }

        public void StartPowerConsumptionCalculation()
        {
            var binaryTracker = new List<int>();
            _inputs[0].ToCharArray().ToList().ForEach(_ => binaryTracker.Add(0));
            foreach (var line in _inputs)
            {
                var lineArray = line.ToCharArray();
                for (int i = 0; i < lineArray.Length; i++)
                {
                    binaryTracker[i] += lineArray[i] == '1' ? 1 : -1;
                }
            }

            var gammaBinaryString = "";
            var epsilonBinaryString = "";
            foreach (var binary in binaryTracker)
            {
                if (binary < 0)
                {
                    gammaBinaryString +="0";
                    epsilonBinaryString +="1";
                }

                if (binary > 0)
                {
                    gammaBinaryString +="1";
                    epsilonBinaryString +="0";
                }
            }
            _gammaRate = Convert.ToInt32(gammaBinaryString, 2);
            _epsilonRate = Convert.ToInt32(epsilonBinaryString, 2);
        }

        public void StartLifeSupportCalculations()
        {
            var oxygenList = new List<string>(_inputs);
            var maxI = oxygenList[0].Length;
            int i = 0;
            Console.WriteLine("Oxygen");
            while (oxygenList.Count() > 1)
            {
                int tracker = 0;
                foreach (var line in oxygenList)
                {
                    var lineArray = line.ToCharArray();
                    tracker += lineArray[i] == '1' ? 1 : -1;
                }

                var currentBit = tracker >= 0 ? '1' : '0';
                oxygenList = oxygenList.Where(x => x.ToCharArray()[i] == currentBit).ToList();
                i++;
            }
            _oxygenRate = Convert.ToInt32(oxygenList[0], 2);
            
            Console.WriteLine("Co2");
            var c02List = new List<string>(_inputs);
            i = 0;
            while (c02List.Count() > 1)
            {
                int tracker = 0;
                foreach (var line in c02List)
                {
                    var lineArray = line.ToCharArray();
                    tracker += lineArray[i] == '1' ? 1 : -1;
                }

                var currentBit = tracker >= 0 ? '0' : '1';
                c02List = c02List.Where(x => x.ToCharArray()[i] == currentBit).ToList();
                i++;
            }
            _co2Rate = Convert.ToInt32(c02List[0], 2);
        }

        public int PowerConsumption()
        {
            return _gammaRate * _epsilonRate;
        }        
        public int LiveSupportRating()
        {
            return _co2Rate * _oxygenRate;
        }
        
    }
}