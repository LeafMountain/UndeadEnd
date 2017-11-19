using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    [Range(2, 50)]
    public float cameraHeight = 15;
    [Range(0, 90)]
    public float cameraPitch = 70;
    [Range(0, 360)]
    public float cameraYaw = 0;

    void LateUpdate(){
        transform.eulerAngles = new Vector3(cameraPitch, cameraYaw, 0);
        
        if(target != null){
            transform.position = target.position - transform.forward * cameraHeight;
        }
    }
}
