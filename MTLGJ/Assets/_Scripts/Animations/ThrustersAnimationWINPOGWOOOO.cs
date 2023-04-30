using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustersAnimationWINPOGWOOOO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem thrust1 = GameObject.Find("Effect_19_Explosion_W").GetComponent<ParticleSystem>();
        ParticleSystem thrust2 = GameObject.Find("Effect_19_Particle_W").GetComponent<ParticleSystem>();
        ParticleSystem thrust3 = GameObject.Find("Effect_19_BreathFireSphere_W").GetComponent<ParticleSystem>();
        ParticleSystem thrust4 = GameObject.Find("Effect_19_BreathFireSphere_2_W").GetComponent<ParticleSystem>();
        thrust1.Play();
        thrust2.Play();
        thrust3.Play();
        thrust4.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
