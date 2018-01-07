using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace FairyShooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        public Sprite TitleScreen;
        public Sprite GameOverScreen;
        public Sprite PausedScreen;
        public Fairy Fairy;
        public GameObjects GameObjects;
        public ProjectileManager ProjectileManager;
        public CollisionManager CollisionManager;
        public EnemyManager EnemyManager;
        public ExplosionManager ExplosionManager;
        public GameState GameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameState = new TitleScreenState(this);
            IsMouseVisible = true;
       
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            var gameBounds = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            GameObjects = new GameObjects();
            //setup managers
            TitleScreen = new Sprite(Content.Load<Texture2D>("animatedtitlescreen"), Vector2.Zero, gameBounds,2,2,8);
            GameOverScreen = new Sprite(Content.Load<Texture2D>("animatedgameover"), Vector2.Zero, gameBounds,1,5,8);
            PausedScreen = new Sprite(Content.Load<Texture2D>("paused"), Vector2.Zero, gameBounds);
            ProjectileManager = new ProjectileManager(Content.Load<Texture2D>("purpleprojectile"));
            EnemyManager = new EnemyManager(Content.Load<Texture2D>("tealenemy"), gameBounds);
            Fairy = new Fairy(Content.Load<Texture2D>("phoenix"), Vector2.Zero, gameBounds);
            CollisionManager = new CollisionManager(GameObjects);
            ExplosionManager = new ExplosionManager(Content.Load<Texture2D>("explosion"), gameBounds);
            GameObjects.Fairy = Fairy;
            GameObjects.CollisionManager = CollisionManager;
            GameObjects.ProjectileManager = ProjectileManager;
            GameObjects.EnemyManager = EnemyManager;
            GameObjects.ExplosionManager = ExplosionManager;



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

            GameState.Update(gameTime, GameObjects);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            GameState.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
