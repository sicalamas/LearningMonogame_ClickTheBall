using ClickTheBall.GameClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;

namespace ClickTheBall
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Ball ball;
        Player player;
        
        public GameMain()
        {
            GameConfig.loadConfig("Config.ini");

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GameConfig.WIDTH;
            graphics.PreferredBackBufferHeight = GameConfig.HEIGHT;
            graphics.IsFullScreen = GameConfig.FULLSCREEN;
            Window.IsBorderless = GameConfig.BORDERLESS;

            Content.RootDirectory = "Content";

            ball = new Ball();
            player = new Player(ball);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            ball.init();
            player.init();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GameConfig.loadTexture("Graphics/SpriteSheet", Content);
            GameConfig.loadFont("Graphics/PixelTypeFont", Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            ball.update(gameTime);
            player.update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(GameConfig.bgColor);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);

            // Drawing rotines are put here
            spriteBatch.DrawString
                (
                GameConfig.gameFont,
                player.score.ToString(),
                new Vector2(2 * GameConfig.SCALE, 2 * GameConfig.SCALE),
                GameConfig.spColor,
                0.0f,
                new Vector2(0, 0),
                GameConfig.SCALE,
                SpriteEffects.None,
                0
                );

                spriteBatch.DrawString
                (
                GameConfig.gameFont,
                "Debug velocity:\n" +
                ball.getVelocity().ToString() +
                "\nDebug position:\n" +
                ball.getPosition().ToString(),
                new Vector2(2 * GameConfig.SCALE, 12 * GameConfig.SCALE),
                GameConfig.spColor,
                0.0f,
                new Vector2(0, 0),
                GameConfig.SCALE / 2,
                SpriteEffects.None,
                0
                );

            spriteBatch.DrawRectangle
                (
                    new RectangleF(0.0f, 0.0f, GameConfig.WIDTH, GameConfig.HEIGHT),
                    GameConfig.spColor,
                    4.0f
                );

            ball.draw(spriteBatch);
            player.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
