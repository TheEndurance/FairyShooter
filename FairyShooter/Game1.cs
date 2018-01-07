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
        private Fairy _fairy;
        private IList<Projectile> _projectiles;
        private GameObjects _gameObjects;
        private ProjectileManager _projectileManager;
        private CollisionManager _collisionManager;
        private EnemyManager _enemyManager;
        private ExplosionManager _explosionManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here
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
            _gameObjects = new GameObjects();
            //setup managers
            _projectileManager = new ProjectileManager(Content.Load<Texture2D>("purpleprojectile"));
            _enemyManager = new EnemyManager(Content.Load<Texture2D>("tealenemy"), gameBounds);
            _fairy = new Fairy(Content.Load<Texture2D>("phoenix"), Vector2.Zero, gameBounds);
            _collisionManager = new CollisionManager(_gameObjects);
            _explosionManager = new ExplosionManager(Content.Load<Texture2D>("explosion"), gameBounds);
            _gameObjects.Fairy = _fairy;
            _gameObjects.CollisionManager = _collisionManager;
            _gameObjects.ProjectileManager = _projectileManager;
            _gameObjects.EnemyManager = _enemyManager;
            _gameObjects.ExplosionManager = _explosionManager;


            _enemyManager.CreateEnemy();
            _enemyManager.CreateEnemy();
            _enemyManager.CreateEnemy();


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
            _fairy.Update(gameTime, _gameObjects);
            _enemyManager.Update(gameTime, _gameObjects);
            _projectileManager.Update(gameTime, _gameObjects);
            _explosionManager.Update(gameTime, _gameObjects);
            _collisionManager.Update(gameTime);

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

            _fairy.Draw(_spriteBatch);
            _projectileManager.Draw(_spriteBatch);
            _enemyManager.Draw(_spriteBatch);
            _explosionManager.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
