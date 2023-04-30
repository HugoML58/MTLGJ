using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem explode1 = GameObject.Find("Effect_26_Explosion_1").GetComponent<ParticleSystem>();
        ParticleSystem explode2 = GameObject.Find("Effect_26_Explosion_2").GetComponent<ParticleSystem>();
        ParticleSystem explode3 = GameObject.Find("Effect_26_Explosion_3").GetComponent<ParticleSystem>();
        explode1.Play();
        explode2.Play();
        explode3.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
