using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Collectable : MonoBehaviour {
    public UnityEvent onCollected;
    public UnityEvent onDropped;

    public void OnCollected(Collider col){
        Collector collector = col.GetComponent<Collector>();

        if(collector){
            collector.Collect(this);
            onCollected.Invoke();
        }
    }

    public void Drop(){
        transform.SetParent(null);
        onDropped.Invoke();
    }
}
