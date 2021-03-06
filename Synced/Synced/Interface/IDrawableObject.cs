﻿// CharacterSelector.cs
// Introduced: 2015-04-29
// Last edited: 2015-04-29
// Edited by:
// Robin Calmegård
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Synced.Interface
{
    interface IDrawableObject
    {
        Vector2 Position { get; }
        Texture2D Texture { get; }
    }
}
