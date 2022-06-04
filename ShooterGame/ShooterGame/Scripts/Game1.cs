using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ShooterGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        SpriteSheet player;

        Vector2 scale;

        RenderTarget2D changing, nonChanging;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
           
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        void graphicsSettings()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            scale = new Vector2(_graphics.PreferredBackBufferWidth / 480, _graphics.PreferredBackBufferHeight / 270);
            _graphics.ApplyChanges();
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphicsSettings();

            changing = new RenderTarget2D(GraphicsDevice, 480, 270);
            nonChanging = new RenderTarget2D(GraphicsDevice, 480, 270);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new SpriteSheet(new Dictionary<string, (int, int, int)> { { "null", (0, 0, 0) }, { "default", (1, 4,100) } }, 
                Content.Load<Texture2D>("Player-Sheet"), 
                Vector2.Zero, 64, 64);
            player.SetCurrentAnimaton("default");
            // TODO: use this.Content to load your game content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            SpriteSheetManager.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            DrawChanging();
            DrawNonChanging();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            spriteBatch.Draw(nonChanging, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(changing, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        void DrawChanging()
        {
            GraphicsDevice.SetRenderTarget(changing);
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            player.Draw(spriteBatch);
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
        }
        void DrawNonChanging()
        {
            GraphicsDevice.SetRenderTarget(nonChanging);
            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
           
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
        }
    }
}
