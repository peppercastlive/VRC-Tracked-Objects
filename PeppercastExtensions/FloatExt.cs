using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRC_OSC_ExternallyTrackedObject.PeppercastExtensions
{
    public static class FloatExt
    {
        public static float Clamp(this float value, float minimum = 0f, float maximum = 1f)
        {
            if (value < minimum)
                return minimum;

            else if (value > maximum)
                return maximum;

            return value;
        }
    }
}
