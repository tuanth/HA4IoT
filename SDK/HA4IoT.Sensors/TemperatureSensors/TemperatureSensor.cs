﻿using System;
using HA4IoT.Contracts.Components;
using HA4IoT.Contracts.Sensors;

namespace HA4IoT.Sensors.TemperatureSensors
{
    public class TemperatureSensor : SensorBase, ITemperatureSensor
    {
        public TemperatureSensor(ComponentId id, INumericValueSensorEndpoint endpoint)
            : base(id)
        {
            if (endpoint == null) throw new ArgumentNullException(nameof(endpoint));

            Settings.SetValue(SingleValueSensorSettings.MinDelta, 0.15F);

            endpoint.ValueChanged += (s, e) =>
            {
                float oldValue = GetCurrentNumericValue();

                // TODO: Create base class.
                if (!GetDifferenceIsLargeEnough(e.NewValue))
                {
                    return;
                }

                SetCurrentValue(new NumericSensorValue(e.NewValue));
                CurrentNumericValueChanged?.Invoke(this, new NumericSensorValueChangedEventArgs(oldValue, e.NewValue));
            };
        }

        public event EventHandler<NumericSensorValueChangedEventArgs> CurrentNumericValueChanged;

        public float GetCurrentNumericValue()
        {
            return ((NumericSensorValue) GetCurrentValue()).Value;
        }

        private bool GetDifferenceIsLargeEnough(float value)
        {
            return Math.Abs(GetCurrentNumericValue() - value) >= Settings.GetFloat(SingleValueSensorSettings.MinDelta);
        }
    }
}