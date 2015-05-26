﻿// Goal.cs
// Introduced: 2015-04-14
// Last edited: 2015-04-14
// Edited by:
// Pontus Magnusson
using System;
using System.Xml.Serialization;

namespace Synced.MapNamespace
{
    [Serializable]
    public class Goal : Obstacle
    {
        [XmlElement("Radius")]
        public int Radius;
    }
}