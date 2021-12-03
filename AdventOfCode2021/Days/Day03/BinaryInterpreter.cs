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
        
        public BinaryInterpreter(List<string> inputs)
        {
            this._inputs = inputs;
        }

        public void StartInterpretation()
        {
            var binaryTracker = new List<int>();
            _inputs[0].ToCharArray().ToList().ForEach(x => binaryTracker.Add(0));
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
        

        public int PowerConsumption()
        {
            return _gammaRate * _epsilonRate;
        }
        
    }
}