// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Code in this file is taken from https://github.dev/dotnet/aspnetcore

#if NET6_0_OR_GREATER

using System.Reflection;

namespace MiniValidation
{
    public static class NonNullablePropertyHelper
    {
        private static readonly NullabilityInfoContext NullabilityContext = new ();

        public static bool IsNonNullableReferenceType(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsValueType)
            {
                return false;
            }

            var nullabilityInfo = NullabilityContext.Create(propertyInfo);
            return nullabilityInfo.WriteState is not NullabilityState.Nullable;
        }
    }
}
#endif
