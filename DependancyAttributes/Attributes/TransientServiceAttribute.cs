using System;
using System.Collections.Generic;
using System.Text;

namespace DependancyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TransientServiceAttribute : Attribute
    {
        public readonly Type TypeOfImplementation;
        public readonly Type TypeOfService;

        public TransientServiceAttribute(Type typeOfImplementation)
        {
            TypeOfImplementation = typeOfImplementation;
        }

        public TransientServiceAttribute(Type typeOfImplementation, Type typeOfService)
        {
            TypeOfImplementation = typeOfImplementation;
            TypeOfService = typeOfService;
        }
    }
}
