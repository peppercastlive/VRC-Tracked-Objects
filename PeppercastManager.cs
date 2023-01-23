using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC_OSC_ExternallyTrackedObject.PeppercastExtensions;
using OscManager = VRC_OSC_ExternallyTrackedObject.OscManager;

namespace VRC_OSC_ExternallyTrackedObject
{
    internal class PeppercastManager
    {
        public PeppercastManager(OscManager oscManager)
        {
            this._oscManager = oscManager;
        }

        private OscManager _oscManager;

        private float _axis1Position;
        private float _axis1Rotation;
        private float _axis2Position;

        public float Axis1Position
        {
            get => _axis1Position;

            set
            {
                _axis1Position = value.Clamp(-1f, 1f);
                _oscManager.
            }

        }

        public float Axis1Rotation
        {
            get => _axis1Rotation;

            set => _axis1Rotation = value.Clamp(-1f, 1f);
        }

        public float Axis2Position
        {
            get => _axis2Position;

            set => _axis2Position = value.Clamp(-1f, 1f);
        }
    }
}
