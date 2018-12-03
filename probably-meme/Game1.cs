using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using probably_meme.Objects;
using System.Collections.Generic;

namespace probably_meme
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Texture2D background;
        Texture2D playerVertTexture;
        Texture2D playerLeftTexture;
        Texture2D playerStandTexture;
        Texture2D weaponTexture;
        Texture2D enemyTexture;

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
            playerVertTexture = Content.Load<Texture2D>("player vertical");
            playerLeftTexture = Content.Load<Texture2D>("player left");
            playerStandTexture = Content.Load<Texture2D>("player");
            player = new Player(new Vector2(GraphicsDevice.PresentationParameters.Bounds.Width / 2,
                GraphicsDevice.PresentationParameters.Bounds.Height / 2), 2, playerLeftTexture, playerVertTexture, playerStandTexture, 15);
            player.setSpeed(2.0);
            enemyTexture = Content.Load<Texture2D>("enemy");
            enemies = new List<Enemy>();
            


            weaponTexture = Content.Load<Texture2D>("ak-47");
            player.changeWeapon(new Weapon(player.getPosition(), 2, weaponTexture, 5, (float)2.0));
            player.weapon.changeOrigin(new Vector2(0, 0));
            player.weapon.changeBulletsTexture(weaponTexture);
            this.IsMouseVisible = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("terrain");
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
                //player.collision(enemy);
            });
            enemyTexture = Content.Load<Texture2D>("enemy");
            if (gameTime.TotalGameTime.TotalSeconds % 2 == 0)
                enemies.Add(new Enemy(GameStaff.randomEnemyPosition(), 10, enemyTexture, 30));
            player.weapon.move();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.PresentationParameters.Bounds, Color.White);
            spriteBatch.End();
            player.draw(spriteBatch);
            enemies.ForEach(delegate (Enemy enemy) { enemy.draw(spriteBatch); });
            player.weapon.draw(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, GraphicsDevice.PresentationParameters.Bounds.Width.ToString(), new Vector2(100, 100), Color.Yellow);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
