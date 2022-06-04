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

    private SpriteSheet spriteSheet;

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
    public void Update()
    { 
        Vector2 pos = position + velocity;
        rectangle.X = (int)pos.X + spriteSheet.originWidth;
        rectangle.Y = (int)pos.Y + spriteSheet.originHeight;
        if (Collision.CheckCollision(rectangle))
        {
            rectangle.X = (int)position.X + spriteSheet.originWidth;
            rectangle.Y = (int)position.Y + spriteSheet.originHeight;
        }
        else
        {
            position = pos;
        }
    }
}


