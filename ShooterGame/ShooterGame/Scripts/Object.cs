using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Object
{
    public  Vector2 velocity;
    private Vector2 position;

    private Rectangle rectangle;

    public SpriteSheet spriteSheet;

    public Object(SpriteSheet pSpriteSheet, Vector2 startPos)
    {
        rectangle = new Rectangle((int)startPos.X + pSpriteSheet.originWidth, (int)startPos.Y + pSpriteSheet.originHeight, pSpriteSheet.sizeWidth, pSpriteSheet.sizeHeight);
        spriteSheet = pSpriteSheet;
        position = startPos;
    }
    public Object(SpriteSheet pSpriteSheet, Rectangle pRectangle, Vector2 startPos)
    {
        rectangle = pRectangle;
        spriteSheet = pSpriteSheet;
        position = startPos;
    }
    public void Update(GameTime gameTime)
    { 
        //Create position that will occur in this frame, then set rectangle to that position
        Vector2 pos = position + velocity * (int)gameTime.ElapsedGameTime.TotalMilliseconds;
        rectangle.X = (int)pos.X + spriteSheet.originWidth;
        rectangle.Y = (int)pos.Y + spriteSheet.originHeight;

        //Check if it is going to collide
        if (Collision.CheckCollision(rectangle))
        {
            //set the position to frame before
            rectangle.X = (int)position.X + spriteSheet.originWidth;
            rectangle.Y = (int)position.Y + spriteSheet.originHeight;
        }
        else
        {
            //set the actual position to position created before
            position = pos;
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteSheet.Draw(spriteBatch, position);
    }
}


