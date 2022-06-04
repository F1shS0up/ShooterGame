using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Player
{
    public Object obj;
    public Player(Object pObj)
    {
        obj = pObj;
    }
    public void Update(GameTime gameTime)
    {
        obj.Update(gameTime);
    }
}

