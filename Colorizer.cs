using UnityEngine;
using System.Collections;

public abstract class Colorizer : MonoBehaviour
{
    protected Color color;
    public abstract void setColor(Color c);
    public abstract void setColor(float r, float g, float b);
    public abstract void setAlpha(float a);

    public abstract Color getColor();
}


public static class ColorizerExtensions
{
	public static void SetColor(this GameObject go, Color c)
	{
		Colorizer[] colorizers = go.GetComponentsInChildren<Colorizer>();
		for (int i = 0; i < colorizers.Length; i++)
		{
			colorizers[i].setColor(c);
		}
	}

	public static void SetColor(this GameObject go, float r, float g, float b)
	{
		Colorizer[] colorizers = go.GetComponentsInChildren<Colorizer>();
		for (int i = 0; i < colorizers.Length; i++)
		{
			colorizers[i].setColor(r, g, b);
		}
	}

	public static void SetAlpha(this GameObject go, float a)
	{
		Colorizer[] colorizers = go.GetComponentsInChildren<Colorizer>();
		for (int i = 0; i < colorizers.Length; i++)
		{
			colorizers[i].setAlpha(a);
		}
	}
}