using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelReader.GameFrameWork
{
    class EnvironmentGraphics : SpriteObject
    { 
        //-------------------------------------------------------------------------------------
        // Class constructors

        public EnvironmentGraphics (GameHost game)
            : base(game)
        {
            SpriteColor = Color.White;
        }

        public EnvironmentGraphics(GameHost game, Vector2 position)
            : this(game)
        {
            // Store the provided position
            Position = position;
        }

        public EnvironmentGraphics(GameHost game, Vector2 position, Texture2D texture)
            : this(game, position)
        {
            // Store the provided texture
            SpriteTexture = texture;
        }
    }
}
