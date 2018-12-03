using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using probably_meme.Objects;

namespace probably_meme
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        private AnimatedSprite animatedSprite;

        Texture2D background;
        Texture2D playerVertTexture;
        Texture2D playerLeftTexture;
        Texture2D playerStandTexture;

        Player player;
        
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
            player.changeWeapon(new Weapon(player.getPosition(), 2, playerStandTexture, 5, (float)2.0));
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
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.PresentationParameters.Bounds, Color.White);
            spriteBatch.End();
            player.draw(spriteBatch);

            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, GraphicsDevice.PresentationParameters.Bounds.Width.ToString(), new Vector2(100, 100), Color.Yellow);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
