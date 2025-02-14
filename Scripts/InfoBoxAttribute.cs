using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Method)]
public class InfoBoxAttribute : PropertyAttribute
{
    public string Info { get; private set; }

    public InfoBoxAttribute(string info)
    {
        Info = info;
    }
}