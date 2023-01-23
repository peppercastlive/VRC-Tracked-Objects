using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace VRC_OSC_ExternallyTrackedObject
{
    public partial class MainWindow
    {
        private PeppercastManager _peppercastManager; // Object that handles main peppercast
        private void Axis1PositionSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void InitializePeppercast()
        {
            _peppercastManager = new PeppercastManager(OscManager);
        }
    }
}
