using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{
    public enum PointOfView { ThirdPerson, FirstPerson, FreeMovement }
    public PointOfView pointOfView;

    public Transform target;

    [Space]
    
    [Header("Third-Person Settings")]
    public bool followTarget;
    public bool limitZoom;
    [Range(1, 50)]
    public float zoom = 15;
    public Vector2 zoomMinMax = Vector2.zero;

    //Smoothing
    public float smoothing;
    Vector3 currentVelocity;

    [Range(0, 90)]
    public float pitch = 80;
    [Range(0, 360)]
    public float yaw = 45;

    [Header("First-Person Settings")]
    [Range(0, 5)]
    public float height;

    void LateUpdate(){
        AdjustCamera();
    }

    public void AdjustCamera(){
        switch (pointOfView)
		{
			case (TopDownCamera.PointOfView.FirstPerson):
				FirstPerson();
				break;
			case (TopDownCamera.PointOfView.ThirdPerson):
				ThirdPerson();
				break;
			case (TopDownCamera.PointOfView.FreeMovement):
				FreeMovement();
				break;
		}
    }

    public void Rotate(float pitch, float yaw, bool add = false){
        if(add){
            transform.eulerAngles += new Vector3(pitch, yaw, 0);
        } else {
            transform.eulerAngles = new Vector3(pitch, yaw, 0);            
        }
    }

    public void Move(Vector3 input){
        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized * input.z;
        Vector3 right = transform.right * input.x;

        Vector3 moveDir = forward + right;

        Vector3 moveTo = moveDir;
        
        if(moveDir != Vector3.zero){
            moveTo = Vector3.SmoothDamp(transform.position, transform.position + moveDir, ref currentVelocity, smoothing);

            transform.position = moveTo;
            // transform.Translate(moveDir, Space.World);
        }
    }

    public void Move(Vector2 input){
        Move(new Vector3(input.x, 0, input.y));
    }

    void Test(){
        
    }

    public void Zoom(float value, bool add = false){
        if(add){
            zoom += value;
        } else {
            zoom = value;
        }

        if(!limitZoom){
            zoom = Mathf.Clamp(zoom, zoomMinMax.x, zoomMinMax.y);
        }

        transform.position = target.position - transform.forward * zoom;
    }

    void FirstPerson(){
        transform.position = target.position + transform.up * height;
        transform.rotation = target.rotation;
    }

    void ThirdPerson(){
        if(followTarget){
            transform.position = target.position - transform.forward * zoom;
        }

        // Zoom(zoom);
        Rotate(pitch, yaw);
    }

    void FreeMovement(){

    }
}
