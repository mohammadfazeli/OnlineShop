﻿using System;
using System.Collections;
using System.Linq;

namespace OnlineShop.Common.Utilities
{
    public static class Assert
    {
        public static void NotNull<T>(T obj,string name,string message = null)
            where T : class
        {
            if(obj is null)
                throw new ArgumentNullException($"{name} : {typeof(T)}",message);
        }

        public static void NotNull<T>(T? obj,string name,string message = null)
            where T : struct
        {
            if(!obj.HasValue)
                throw new ArgumentNullException($"{name} : {typeof(T)}",message);
        }

        public static bool GuidIsValid(this Guid id)
        {
            return id != new Guid();
        }

        public static bool GuidIsValid(this Guid? id)
        {
            return id != null && id != new Guid();
        }

        public static void NotEmpty<T>(T obj,string name,string message = null,T defaultValue = null)
            where T : class
        {
            if(obj == defaultValue
                || (obj is string str && string.IsNullOrWhiteSpace(str))
                || (obj is IEnumerable list && !list.Cast<object>().Any()))
            {
                throw new ArgumentException("Argument is empty : " + message,$"{name} : {typeof(T)}");
            }
        }
    }
}