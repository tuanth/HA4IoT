﻿using System;
using HA4IoT.Contracts.Actuators;
using HA4IoT.Contracts.Configuration;

namespace HA4IoT.Actuators
{
    public static class ActuatorIdFactory
    {
        public static ActuatorId Create(IRoom room, Enum id)
        {
            return new ActuatorId(room.Id + "." + id);
        }
    }
}