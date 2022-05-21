using App05Game.Controllers;
using App05Game.Screens;
using App05Game.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App05Game
/// <summary>
/// This game creates a variety of sprites as an example.  
/// There is no game to play yet. The spaceShip and the 
/// asteroid can be used for a space shooting game, the player, 
/// the coin and the enemy could be used for a pacman
/// style game where the player moves around collecting
/// random coins and the enemy tries to catch the player.
/// 
/// Last Updated 28 April 2022
/// 
/// </summary>
/// <authors>
/// Jyoti Devi And Narinder Kaur
/// </authors>
{
    public class App05Game : Game
    {
        #region Constants

        public const int HD_Game_Height = 720;
        public const int HD_Game_Width = 1280;

        public const string GameName = "Attacker";
        public const string ModuleName = "BNU CO453 2022";
        public const string AuthorNames = "Jyoti & Narinder ";
        public const string AppName = "App05: C# MonoGame";


        // Essential XNA objects for Graphics manipulation

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        private Texture2D playerImage;
        private Texture2D walkDownImage;
        private Texture2D walkUpImage;
        private Texture walkRightImage;
        private Texture2D walkLeftImage;

        private Texture2D monoGameBackgroundImage;
        private Texture2D coinsImage;

        private PlayerSprite player;

        // Screens

        private StartScreen startScreen;
        private CoinsScreen coinsScreen;

        #endregion

        /// <summary>
        /// Create a graphics manager and the root for
        /// all the game assets or content
        /// </summary>
        public App05Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = HD_Game_Width;
            graphics.PreferredBackBufferHeight = HD_Game_Height;

            graphics.ApplyChanges();

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerImage = Content.Load<Texture2D>("Player/player");
            walkDownImage = Content.Load<Texture2D>("Player/walkDown");
            walkUpImage = Content.Load<Texture2D>("Player/walkUp");
            walkRightImage = Content.Load<Texture2D>("Player/walkRight");
            walkLeftImage = Content.Load<Texture2D>("Player/walkLeft");
            monoGameBackgroundImage = Content.Load<Texture2D>("Player/monoGameBackground");
            coinsImage = Content.Load<Texture2D>("Player/coins");
            SetupSprites();
        }
        private void SetupSprites() 
        {
            player = new PlayerSprite(200,300);
            player.Image= playerImage;
        }


        /// <summary>
        /// Called 60 frames/per second and updates the positions
        /// of all the drawable objects
        /// </summary>
        /// <param name="gameTime">
        /// Can work out the elapsed time since last call if
        /// you want to compensate for different frame rates
        /// </param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape)) 
                Exit();
            player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Called 60 frames/per second and Draw all the 
        /// sprites and other drawable images here
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LawnGreen);

            spriteBatch.Begin();
            Vector2 position = new Vector2(0, 0);

            spriteBatch.Draw(
                monoGameBackgroundImage,position,Color.White);
            spriteBatch.Draw(player.Image,player.Position,Color.Yellow);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
