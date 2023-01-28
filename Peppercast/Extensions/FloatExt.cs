using System;

namespace VRC_OSC_ExternallyTrackedObject.Peppercast.Extensions
{
    public static class FloatExt
    {
        public static float Clamp(this float value, float minimum = 0f, float maximum = 1f)
        {
            // Throws an exception if the minimum value is greater than the maximum value.
            if (minimum >= maximum)
                throw new Exception("A minimum value can't be greater then or equal to the maximum value given.");

            // Returns the minimum value if the value is less than the minimum value.
            if (value < minimum)
                return minimum;

            // Returns the maximum value if the value is greater than the maximum value.
            else if (value > maximum)
                return maximum;

            // Returns the given value neither of the previous conditions are met.
            return value;
        }
    }
}
