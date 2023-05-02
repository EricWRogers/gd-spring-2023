using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Box : MonoBehaviour
{
    public SceneController sc;
    public List<string> tagsKillBox;

    void Start()
    {
        sc = FindObjectOfType<SceneController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsKillBox.Contains(other.gameObject.tag))
        {
            sc.Reload();
        }
    }
}
