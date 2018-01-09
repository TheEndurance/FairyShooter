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
        public Sprite HelpScreen;
        public Sprite AboutScreen;
        public Fairy Fairy;
        public GameObjects GameObjects;
        public ProjectileManager ProjectileManager;
        public CollisionManager CollisionManager;
        public EnemyManager EnemyManager;
        public ExplosionManager ExplosionManager;
        public SoundManager SoundManager;
        public GameState GameState;
        public StatusManager GameStatusManager;
        public KeyboardState CurrentKeyboardState;
        public KeyboardState PreviousKeyboardState;
        public SpriteFont GameFont;
        public int Score;
        public Rectangle GameBounds;

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

            
            GameBounds = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            GameObjects = new GameObjects();
            SoundManager = new SoundManager(Content);
            TitleScreen = new Sprite(Content.Load<Texture2D>("animatedtitlescreen"), Vector2.Zero, GameBounds,2,2,8);
            GameOverScreen = new Sprite(Content.Load<Texture2D>("animatedgameover"), Vector2.Zero, GameBounds,1,5,8);
            PausedScreen = new Sprite(Content.Load<Texture2D>("paused"), Vector2.Zero, GameBounds);
            HelpScreen = new Sprite(Content.Load<Texture2D>("howtoplay"), Vector2.Zero, GameBounds);
            AboutScreen = new Sprite(Content.Load<Texture2D>("about"), Vector2.Zero, GameBounds);
            ProjectileManager = new ProjectileManager(Content,SoundManager);
            EnemyManager = new EnemyManager(Content.Load<Texture2D>("tealenemy"), GameBounds);
            Fairy = new Fairy(Content.Load<Texture2D>("phoenix"), Vector2.Zero, GameBounds);
            CollisionManager = new CollisionManager(GameObjects);
            ExplosionManager = new ExplosionManager(Content.Load<Texture2D>("explosion"), GameBounds,SoundManager);

            GameObjects.Fairy = Fairy;
            GameObjects.CollisionManager = CollisionManager;
            GameObjects.ProjectileManager = ProjectileManager;
            GameObjects.EnemyManager = EnemyManager;
            GameObjects.ExplosionManager = ExplosionManager;
            GameObjects.SoundManager = SoundManager;
            

            GameFont = Content.Load<SpriteFont>("GameFont");
            GameStatusManager = new StatusManager(GameFont,GameBounds,EnemyManager);

            SoundManager.PlayBackgroundMusic();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            CurrentKeyboardState = Keyboard.GetState(PlayerIndex.One);
            GameState.Update(gameTime, GameObjects);
            PreviousKeyboardState = CurrentKeyboardState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            GameState.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Resets the game by calling LoadContent
        /// </summary>
        public void ResetGame()
        {
            this.LoadContent();
        }
    }
}
