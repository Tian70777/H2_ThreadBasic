using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadBasicOpgave1Til3.Opgave3
{
    /// <summary>
    /// Generates random temperature between -20 and 120 degraees
    /// </summary>
    public static class TemperatureGenerator
    {
        private static Random random = new Random();

        public static int Generator()
        {
            return random.Next(-20, 121);

        }

    }
}
