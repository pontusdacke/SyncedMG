﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synced.Content;
using Synced.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Synced.Static_Classes
{
    /// <summary>
    /// Singelton sealed ScreenManager, base class DrawableGameComponent
    /// </summary>
    sealed class ScreenManager : DrawableGameComponent
    {
        enum ScreenState { SplashScreen, MenuScreen, GameScreen }
        
        #region Singelton
        private static ScreenManager _screenManager;
        public static ScreenManager Instance
        {
            get
            {
                return _screenManager;
            }
        }
        public static void InitializeScreenManager(Game game)
        {
            if (_screenManager == null)
            _screenManager = new ScreenManager(game);
            Screen screena = new MenuScreen(Library.Interface.MenuBackground, game);
            screena.Deactivated();
            _screenManager.Screens.Push(screena);
            //Loads menu screen
            //Loads splash screens
            Screen screen = new SplashScreen(Library.Interface.Arrows, game);
            screen.Activated();
            _screenManager.Screens.Push(screen);


        }
        #endregion

        #region Constructor
        /// <summary>
        /// Private constructor of ScreenManager
        /// </summary>
        /// <param name="game"></param>
        private ScreenManager(Game game) : base(game) { }
        #endregion

        #region Screens
        /// <summary>
        /// Backgrounds screen for the applications
        /// </summary>
        public Stack<Screen> Screens = new Stack<Screen>();
        
        public int Count
        {
            get
            {
                return Screens.Count;
            }
        }
        public void AddScreen(Screen screen)
        {
            Screens.Push(screen);
        }
        public void AddScreen(List<Screen> screens)
        {
            screens.ForEach(Screens.Push);
        }
        public void AddScreen(Screen[] screens)
        {
            Array.ForEach(screens, Screens.Push);
        }
        #endregion
        public static Screen Pop()
        {
            if (ScreenManager.Instance.Screens.Count < 1)
            {
                return null;
            }
            ScreenManager.Instance.Screens.Peek().Deactivated(); //NOT SURE WHAT TO DO HERE.
            Screen prev = ScreenManager.Instance.Screens.Pop(); // RETURN OR NOT RETURN IS THE QUESTION
            if (ActiveScreen != null)
                ScreenManager.Instance.Screens.Peek().Activated();

            return prev;
        }
        public static Screen ActiveScreen
        {
            get
            {
                if (ScreenManager.Instance.Screens.Count >= 1)
                    return ScreenManager.Instance.Screens.Peek();
                else return null;
            }
        }


        public static bool Initialized
        {
            get;
            private set;
        }
        public override void Initialize()
        {
            ScreenManager.Initialized = true;
        }

        //public override void Update(GameTime gameTime)
        //{
        //    foreach (var item in Screens)
        //    {
        //        if (item.Enabled)
        //            item.Update(gameTime);
        //    }
        //}
        
        //public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        //{
        //    foreach (var item in Screens)
        //    {
        //        if (item.Enabled)
        //            item.Draw(gameTime);
        //    }
        //}
        protected override void Dispose(bool disposing)
        {

        }
    }
}