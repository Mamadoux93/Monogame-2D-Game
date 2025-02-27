﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UltraLongMonogameTutoriel.NPS;
using UltraLongMonogameTutoriel.Scenes;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class GameManager
    {
        private readonly UIManager ui = new();
        

        private Player player;
        private GraphicsDeviceManager graphics;
        private static CameraManager cameraManager;
        private RessourceManager ressourceManager;
        private List<Sprite> usableItems;
        //private readonly WindowResize windowResize;
        private SceneManager sceneManager;

        GameManagerConfig config;

        private readonly TriggerManager triggerManager;

        private List<Sprite> SummonedEntities { get; set; } = new List<Sprite>();


        public GameManager(GameManagerConfig config)
        {
            this.config = config;
            player = config.Player;
            cameraManager = config.CameraManager;
            ressourceManager = config.RessourceManager;
            usableItems = config.UsableItems;
            sceneManager = config.SceneManager;
            graphics = config._GraphicsDeviceManager;

            triggerManager = new TriggerManager(cameraManager);
            ui.AddButton(2500, 100, 90, 90, Color.Chocolate).OnClick += SpawnProjectile;
            ui.AddButton(2500, 200, 90, 90, Color.Aqua).OnClick += SpawnEnemy;
            ui.AddButton(2500, 300, 90, 90, Color.Crimson).OnClick += AwarnessSwitch;

            ui.AddCanvas(200, 500, 1000, 1000);

            triggerManager.AddTriggerBox("SpaceScene",player.rect.X + 500, player.rect.Y - 800, 90, 1000, Color.Red, ClassicCinematic);


            InitializeTriggersForCurrentScene(); // Ca c'est pour la toute premiere cinématique sinon elle marche pas

        }

        public void Update()
        {
            ui.Update();
            DragDropManager.Update();
            InputManager.Update();

            triggerManager.ActivateTriggersForScene(sceneManager.CurrentScene.GetType().Name);

        }
        //--Cinematics
        private void FirstCinematicTriggerBox(object sender, EventArgs e)
        {
            cameraManager.FirstCinematic = true;
            cameraManager.CameraPostion = new(player.rect.X, player.rect.Y);
            cameraManager.StartCinematic(1, -player.rect.X, -player.rect.Y, 10);
            cameraManager.FirstCinematic = false;
        }

        private void ClassicCinematic(object sender, EventArgs e)
        {
            cameraManager.StartCinematic(1, -3000, -player.rect.Y, 0);
        }

        //--Cinematics

        //--Scene
        private void SceneChange(object sender, EventArgs e)
        {
            sceneManager.AddScene(new GameStartScene(Globals.Content, sceneManager, graphics));
            Globals.LevelChange = true;

            InitializeTriggersForCurrentScene();
        }
        private void InitializeTriggersForCurrentScene()
        {
            string sceneName = sceneManager.CurrentScene.GetType().Name;
            int spawnX = sceneManager.CurrentScene.SpawnPointX;
            int spawnY = sceneManager.CurrentScene.SpawnPointY;
            int sceneChangeX = sceneManager.CurrentScene.SceneChangePointX;
            int sceneChangeY = sceneManager.CurrentScene.SceneChangePointY;

            triggerManager.ClearTriggers();

            triggerManager.AddTriggerBox(sceneName, spawnX, spawnY, 90, 90, Color.Red, FirstCinematicTriggerBox);
            triggerManager.AddTriggerBox(sceneName, sceneChangeX, sceneChangeY, 120, 120, Color.Orange, SceneChange);

            Debug.WriteLine($"Triggers ajoutés pour la scène {sceneName}");
        }

        //--Scene


        private void SpawnProjectile(object sender, EventArgs e)
        {
            SummonEntity<Projectiles>(ressourceManager.GetTexture("fireball"),
                new Rectangle(player.rect.X, player.rect.Top, Globals.TILESIZE, Globals.TILESIZE),
                new Rectangle(0, 0, 8, 8),
                usableItems, player);
        }
        private void SpawnEnemy(object sender, EventArgs e)
        {
            SummonEntity<EnemyZebi>(ressourceManager.GetTexture("player_static"),
                new Rectangle(player.rect.X + 300 * player.Direction, player.rect.Y, Globals.TILESIZE, Globals.TILESIZE * 2),
                new Rectangle(0, 0, 8, 16),
                usableItems, player);
        }
        private void AwarnessSwitch(object sender, EventArgs e)
        {
            Globals.NPS_Awarness = !Globals.NPS_Awarness;
        }

        private void SummonEntity<T>(Texture2D texture, Rectangle rect, Rectangle srect, List<Sprite> list, Sprite Summoner) where T : Sprite
        {
            T entity = (T)Activator.CreateInstance(typeof(T), texture, rect, srect);

            entity.Summon();
            SummonedEntities.Add(entity);


            list.Add(entity);

            Debug.WriteLine($"{entity} summoned!");

            if (typeof(T) == typeof(Projectiles))
            {
                entity.Direction = Summoner.Direction;
            }

            SummonedEntities.Clear();

        }

        public void Draw()
        {
            if (!cameraManager.IsCinemating)
            {
                ui.Draw();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                triggerManager.Draw();
            }
            triggerManager.Update();
            triggerManager.CheckTriggers(player);
        }
    }
}
