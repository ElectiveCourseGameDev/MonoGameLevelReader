using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelReader.GameFrameWork
{
 /// <summary>
 /// This class is used to draw tiled based maps contained in a TiledMap class
 /// supported Position,  scale, draw
 /// </summary>
    class MapObject : SpriteObject
    {
        private TiledMap _tiledMap;
        private SpriteFont _font;
        private int _tilesPrRow ;

        public MapObject(GameHost game) : base(game)
        {
        }

        public MapObject(GameHost game, Vector2 position) : base(game, position)
        {
        }

        public MapObject(GameHost game, Vector2 position, Texture2D texture, TiledMap tiledMap) : base(game, position, texture)
        {
            _tiledMap = tiledMap;
            
        }
        public MapObject(GameHost game, Vector2 position, Texture2D texture, TiledMap tiledMap, SpriteFont font)
            : base(game, position, texture)
        {
            _font = font;
            _tiledMap = tiledMap;
            _tilesPrRow = _tiledMap.ImageWidth / (_tiledMap.TileWidth+_tiledMap.TileSetSpacing);

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            foreach (String layername in _tiledMap.LayerNames)
            {



                for (int i = 0; i < _tiledMap.Width; i++)
                {
                    for (int j = 0; j < _tiledMap.Height; j++)
                    {
                        int gidValue = _tiledMap.Layers[layername][j, i];

                        if (gidValue != 0)
                        {
                            int x = (gidValue - 1)%_tilesPrRow*(_tiledMap.TileWidth+_tiledMap.TileSetSpacing);
                            int y = (int) ((gidValue - 1)/_tilesPrRow)*(_tiledMap.TileHeight+_tiledMap.TileSetSpacing);
                            spriteBatch.Draw(
                                SpriteTexture,
                                new Vector2(i*_tiledMap.TileWidth*ScaleX + PositionX, j*_tiledMap.TileHeight*ScaleY + PositionY),
                                new Rectangle(x, y, _tiledMap.TileWidth, _tiledMap.TileHeight),
                                Color.White,
                                0f,
                                new Vector2(0, 0),
                                Scale,
                                SpriteEffects.None,
                                0f);
                        }
                    }
                }
            }

            // used to print the tiles numbers (debugging...)
            //for (int i = 0; i < _tiledMap.Width; i++)
            //{
            //    for (int j = 0; j < _tiledMap.Height; j++)
            //    {

            //        int gidValue = _tiledMap.Layers[_tiledMap.LayerNames[0]][j, i];

            //        int x = (gidValue % 12 - 1) * 72;
            //        int y = (int)((gidValue - 1) / 12) * 72;

            //        spriteBatch.DrawString(_font, gidValue.ToString(), new Vector2(i * 70, j * 70), Color.White);
            //        spriteBatch.DrawString(_font, "{" + x + ";" + y + "}", new Vector2(70 * i, 70 * j + 20), Color.Orange);

            //    }
            //}
        }
    }
}
