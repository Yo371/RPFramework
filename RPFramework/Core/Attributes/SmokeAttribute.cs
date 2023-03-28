using System;
using NUnit.Framework;

namespace RPFramework.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SmokeAttribute : CategoryAttribute
    {
        
    }
}