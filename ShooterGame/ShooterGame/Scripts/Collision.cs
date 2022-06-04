using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

static class Collision
{
    static List<Rectangle> collisions;
    public static bool CheckCollision(Rectangle A)
    {
        foreach (Rectangle B in collisions) 
        {
            if (A.Intersects(B))
            {
                return true;
            }
        }
        return false;
    }
    
}

