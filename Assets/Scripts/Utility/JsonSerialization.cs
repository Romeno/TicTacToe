using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class UnityContractResolver : DefaultContractResolver
{
    public new static readonly UnityContractResolver Instance = new UnityContractResolver();

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);

        if ((property.DeclaringType == typeof(Vector2Int) ||
            property.DeclaringType == typeof(Vector3Int)) &&
            (property.PropertyName == "sqrMagnitude" || 
            property.PropertyName == "magnitude"))
        {
            property.ShouldSerialize = instance => false;
        }

        if ((property.DeclaringType == typeof(Vector2) &&
            property.DeclaringType == typeof(Vector3)) ||
            (property.PropertyName == "sqrMagnitude" ||
            property.PropertyName == "magnitude" ||
            property.PropertyName == "normalized"))
        {
            property.ShouldSerialize = instance => false;
        }

        return property;
    }
}
