using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using VRC_OSC_ExternallyTrackedObject.Peppercast.Extensions;

namespace VRC_OSC_ExternallyTrackedObject.Peppercast
{
    internal class PeppercastManager
    {
        private const string FOLDER = "Pepper Cast";
        private const string CONFIGFILE = "Configuration.json";

        public const string TRACKERROTATION = "TrackerRot";
        public const string AXIS1POSITION = "Axis1Pos";
        public const string AXIS1ROTATION = "Axis1Rot";
        public const string AXIS2POSITION = "Axis2Pos";



        public static string ConfigPath => Path.Join(Environment.CurrentDirectory, FOLDER, CONFIGFILE);

        public PeppercastManager(OscManager? oscManager, float trackerRotation, float axis1Position, float axis2Position)
        {
            this._oscManager = oscManager;
            this._trackerRotation = trackerRotation;
            this._axis1Position = axis1Position;
            this._axis2Position = axis2Position;
        }

        public PeppercastManager(OscManager oscManager)
        {
            this._oscManager = oscManager;
            this._trackerRotation = 0f;
            this._axis1Position = 0f;
            this._axis2Position = 0f;
        }

        private OscManager? _oscManager;

        private float _trackerRotation;
        private float _axis1Position;
        private float _axis2Position;

        public float TrackerRotation
        {
            get => _trackerRotation;

            set
            {
                _trackerRotation = value.Clamp(-1f, 1f);
                _oscManager?.SendAvatarParameter(TRACKERROTATION, _trackerRotation);
            }
        }

        /// <summary>
        /// The y axis translation from the tracker to the first axis object.
        /// </summary>
        public float Axis1Position
        {
            get => _axis1Position;

            set
            {
                _axis1Position = value.Clamp(-1f, 1f); // Clamps the float between two values, a minimum and a maximum value.
                _oscManager?.SendAvatarParameter(AXIS1POSITION, _axis1Position); // Sends the axis value to the avatar using the OscManager object.
            }
        }

        /// <summary>
        /// The axis from the first axis to the second axis on the z translation.
        /// </summary>
        public float Axis2Position
        {
            get => _axis2Position;

            set
            {
                _axis2Position = value.Clamp(-1f, 1f);
                _oscManager?.SendAvatarParameter(AXIS2POSITION, _axis2Position); // Sends the value of the offset to the avatar using the OscManager object.
            }
        }

        /// <summary>
        /// Saves the configuration of the "PeppercastManager" object.
        /// </summary>
        public void SaveRigConfiguration()
        {
            var jObj = new JObject(); // Creates a new JsonObject.

            jObj.Add("TrackerRotation", TrackerRotation); // Adds "TrackerRotation" value to the JsonObject.
            jObj.Add("Axis1Position", Axis1Position); // Adds "Axis1Position" value to the JsonObject.
            jObj.Add("Axis2Position", Axis2Position); // Adds "Axis2Position" value to the JsonObject.

            var json = jObj.ToString(); // Grabs the Json string and stores it in a value.

            // Opens a new StreamWriter.
            using (var sw = new StreamWriter(ConfigPath))
            {
                sw.Write(json); // Writes the Json string to the configuration file.
            }
        }

        /// <summary>
        /// Reloads the configuration info from it's file.
        /// </summary>
        public void ReloadRigInfo()
        {
            var json = ""; // Creates an empty string and saves it to a variable.

            // Creates a new StreamReader.
            using (var sr = new StreamReader(ConfigPath))
            {
                json = sr.ReadToEnd(); // Reads everything from the file using the streamreader then saves it to a variable.
            }

            var jObj = (JObject)JsonConvert.DeserializeObject(json); // Deserializes the json string and turns it into a JsonObject.

            var trackerRot = jObj.GetValue("TrackerRotation").Value<float>(); // Extracts the "TrackerRotation" value and stores it in a variable.
            var axis1Pos = jObj.GetValue("Axis1Position").Value<float>(); // Extracts the "Axis1Position" value and stores it in a variable.
            var axis1Rot = jObj.GetValue("Axis1Rotation").Value<float>(); // Extracts the "Axis1Rotation" value and stores it in a variable.
            var axis2Pos = jObj.GetValue("Axis2Position").Value<float>(); // Extracts the "Axis2Position" value and stores it in a variable.

            TrackerRotation = trackerRot; // Saves the "TrackerRotation" variable and stores it into the "TrackerRotation" property in the object.
            Axis1Position = axis1Pos; // Saves the "Axis1Position" variable and stores it into the "Axis1Position" property in the object.
            Axis2Position = axis2Pos; // Saves the "Axis2Position" variable and stores it into the "axis2Position" property in the object.
        }

        /// <summary>
        /// Initializes the "PeppercastManager" object.
        /// </summary>
        /// <param name="oscManager"></param>
        /// <returns></returns>
        public static PeppercastManager Initialize(OscManager oscManager)
        {
            // Creates a directory for the Peppercast files if one isn't already made.
            if (!Directory.Exists(FOLDER))
                Directory.CreateDirectory(FOLDER);

            PeppercastManager peppercastManager; // Creates an unnnasighned "PeppercastManager" object

            // Checks if the Peppercast configuration file doesn't exists.
            if (!File.Exists(ConfigPath))
            {
                peppercastManager = new PeppercastManager(oscManager); // Creates a new "PeppercastManager" object.
                peppercastManager.SaveRigConfiguration(); // Saves the configuration to a file.
                return peppercastManager; // Returns the "PeppercastManager" object.
            }

            // Creates a variable and assigns it an empty string.
            var json = "";

            // Creates a StreamReader and using the configuration path.
            using (var sr = new StreamReader(ConfigPath))
            {
                json = sr.ReadToEnd(); // Stores the contents of the file in the empty string variable.
            }

            var jObj = (JObject)JsonConvert.DeserializeObject(json); // Parses the json string to deserialize the "PeppercastManager" object into a JsonObject.

            var trackerRotation = jObj.GetValue("TrackerRotation").Value<float>(); // Stores the value of "TrackerRotation" into the variable.
            var axis1Pos = jObj.GetValue("Axis1Position").Value<float>(); // Stores the value of "Axis1Position" into a variable.
            var axis2Pos = jObj.GetValue("Axis2Position").Value<float>(); // Stores the value of "Axis2Position" into a variable.

            return new PeppercastManager(oscManager, trackerRotation, axis1Pos, axis2Pos); // Returns a "PeppercastManager" object using the previously stored variables. 
        }
    }
}
