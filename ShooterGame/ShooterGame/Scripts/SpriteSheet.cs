using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


class SpriteSheet
{
    private Dictionary<string, (int, int, int)> animationKeys; //All the animations values: start int, end int, speed
    private int currentSpeed, currentSprite, currentAnim;
    private int blockWidth, blockHeight; //Block that will nbe animating
    private int sizeWidth, sizeHeight, originWidth, originHeight;

}
