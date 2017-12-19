using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{    
    [Header("Auto Adjust Settings")]
    public bool enableAuto;
    public bool followTarget;
    public Transform[] targets;

    [Header("Orientation Settings")]
    [Range(0, 360)]
    public float pitch = 0;
    [Range(0, 360)]
    public float yaw = 0;
    [Range(0, 360)]
    public float roll = 0;

    public Vector3 offset;

    [Header("Zoom Settings")]
    public bool autoZoom;
    [Range(0, 50)]
    public float zoom = 15;
    public bool limitZoom;    
    public Vector2 zoomMinMax = Vector2.zero;

    [Header("Smoothing Settings")]
    public bool enableSmoothing;
    [Range(0, 1)]
    public float moveSmoothing = .5f;
    [Range(0, 1)]    
    public float zoomSmoothing = .5f;
    Vector3 currentVelocity;

    Bounds targetsBounds;
    Vector3 targetPosition;

    void LateUpdate(){
        if(enableAuto){
            AutoAdjustCamera();
        }

        Move(targetPosition);        
    }

    public void AutoAdjustCamera(){
        if(targets == null || targets.Length == 0){
            Debug.LogWarning("No target selected");
            return;
        }

        targetsBounds = EncapsulateTargets(targets);

        //Move
        if(followTarget){
            targetPosition = GetFollowPosition();
            targetPosition += offset;
        }

        //Zoom
        if(autoZoom){
            // Zoom(targetsBounds.size.x);
        }

        Rotate(pitch, yaw, roll);
    }

    public void Rotate(float pitch, float yaw, float roll, bool add = false){
        if(add){
            transform.eulerAngles += new Vector3(pitch, yaw, roll);
        } else {
            transform.eulerAngles = new Vector3(pitch, yaw, roll);            
        }
    }

    public void Move(Vector3 targetPosition){
        Move(targetPosition, true);
    }

    public void Move(Vector3 targetPosition, bool globalPosition){
        Vector3 newPosition = targetPosition;
        Vector3 _targetPosition = targetPosition;

        if(!globalPosition){
            _targetPosition = transform.TransformPoint(_targetPosition);
        }

        if(enableSmoothing){
            newPosition = Vector3.SmoothDamp(transform.position, _targetPosition, ref currentVelocity, moveSmoothing);
        }
        
        transform.position = newPosition;
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

                Debug.Log(value);


        targetPosition -= transform.forward * zoom;
    }

    Vector3 GetFollowPosition(){
        Vector3 targetPosition = transform.position;
        
        if(targets != null && targets.Length > 0){
            targetPosition = targetsBounds.center;
        } 

        return targetPosition;
    }

    Bounds EncapsulateTargets(Transform[] targets){
        Bounds encapsulatedBounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 1; i < targets.Length; i++){
            encapsulatedBounds.Encapsulate(targets[i].position);
        }

        return encapsulatedBounds;
    }
}