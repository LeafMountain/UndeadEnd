using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{    
    [Header("Auto Adjust Settings")]
    public bool enableAuto;
    public bool followTargets { get { return targets != null && targets.Count > 0 && targets[0] != null; } }
    public List<Transform> targets = new List<Transform>();

    [Header("Orientation Settings")]
    [Range(0, 360)]
    public float pitch = 0;
    [Range(0, 360)]
    public float yaw = 0;
    [Range(0, 360)]
    public float roll = 0;

    public Vector3 offset;

    [Header("Zoom Settings")]
    public bool enableZoom;
    public bool encapsulationZoom;
    [Range(0, 50)]
    public float zoom = 15;
    public bool limitZoom;    
    public Vector2 zoomMinMax = Vector2.zero;

    [Header("Smoothing Settings")]
    public bool enableSmoothing;
    [Range(0, 1)]
    public float smoothing = .5f;
    Vector3 currentVelocity;

    //Targets bounds
    Bounds targetsBounds;
    //The desiered position of the camera
    Vector3 targetPosition;

    [Header("Replacement Shader")]
    public bool enableReplacementShader;
    public Shader replacementShader;

    Camera cam;

    void Start(){
        cam = GetComponent<Camera>();

        if(enableReplacementShader){
            UseReplacementShader();
        }

        if(!followTargets){
            targetPosition = transform.position;
        }
    }

    void LateUpdate(){
        if(enableAuto){
            AutoAdjustCamera();
        }

        UpdatePosition();
    }

    void UpdatePosition(){
        Vector3 newPosition = targetPosition;

        if(enableSmoothing){
            newPosition = Vector3.SmoothDamp(transform.position, this.targetPosition, ref currentVelocity, smoothing);
        }
        
        transform.position = newPosition;
    }

    public void AutoAdjustCamera(){
        if(!followTargets){
            Debug.LogWarning("No target selected");
            return;
        }
        
        //Move
        targetsBounds = EncapsulateTargets(targets);
        targetPosition = GetFollowPosition();
        targetPosition += offset;


        //Zoom
        if(encapsulationZoom){
            float value = targetsBounds.size.x + targetsBounds.size.y;
            value *= 2;     //Magic number
            Zoom(value);
        } else {
            Zoom(0, true);
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

        if(!globalPosition){
            newPosition = transform.TransformPoint(targetPosition) + transform.position;
        }

        if(enableSmoothing){
            newPosition = Vector3.SmoothDamp(transform.position, this.targetPosition, ref currentVelocity, smoothing);
        }

        targetPosition = newPosition;
    }

    public void Zoom(float value, bool add = false){
        if(add){
            zoom += value;
        } else {            
            zoom = value;
        }

        if(limitZoom){
            zoom = Mathf.Clamp(zoom, zoomMinMax.x, zoomMinMax.y);
        }

        targetPosition -= transform.forward * zoom;
    }

    Vector3 GetFollowPosition(){
        Vector3 targetPosition = transform.position;
        
        if(followTargets){
            targetPosition = targetsBounds.center;
        } 

        return targetPosition;
    }

    Bounds EncapsulateTargets(List<Transform> targets){
        Bounds encapsulatedBounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 1; i < targets.Count; i++){
            if(targets[i]){
                encapsulatedBounds.Encapsulate(targets[i].position);
            }
        }

        return encapsulatedBounds;
    }

    void UseReplacementShader(){
        if(replacementShader){
            cam.SetReplacementShader(replacementShader, "");
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetsBounds.center, .5f);
    }
}