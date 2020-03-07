using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleScript : MonoBehaviour
{
    public ParticleSystem emmiter;

    void Start()
    {
        StartCoroutine(Implode());
    }

    IEnumerator Implode()
    {
        if (!emmiter.isPlaying)
        {
            emmiter.Play();
        }

        //let the system do it's thing for a bit
        yield return new WaitForSeconds(0.1f);

        //stop emission
        emmiter.emissionRate = 0f;

        //allocate reference array
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[emmiter.particleCount];


        //this loop executes over several frames
        // - get particle list
        // - update each particle's position
        // - set particle list
        // - wait one frame
        for (float t = 0f; t < 1f; t += 0.1f)
        {
            int count = emmiter.GetParticles(particles);
            for (int i = 0; i < count; i++)
            {
                particles[i].position = Vector3.Lerp(particles[i].position, transform.position, t);
            }
            emmiter.SetParticles(particles, count);

            yield return null;
        }

        //once loop is finished, clear particles
        emmiter.Clear();
    }
}
