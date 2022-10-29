using System;
using System.Collections.Generic;
using System.Text;

namespace DependancyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ScopedServiceAttribute : Attribute
    {
        public readonly Type TypeOfImplementation;
        public readonly Type TypeOfService;

        public ScopedServiceAttribute(Type typeOfImplementation)
        {
            TypeOfImplementation = typeOfImplementation;
        }

        public ScopedServiceAttribute(Type typeOfImplementation, Type typeOfService)
        {
            TypeOfImplementation = typeOfImplementation;
            TypeOfService = typeOfService;
        }
    }
}
