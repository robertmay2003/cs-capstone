using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public ParticleSystem collisionParticle;
    
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        Color color = Color.HSVToRGB(Random.value, 0.4f, 1f);
        _renderer.color = color;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ParticleSystem p = Instantiate(collisionParticle, other.contacts[0].point, Quaternion.identity);
        p.startColor = _renderer.color;
        p.transform.localScale *= other.contacts[0].normalImpulse / 25f;
        
        Destroy(p.gameObject, p.main.duration);
    }
}
