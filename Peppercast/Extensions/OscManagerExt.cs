using Rug.Osc;

namespace VRC_OSC_ExternallyTrackedObject.Peppercast.Extensions
{
    internal static class OscManagerExt
    {

        public const string AVATAR_PARAMETER_PATH = "/avatar/parameters/{0}";

        /// <summary>
        ///  Sends a value to VRChat with a given avatar parameter.
        /// </summary>
        /// <param name="oscManager"></param>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        public static void SendAvatarParameter(this OscManager oscManager, string parameter, float value) => 
            oscManager.OSCSender?.Send(new OscMessage(string.Format(AVATAR_PARAMETER_PATH, parameter), value));
        
        /// <summary>
        /// Sends a value to VRChat with a given avatar parameter.
        /// </summary>
        /// <param name="oscManager"></param>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        public static void SendAvatarParameter(this OscManager oscManager, string parameter, bool value) =>
            oscManager.OSCSender?.Send(new OscMessage(string.Format(AVATAR_PARAMETER_PATH, parameter), value));
        
        /// <summary>
        /// Sends a value to VRChat with a given avatar parameter.
        /// </summary>
        /// <param name="oscManager"></param>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        public static void SendAvatarParameter(this OscManager oscManager, string parameter, int value) =>
            oscManager.OSCSender?.Send(new OscMessage(string.Format(AVATAR_PARAMETER_PATH, parameter), value));
        
    }
}
