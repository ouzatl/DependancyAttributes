using System;
using System.Collections.Generic;
using System.Text;

namespace DependancyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SingletonServiceAttribute : Attribute
    {
        
        public readonly Type TypeOfImplementation;
        public readonly Type TypeOfService;
        
        public SingletonServiceAttribute(Type typeOfImplementation)
        {
            TypeOfImplementation = typeOfImplementation;
        }

        public SingletonServiceAttribute(Type typeOfImplementation, Type typeOfService)
        {
            TypeOfImplementation = typeOfImplementation;
            TypeOfService = typeOfService;
        }
    }
}
