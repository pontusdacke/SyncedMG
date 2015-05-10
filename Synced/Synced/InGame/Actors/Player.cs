﻿// Player.cs
// Introduced: 2015-04-14
// Last edited: 2015-04-30
// Edited by:
// Pontus Magnusson
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Synced.Content;
using Synced.Static_Classes;
using Microsoft.Xna.Framework.Input;

namespace Synced.Actors
{
    class Player : GameComponent
    {
        public Unit Left
        { get; set; }

        public Unit Right
        {
            get;
            set;
        }

        PlayerIndex _playerIndex;


        public Player(PlayerIndex playerIndex, Library.Character.Name character, Game game)
            : base(game)
        {
            _playerIndex = playerIndex;
            Left = new Unit(Library.Character.GameTexture[character], Color.Red, game);
            Right = new Unit(Library.Character.GameTexture[character], Color.DarkRed, game);

            game.Components.Add(this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Left.Direction = InputManager.LeftStickDirection(_playerIndex);
            Right.Direction = InputManager.RightStickDirection(_playerIndex);

            if (InputManager.LeftShoulderPressed(_playerIndex))
                Left.Shoot();

            if (InputManager.RightShoulderPressed(_playerIndex))
                Right.Shoot();

            base.Update(gameTime);
        }

    }
}