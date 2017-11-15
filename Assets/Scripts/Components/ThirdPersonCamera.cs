using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    [Range(2, 50)]
    public float cameraHeight = 15;
    [Range(0, 90)]
    public float cameraAngle = 70;

    void LateUpdate(){
        transform.eulerAngles = new Vector3(cameraAngle, 0, 0);
        
        if(target != null){
            transform.position = target.position - transform.forward * cameraHeight;
        }
    }
}
