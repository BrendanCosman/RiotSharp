﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionConverter.cs" company="">
//
// </copyright>
// <summary>
//   The region converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// The region converter.
    /// </summary>
    class RegionConverter : JsonConverter
    {
        /// <summary>
        /// The can convert.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// The read json.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="existingValue">
        /// The existing value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() != null)
            {
                var str = token.Value<string>();
                switch (str)
                {
                    case "BR":
                        return Region.br;
                    case "EUNE":
                        return Region.eune;
                    case "EUW":
                        return Region.euw;
                    case "KR":
                        return Region.kr;
                    case "LAN":
                        return Region.lan;
                    case "LAS":
                        return Region.las;
                    case "NA":
                        return Region.na;
                    case "OCE":
                        return Region.oce;
                    case "RU":
                        return Region.ru;
                    case "TR":
                        return Region.tr;
                    default:
                        return null;
                }
            }

            return null;
        }

        /// <summary>
        /// The write json.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Region)value).ToString().ToUpper());
        }
    }
}
