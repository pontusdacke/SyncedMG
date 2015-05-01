﻿// InputManager.cs
// Introduced: 2015-04-14
// Last edited: 2015-04-14
// Edited by:
// Pontus Magnusson
//
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Synced.Static_Classes
{
    static class InputManager
    {
        static Dictionary<PlayerIndex, GamePadState> _LastStates = new Dictionary<PlayerIndex, GamePadState>();

        public static void Update()
        {
            foreach (PlayerIndex p in Enum.GetValues(typeof(PlayerIndex)))
                _LastStates[p] = GamePad.GetState(p);
        }

        public static bool IsButtonPressed(Buttons button, PlayerIndex playerIndex)
        {
            return (GamePad.GetState(playerIndex).IsButtonDown(button) && _LastStates[playerIndex].IsButtonUp(button)) ;
        }

        public static bool LeftStickLeft(PlayerIndex playerIndex)
        {
            return (GamePad.GetState(playerIndex).ThumbSticks.Left.X > 0f && _LastStates[playerIndex].ThumbSticks.Left.X <= 0f);
        }
        public static bool LeftStickRight(PlayerIndex playerIndex)
        {
            return (GamePad.GetState(playerIndex).ThumbSticks.Left.X < 0f && _LastStates[playerIndex].ThumbSticks.Left.X >= 0f);
        }
        public static bool LeftStickUp(PlayerIndex playerIndex)
        {
            return (GamePad.GetState(playerIndex).ThumbSticks.Left.Y > 0f && _LastStates[playerIndex].ThumbSticks.Left.Y <= 0f);
        }
        public static bool LeftStickDown(PlayerIndex playerIndex)
        {
            return (GamePad.GetState(playerIndex).ThumbSticks.Left.Y < 0f && _LastStates[playerIndex].ThumbSticks.Left.Y >= 0f);
        }
    }
}
