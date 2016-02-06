﻿using System;
using HA4IoT.Actuators;
using HA4IoT.Contracts;
using HA4IoT.Contracts.Actuators;
using HA4IoT.Contracts.Notifications;
using HA4IoT.Networking;

namespace HA4IoT.Hardware.OpenWeatherMapWeatherStation
{
    public class WeatherStationHumiditySensor : SingleValueSensorActuatorBase, IHumiditySensor
    {
        public WeatherStationHumiditySensor(ActuatorId id, IHttpRequestController api, INotificationHandler logger) 
            : base(id, api, logger)
        {
        }

        public void SetValue(double value)
        {
            SetValueInternal(Convert.ToSingle(value));
        }
    }
}