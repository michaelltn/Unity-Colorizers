using UnityEngine;
using System.Collections;

public class SpriteColorizer : Colorizer
{
    SpriteRenderer spriteRenderer;

    public override void setColor(Color c)
    {
        if (spriteRenderer == null)
            spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.color = color = c;
    }

    public override void setColor(float r, float g, float b)
    {
        if (spriteRenderer == null)
            spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        color.r = Mathf.Clamp01(r);
        color.g = Mathf.Clamp01(g);
        color.b = Mathf.Clamp01(b);
        color.a = spriteRenderer.color.a;
        spriteRenderer.color = color;
    }

    public override void setAlpha(float a)
    {
        if (spriteRenderer == null)
            spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(a);
        spriteRenderer.color = color;
    }

    public override Color getColor()
    {
        if (spriteRenderer == null)
            spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        return spriteRenderer.color;
    }
}
