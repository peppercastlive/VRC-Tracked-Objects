using System.Security.RightsManagement;
using System.Windows;
using VRC_OSC_ExternallyTrackedObject.Peppercast;

namespace VRC_OSC_ExternallyTrackedObject
{
    public partial class MainWindow
    {
        /// <summary>
        /// Object that handles the main functions of Peppercast.
        /// </summary>
        private PeppercastManager _peppercastManager;
        
        /// <summary>
        /// The method that's called when the value of axis 1 position slider value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Axis1PositionSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _peppercastManager.Axis1Position = (float)e.NewValue;
            axis1PosLabel.Content = string.Format("Axis 1 Position: {0}", _peppercastManager.Axis1Position.ToString("0.00"));
        }

        /// <summary>
        /// The method that's called when the axis 1 rotation slider value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Axis1RotationSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    _peppercastManager.Axis1Rotation = (float)e.NewValue;
        //    axis1RotLabel.Content = string.Format("Axis 1 Rotation: {0}", _peppercastManager.Axis1Rotation.ToString("0.00"));
        //}

        /// <summary>
        /// The method that's called when the axis 2 position slider value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Axis2PositionSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _peppercastManager.Axis2Position = (float)e.NewValue;
            axis2PosLabel.Content = string.Format("Axis 2 Position: {0}", _peppercastManager.Axis2Position.ToString("0.00"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rigOffsetSaveButtonClick(object sender, RoutedEventArgs e)
        {
            _peppercastManager.SaveRigConfiguration();
        }

        /// <summary>
        /// Sets the value of "axis1PoitionSlider" to 0 and updates the value in the "PeppercastManager" object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAxis1Position(object sender, RoutedEventArgs e)
        {
            axis1PositionSlider.Value = 0f;
            _peppercastManager.Axis1Position = 0f;
        }

        /// <summary>
        /// Sets the value of "axis1RotationSlider" value to 0, then updates the value in the "PeppercastManager" object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ResetAxis1Rotation(object sender, RoutedEventArgs e)
        //{
        //    axis1RotationSlider.Value = 0f;
        //    _peppercastManager.Axis1Rotation = 0f;
        //}

        /// <summary>
        /// Sets the value of the "axis2PositionSlider" to 0, then updates the value within the "PeppercastManager" object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAxis2Position(object sender, RoutedEventArgs e)
        {
            axis2PositionSlider.Value = 0f;
            _peppercastManager.Axis2Position = 0f;
        }

        /// <summary>
        /// Initializes the Peppercast scripts.
        /// </summary>
        private void InitializePeppercast()
        {
            _peppercastManager = PeppercastManager.Initialize(OscManager);

            axis1PositionSlider.Value = _peppercastManager.Axis1Position;
            //axis1RotationSlider.Value = _peppercastManager.Axis1Rotation;
            axis2PositionSlider.Value = _peppercastManager.Axis2Position;
        }

        /// <summary>
        /// The peppercast manager values from the file, then updates the values of the sliders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadRigConfiguration(object sender, RoutedEventArgs e)
        {
            _peppercastManager.ReloadRigInfo();

            axis1PositionSlider.Value = _peppercastManager.Axis1Position;
            //axis1RotationSlider.Value = _peppercastManager.Axis1Rotation;
            axis2PositionSlider.Value = _peppercastManager.Axis2Position;
        }

        private void trackerRotationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _peppercastManager.TrackerRotation = (float)e.NewValue;
            axis1PosLabel.Content = string.Format("Tracker Rotation: {0}", _peppercastManager.TrackerRotation.ToString("0.00"));
        }

        private void trackerRotationReset_Click(object sender, RoutedEventArgs e)
        {
            trackerRotationSlider.Value = 0f;
            _peppercastManager.TrackerRotation = 0f;
        }
    }
}
