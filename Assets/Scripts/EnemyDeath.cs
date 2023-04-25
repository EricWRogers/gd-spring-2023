using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public List<string> tagsBoot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsBoot.Contains(other.gameObject.tag))
        {
            gameObject.SetActive(false);
            other.gameObject.transform.parent.gameObject.GetComponent<Player>().isKilledEnemy = true;
        }
    }
}
