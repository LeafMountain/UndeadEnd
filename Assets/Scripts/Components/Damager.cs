using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Damager : MonoBehaviour {

    [SerializeField]
    int damage;

    public void Damage (GameObject go)
    {
        if(go.GetComponent<Health>()){
            go.GetComponent<Health>().ModifyHealth(damage);
        }
    }
}
