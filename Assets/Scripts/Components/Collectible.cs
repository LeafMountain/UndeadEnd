using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Collectible : MonoBehaviour {
    public UnityEvent onCollected;
    public UnityEvent onDropped;

    public void Collect(GameObject go){
        Collector collector = go.GetComponent<Collector>();

        if(collector){
            collector.Collect(gameObject);
            onCollected.Invoke();
        }
    }

    public void Drop(){
        onDropped.Invoke();
    }
}
