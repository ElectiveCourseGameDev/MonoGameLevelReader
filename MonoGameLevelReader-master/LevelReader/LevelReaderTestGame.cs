using System.Threading.Tasks;
using System.Xml;
using LevelReader.GameFrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelReader
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LevelReaderTestGame : GameHost
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private Texture2D _tiles;
        private TiledMap _level;
        private bool _levelLoaded = false;
        private string _levelInfo;
        private SpriteFont _font;
        private MapObject _mapObject;
        private KeyboardState _keyboardState;

        public LevelReaderTestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
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
             _tiles = Content.Load<Texture2D>("tiles_spritesheet");

            _font = Content.Load<SpriteFont>("MonoLog");

            _level = new TiledMap("Levels/levelTest.tmx");

            
            _mapObject = new MapObject(this, new Vector2(0,0), _tiles, _level, _font);
            //_mapObject.Scale = new Vector2(2,2);
            GameObjects.Add(_mapObject);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // The map can be moved with the position Property...
            // future improvemnts.... only draw visible tiles!
            _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Keys.Left)) _mapObject.PositionX+=4;
            if (_keyboardState.IsKeyDown(Keys.Right)) _mapObject.PositionX -= 4;
            if (_keyboardState.IsKeyDown(Keys.Up)) _mapObject.PositionY -= 4;
            if (_keyboardState.IsKeyDown(Keys.Down)) _mapObject.PositionY += 4;

            if (_keyboardState.IsKeyDown(Keys.Left) && _keyboardState.IsKeyDown(Keys.RightControl))
                _mapObject.PositionX = 0;

            if (_keyboardState.IsKeyDown(Keys.Up) && _keyboardState.IsKeyDown(Keys.RightControl))
                _mapObject.PositionY = 0;


            base.Update(gameTime);
        }

        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            
            _spriteBatch.Begin();
            foreach (SpriteObject so in GameObjects)
            {
               // my MapObject is added to the list of GameObjects
               so.Draw(gameTime, _spriteBatch);
            }

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
