using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Collectible : MonoBehaviour
{   
    public bool autoDestroy = true;

    public event EventHandler<EventArgs> Collected;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OnCollected();
            if (autoDestroy) Destroy(gameObject);
        }
    }
    
    private void OnCollected()
    {
        Collected?.Invoke(this, EventArgs.Empty);
    }
}
