using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{
    public enum PointOfView { ThirdPerson, FirstPerson, FreeMovement }
    public PointOfView pointOfView;

    public Transform target;

    [Space]
    
    [Header("Third-Person Settings")]    
    [Range(1, 50)]
    public float zoom = 15;
    [Range(0, 90)]
    public float pitch = 80;
    [Range(0, 360)]
    public float yaw = 45;

    [Header("First-Person Settings")]
    public float height;

    void LateUpdate(){
        AdjustCamera();
    }

    public void AdjustCamera(){
        float zoom = this.zoom;
        float pitch = this.pitch;
        float yaw = this.yaw;

        if(pointOfView == PointOfView.FirstPerson){
            zoom = 0;
            pitch = 0;
            yaw = 0;
        }

        
        if(target != null){
            transform.position = target.position - transform.forward * zoom;
        }
    }

    void FirstPersonAdjust(){
        transform.position = target.position + transform.up * height;
        transform.rotation = target.rotation;
    }

    void ThirdPersonCamera(){
        transform.position = target.position - transform.forward * zoom;        
    }

    public void Rotate(float pitch, float yaw){
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }

    public void Move(Vector3 input){
        Vector3 forward = transform.forward * input.z;
        Vector3 right = transform.right * input.x;
        Vector3 up = transform.up * input.y;

        Vector3 moveDir = forward + right + up;

        if(moveDir != Vector3.zero){
            transform.Translate(moveDir);
        }
    }

    public void Move(Vector2 input){
        Move(new Vector3(input.x, 0, input.y));
    }
}
