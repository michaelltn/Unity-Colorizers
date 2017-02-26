using UnityEngine;
using System.Collections;

public class ParticleSystemColorizer : Colorizer
{
    new ParticleSystem particleSystem;

    public static void SetCurrentParticleColor(ParticleSystem particleSystem, Color color)
    {
        UnityEngine.ParticleSystem.Particle[] particles = new UnityEngine.ParticleSystem.Particle[particleSystem.maxParticles];
        int particleCount = particleSystem.GetParticles(particles);

        Color temp;
        for (int i = 0; i < particleCount; i++)
        {
            temp = particles[i].color;
            temp.r = color.r;
            temp.g = color.g;
            temp.b = color.b;
            particles[i].color = temp;
        }
        particleSystem.SetParticles(particles, particleCount);
    }

    public override void setColor(Color c)
    {
        if (particleSystem == null)
            particleSystem = this.gameObject.GetComponent<ParticleSystem>();

        particleSystem.startColor = color = c;
        SetCurrentParticleColor(particleSystem, color);
    }

    public override void setColor(float r, float g, float b)
    {
        if (particleSystem == null)
            particleSystem = this.gameObject.GetComponent<ParticleSystem>();

        color.r = Mathf.Clamp01(r);
        color.g = Mathf.Clamp01(g);
        color.b = Mathf.Clamp01(b);
        color.a = particleSystem.startColor.a;
        particleSystem.startColor = color;
        SetCurrentParticleColor(particleSystem, color);
    }

    public override void setAlpha(float a)
    {
        if (particleSystem == null)
            particleSystem = this.gameObject.GetComponent<ParticleSystem>();

        Color color = particleSystem.startColor;
        color.a = Mathf.Clamp01(a);
        particleSystem.startColor = color;
    }

    public override Color getColor()
    {
        if (particleSystem == null)
            particleSystem = this.gameObject.GetComponent<ParticleSystem>();

        return particleSystem.startColor;
    }
}
