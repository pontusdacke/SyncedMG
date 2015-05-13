﻿using Microsoft.Xna.Framework;
using Synced.Content;
using Synced.InGame;
using Synced.Interface;
// MenuState.cs
// Introduced: 2015-04-17
// Last edited: 2015-05-10
// Edited by:
// Pontus Magnusson
// Göran Forsström
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Synced.State_Machine
{
    class MenuState : State, IUnloadable
    {
        MenuScreen _menu;

        public MenuState(Game game)
            : base(game)
        {
            Library.Audio.PlaySong(Library.Audio.Songs.Menu);
            _menu = new MenuScreen(Library.Interface.MenuBackground, game);
        }

        public override void Update(GameStateMachine gameStateMachine)
        {
            if (_menu.IsEveryoneReady())
            {
                Game.Components.Remove(_menu);
                gameStateMachine.CurrentState = new GameState(Game);
            } 
        }

        public override void Play(GameStateMachine gameStateMachine)
        {
        }
        public override string GetStateName() { return "Menu State"; }

        public void Unload()
        {
            _menu.Unload();
        }
    }
}
