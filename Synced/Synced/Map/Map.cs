﻿// Map.cs
// Introduced: 2015-04-14
// Last edited: 2015-05-13
// Edited by:
// Pontus Magnusson
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synced.Actors;
using Synced.Content;
using Synced.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using Synced.InGame;
using Synced.MapNameSpace;
using Synced.CollisionShapes;
using Synced.Static_Classes;

namespace Synced.MapNamespace
{
    class Map : DrawableGameComponent// : Screen
    {
        #region Variables
        int CrystalStartIndex;
        public static List<CrystalSpawnData> crystalSpawnList;
        public static List<PlayerStartData> playerStartData;

        // World
        #endregion
        #region Properties
        public MapData Data
        {
            get;
            set;
        }
        public World World
        {
            get;
            set;
        }
        #endregion

        public Map(string path, Game game, World world) : base (game)
        {
            if (crystalSpawnList == null)
            {
                crystalSpawnList = new List<CrystalSpawnData>();
            }
            else
            {
                crystalSpawnList.Clear();
            }

            if (playerStartData == null)
            {
                playerStartData = new List<PlayerStartData>();
            }
            else
            {
                playerStartData.Clear();
            }

            Data = Library.Serialization<MapData>.DeserializeFromXmlFile(path);
            World = world;
        }

        public void LoadMap(Game game) // playerData
        {
            //Process data
            foreach (var mapObject in Data.Objects)
            {
                if (mapObject is CrystalSpawnData)
                {
                    crystalSpawnList.Add((CrystalSpawnData)mapObject);
                }
                if (mapObject is PlayerStartData)
                {
                    playerStartData.Add((PlayerStartData)mapObject);
                }
                else
                {
                    SyncedGameCollection.ComponentCollection.Add(mapObject.GetComponent(game, World));
                }
            }
        }
        private void SetupPlayer()
        { 
        
        }
        
        public void ClearData()
        {
            crystalSpawnList.Clear();
            playerStartData.Clear();
        }
    }
}
