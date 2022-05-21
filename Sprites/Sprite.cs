using App05MonoGame.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace App05Game
{
  
    /// <summary>
    /// Create a sprite that is active, alive and
    /// visible with no speed, rotation or scale
    /// facing east (to the right)
    /// </summary>
    /// <Author>
    /// Jyoti Devi & Narinder Kaur 
    /// </Author> 
    /// 
    public class Sprite
       //structures 
    {
        public Rectangle Boundary { get; set; }

        public Vector2 StartPosition { get; set; }  

        public Vector2 Position { get; set; }

        //properties 
        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }
        public int Speed { get; set; }
        public Texture2D Image { get; set; }
        public bool isActive { get; set; }
        public bool isAlive { get; set; }
        public int Width
        {
            get { return Image.Width; }
        }
        public int Height
        {
            get { return Image.Height; }
        }
        // the rectangle occupied by the unscaled image 

        public Rectangle BoundingBox
        {
            get 
            {
                return new Rectangle(
                    (int)Position.X, (int)Position.Y, Width, Height);
             }
        }

        //variables 

        protected float deltaTime; 

        /// <summary>
        /// Constructor sets the main image and starting position of
        /// the Sprite as a Vector2
        /// </summary>
        public Sprite(Texture2D image, int x, int y) 
        {
            Image = image;
            Position = new Vector2(x, y);
            StartPosition = Position;
            MaxSpeed = 1000;
            MinSpeed = 200;
            Speed = MinSpeed;

            isActive = true;
            isAlive = true;
        }
        public Vector2 GetCenterPosition()
        {
            return new Vector2(Position.X - Image.Width/ 2, 
                            Position.Y - Image.Height / 2);
        }

        public void ResetPosition()
        {
            Position = StartPosition;
        }

        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState keyState = Keyboard.GetState();
            float newX, newY;
            if (keyState.IsKeyDown(keys.Right))
            {
                newX = Position.X + Speed * deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            if(keyState.IsKeyDown(keys.Left))
            {
                newX = Position.X - Speed * deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            if (keyState.IsKeyDown(keys.Up))
            {
                newY = Position.Y - Speed * deltaTime;
                Position = new Vector2(newY, Position.X);
            }
            if (keyState.IsKeyDown(keys.Down))
            {
                newY = Position.Y + Speed * deltaTime;
                Position = new Vector2(newY, Position.X);
            }
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (isActive && isAlive)
            {
                Rotation += MathHelper.ToRadians(RotationSpeed);
                Vector2 newPosition = Position + ((Direction * Speed) * deltaTime);

                if (Boundary.Width == 0 || Boundary.Height == 0)
                {
                    Position = newPosition;
                }
                else if (newPosition.X >= Boundary.X &&
                    newPosition.Y >= Boundary.Y &&
                    newPosition.X + Width < Boundary.X + Boundary.Width &&
                    newPosition.Y + Height < Boundary.Y + Boundary.Height)
                {
                    Position = newPosition;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (debug)
            {
                TextHelper.DrawString(
                    $"({Position.X:0},{Position.Y:0})", Position);
            }

            if (Origin == Vector2.Zero)
                Origin = new Vector2(Width / 2, Height / 2);

            if(isActive)
            {
                spriteBatch.Draw
                    (Image,
                     Position,
                     null,
                     Color.White, Rotation, Origin,
                     Scale, SpriteEffects.None, 1);
            }
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
