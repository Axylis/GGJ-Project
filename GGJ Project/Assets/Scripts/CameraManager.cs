using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    [SerializeField] Vector2 topLeftPos, bottomRightPos, TLZoomedPos, BRZoomedPos;
    [SerializeField] float cursorMoveArea = 0.05f, zoomAmount = 2, zoomDuration = 0.5f, posStepSize = 0.02f;
    Camera cam;
    bool zoomingOut = false;
    float defaultSize, currZoomStart = 0, defaultZPos, targetSize;
    Vector2 defaultTopLeftPos, defaultBottomRightPos;
    Vector3 velocity;

    void Start(){
        cam = GetComponent<Camera>();
        defaultSize = targetSize = cam.orthographicSize;
        defaultZPos = transform.position.z;
        defaultBottomRightPos = bottomRightPos;
        defaultTopLeftPos = topLeftPos;
    }

    void Update(){
        if(!zoomingOut){
            updatePosition();
        }else{
            zoomingOutCorr();
        }
        updateSize();
    }

    void updatePosition(){
        Vector2 targetPos = cam.transform.position;
        if(Input.mousePosition.x < Screen.width * cursorMoveArea){
            targetPos.x = topLeftPos.x;
        }else if(Input.mousePosition.x > Screen.width * (1-cursorMoveArea)){
            targetPos.x = bottomRightPos.x;
        }
        if(Input.mousePosition.y < Screen.height * cursorMoveArea){
            targetPos.y = bottomRightPos.y;
        }else if(Input.mousePosition.y > Screen.height * (1-cursorMoveArea)){
            targetPos.y = topLeftPos.y;
        }

        posEasing(targetPos, posStepSize);
    }

    void zoomingOutCorr(){
        Vector3 adjustPos = transform.position;
        if(adjustPos.x < topLeftPos.x){
            adjustPos.x = topLeftPos.x;
        }else if(adjustPos.x > bottomRightPos.x){
            adjustPos.x = bottomRightPos.x;
        }
        if(adjustPos.y < bottomRightPos.y){
            adjustPos.y = bottomRightPos.y;
        }else if(adjustPos.y > topLeftPos.y){
            adjustPos.y = topLeftPos.y;
        }
        
        float t = (Time.time - currZoomStart) / zoomDuration;
        transform.position = Vector3.Slerp(transform.position, adjustPos, t);
    }

    void posEasing(Vector2 targetPos, float step){
        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
        transform.position = new Vector3(transform.position.x, transform.position.y, defaultZPos);
    }

    void updateSize(){
        if(Input.mouseScrollDelta.y > 0){
            // Debug.Log("Zoom In" + defaultSize + ":" + targetSize);
            targetSize = defaultSize / zoomAmount;
            currZoomStart = Time.time;
            bottomRightPos = BRZoomedPos;
            topLeftPos = TLZoomedPos;
        }else if(Input.mouseScrollDelta.y < 0){
            // Debug.Log("Zoom Out");
            targetSize = defaultSize;
            currZoomStart = Time.time;
            bottomRightPos = defaultBottomRightPos;
            topLeftPos = defaultTopLeftPos;

            if(transform.position.x < topLeftPos.x){
                zoomingOut = true;
            }else if(transform.position.x > bottomRightPos.x){
                zoomingOut = true;
            }
            if(transform.position.y < bottomRightPos.y){
                zoomingOut = true;
            }else if(transform.position.y > topLeftPos.y){
                zoomingOut = true;
            }
        }

        sizeEasing();
    }

    void sizeEasing(){
        float t = (Time.time - currZoomStart) / zoomDuration;
        cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, targetSize, t);
        if(t >= 1){
            zoomingOut = false;
        }
    }
}