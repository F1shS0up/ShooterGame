using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


class SpriteSheet
{
    private Dictionary<string, (int, int, int)> animationKeys; //All the animations values: start int, end int, speed
    private int currentSprite;
    private string currentAnim;
    private int blockWidth, blockHeight; //Block that will nbe animating
    public int sizeWidth, sizeHeight, originWidth, originHeight;// the size and origin for collision
    private Texture2D texture;
    float time;
    

    public SpriteSheet(Dictionary<string, (int, int, int)> pKeys, Texture2D pTexture,Vector2 startPosition ,int pBlockWidth, int pBlockHeight, int pSizeWidth = 0, int pSizeHeight = 0, int pOriginWidth = 0, int pOriginHeight = 0)
    {
        animationKeys = pKeys;

        blockWidth = pBlockWidth;
        blockHeight = pBlockHeight;

        if(pSizeWidth != 0) { sizeWidth = pSizeWidth; }
        else { sizeWidth = blockWidth; }

        if (pSizeHeight != 0) { sizeHeight = pSizeHeight; }
        else { sizeHeight = blockHeight; }

        originWidth = pOriginWidth;
        originHeight = pOriginHeight;

        time = 0;

       

        texture = pTexture;
        SetCurrentAnimaton("null");
        SpriteSheetManager.spriteSheets.Add(this);
    }
    public void SetCurrentAnimaton(string name)
    {
        time = 0;
        currentAnim = name;
        currentSprite = animationKeys[currentAnim].Item1;
    }
    public void Update(GameTime gameTime)
    {
        if (time > animationKeys[currentAnim].Item3)
        {

            currentSprite++;
            if (currentSprite > animationKeys[currentAnim].Item2)
            {
               

                currentSprite = animationKeys[currentAnim].Item1;
            }
            time = 0;
        }
        else
        {
            time = time + (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        }
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle x = new Rectangle(blockWidth * (currentSprite - 1), 0, blockWidth, blockHeight);
        spriteBatch.Draw(texture, position, x, Color.White);
    }

}

