using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using probably_meme.Objects;
using System;
using System.Collections.Generic;

namespace probably_meme
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Texture2D background;
        Texture2D playerTexture;
        Texture2D weaponTexture;
        Texture2D bulletTexture;
        Texture2D enemyTexture;
        Texture2D enemyTexture1;
        int ms;
        double enemySpeed;
        Player player;
        Enemy enemy;

        List<Enemy> enemies;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerTexture = Content.Load<Texture2D>("player 2v2");
            player = new Player(new Vector2(GraphicsDevice.PresentationParameters.Bounds.Width / 2,
                GraphicsDevice.PresentationParameters.Bounds.Height / 2), 2, playerTexture, 100, 20);
            player.setSpeed(2.0);
            enemies = new List<Enemy>();


            ms = 2000;
            enemySpeed = 1;
            weaponTexture = Content.Load<Texture2D>("ak-47");
            bulletTexture = Content.Load<Texture2D>("bullet");
            SoundEffect[] shoots = new SoundEffect[3];
            shoots[0] = Content.Load<SoundEffect>("shoot 1");
            shoots[1] = Content.Load<SoundEffect>("shoot 2");
            shoots[2] = Content.Load<SoundEffect>("shoot 3");
            player.changeWeapon(new Weapon(player.getPosition(), 2, weaponTexture, 5, (float)10.0, shoots));
            player.weapon.changeBulletsTexture(bulletTexture);
            this.IsMouseVisible = true;
            player.weapon.changeOrigin(new Vector2(50, 50));
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("terrain 2");
            spriteFont = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            player.move(new Vector2(0, 0));
            enemies.ForEach(delegate (Enemy enemy) 
            {
                enemy.move(player.getPosition());
                if (enemy.isLive())
                    enemy.take_damage(player.collision(enemy));
            });
            enemies.ForEach(delegate (Enemy enemy)
            {
                //enemy.take_damage(player.collision(enemy));
            });
            enemyTexture = Content.Load<Texture2D>("enemy");
            enemyTexture1 = Content.Load<Texture2D>("player");
            if ((int)(gameTime.TotalGameTime.TotalMilliseconds % ms) == 0)
            {
                Random random = new Random();
                if (random.Next(0, 2) == 1)
                    enemies.Add(new Enemy(GameStaff.randomEnemyPosition(), 4, enemyTexture, 100, 4, enemySpeed));
                else
                    enemies.Add(new Enemy(GameStaff.randomEnemyPosition(), 2, enemyTexture1, 100, 1, enemySpeed));
                if (ms - 50 > 300)
                    ms -= 50;
                if (enemySpeed < 3)
                    enemySpeed += 0.1;
            }
                
            player.weapon.move();
            if (!player.isLive())
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.PresentationParameters.Bounds, Color.White);
            spriteBatch.End();
            player.draw(spriteBatch);
            enemies.ForEach(delegate (Enemy enemy) 
            {
                if (enemy.isLive())
                {
                    enemy.draw(spriteBatch);
                }
                    
                //else
                //    enemies.Remove(enemy);
            });
            player.weapon.draw(spriteBatch);
            String time = gameTime.TotalGameTime.Minutes + ":" + gameTime.TotalGameTime.Seconds;
            String health = player.hitPoints.ToString();
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, time, new Vector2(100, 100), Color.Black);
            spriteBatch.DrawString(spriteFont, health, new Vector2(100, 150), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
