﻿using System;

namespace Headway.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DynamicConfigurationDefaultAttribute : Attribute
    {
    }
}