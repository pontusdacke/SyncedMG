﻿using Microsoft.Xna.Framework;
// InGameState.cs
// Introduced: 2015-04-17
// Last edited: 2015-04-17
// Edited by:
// Pontus Magnusson
//
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Synced.State_Machine
{
    class GameState : State
    {
        public GameState(Game game) : base(game)
        {
        }
        public override void Pause(GameStateMachine gameStateMachine)
        {
            gameStateMachine.CurrentState = new PauseState(Game);
        }

        public override void Finish(GameStateMachine gameStateMachine)
        {
            gameStateMachine.CurrentState = new ScoreState(Game);
        }
        public override string GetStateName() { return "Game State"; }
    }
}
