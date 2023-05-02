using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("collisioncontrol"));

    }
}