using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextColorizer : Colorizer
{
	Text uiText;
	Outline uiOutline;

	public override void setColor(Color c)
	{
		if (uiText == null)
			uiText = this.gameObject.GetComponent<Text>();

		uiText.color = color = c;
	}

	public override void setColor(float r, float g, float b)
	{
		if (uiText == null)
			uiText = this.gameObject.GetComponent<Text>();

		color.r = Mathf.Clamp01(r);
		color.g = Mathf.Clamp01(g);
		color.b = Mathf.Clamp01(b);
		color.a = uiText.color.a;
		uiText.color = color;
	}

	public override void setAlpha(float a)
	{
		if (uiText == null)
			uiText = this.gameObject.GetComponent<Text>();

		Color color = uiText.color;
		color.a = Mathf.Clamp01(a);
		uiText.color = color;
	}

	public override Color getColor()
	{
		if (uiText == null)
			uiText = this.gameObject.GetComponent<Text>();

		return uiText.color;
	}
		
}
