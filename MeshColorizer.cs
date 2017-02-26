using UnityEngine;
using System.Collections;

public class MeshColorizer : Colorizer
{
    public int materialIndex = 0;
    public string colorProperty = "_Color";

    MeshRenderer meshRenderer;

    public override void setColor(Color c)
    {
        if (meshRenderer == null)
            meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        if (materialIndex >= 0 && materialIndex < meshRenderer.materials.Length)
        {
            if (meshRenderer.materials[materialIndex].HasProperty(colorProperty))
            {
                color = c;
                meshRenderer.materials[materialIndex].SetColor(colorProperty, color);
            }
        }
    }

    public override void setColor(float r, float g, float b)
    {
        if (meshRenderer == null)
            meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        if (materialIndex >= 0 && materialIndex < meshRenderer.materials.Length)
        {
            if (meshRenderer.materials[materialIndex].HasProperty(colorProperty))
            {
                color.r = Mathf.Clamp01(r);
                color.g = Mathf.Clamp01(g);
                color.b = Mathf.Clamp01(b);
                color.a = meshRenderer.materials[materialIndex].GetColor(colorProperty).a;
                meshRenderer.materials[materialIndex].SetColor(colorProperty, color);
            }
        }
    }

    public override void setAlpha(float a)
    {
        if (meshRenderer == null)
            meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        if (materialIndex >= 0 && materialIndex < meshRenderer.materials.Length)
        {
            if (meshRenderer.materials[materialIndex].HasProperty(colorProperty))
            {
                Color color = meshRenderer.materials[materialIndex].GetColor(colorProperty);
                color.a = Mathf.Clamp01(a);
                meshRenderer.materials[materialIndex].SetColor(colorProperty, color);
            }
        }
    }

    public override Color getColor()
    {
        if (meshRenderer == null)
            meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        if (materialIndex >= 0 && materialIndex < meshRenderer.materials.Length)
        {
            if (meshRenderer.materials[materialIndex].HasProperty(colorProperty))
            {
                return meshRenderer.materials[materialIndex].GetColor(colorProperty);
            }
        }
        return new Color(0, 0, 0, 0);
    }
}
