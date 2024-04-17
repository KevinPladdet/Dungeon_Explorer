using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    private ParticleSystem particle;

    private float lastTime;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        lastTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        float deltaTime = Time.realtimeSinceStartup - lastTime;

        if (Time.timeScale == 0f)
        {
            particle.Simulate(deltaTime, false, false);
        }

        lastTime = Time.realtimeSinceStartup;
    }
}
