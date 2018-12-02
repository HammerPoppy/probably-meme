using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace probably_meme
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Texture2D background;
        
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.PresentationParameters.Bounds, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();

            spriteBatch.DrawString(spriteFont, GraphicsDevice.PresentationParameters.Bounds.Width.ToString(), new Vector2(100, 100), Color.Yellow);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
