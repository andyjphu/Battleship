using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    private float sizeScale = 10;    //sizeScale Factor
    public float panSpeed = 1.5f;
    public float orthoMax = 10.9f;
    public float orthoMin = 1.3f;
    public float zoomKeySpeed = 0.3f;
    private Camera currentCamera;
    private float mDelta; //Mouse Delta


    public delegate void mapChanges();
    //public static event mapChanges localView;
    //public static event mapChanges globalView;



    /// <summary>
    /// Checks camera orthographic size to make sure the game is in the right map mode
    /// </summary>
    private void checkMapMode()
    {

        if (currentCamera.orthographicSize > 10)
        {

            //globalView();
        }
        else
        {
            //localView();
        }

    }


    private void Start()
    {

        currentCamera = Camera.main;

        checkMapMode();
    }//Void

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)  //To reduce lag, only check ro try for scaling when relevant
        {
            mDelta = Input.mouseScrollDelta.y / 5;
            sizeScale -= mDelta; // plus or minus change in mouse scroll, inverted because that's the way I like it lol

            sizeScale = Mathf.Clamp(sizeScale, orthoMin, orthoMax);    //To try and prevent fustrum errors
            currentCamera.orthographicSize = sizeScale;

        }
        currentCamera = Camera.main;
        checkMapMode();
        Vector3 cam_pos = currentCamera.transform.position;






        float ortho_size = currentCamera.orthographicSize;

        if (Input.GetKey(KeyCode.W))
        {
            cam_pos.y += Time.deltaTime * (ortho_size * panSpeed);   //WASD movement, orthographic size 1 is zoomed in, ortho size 5 is zoomed out so this accelerates when
        }
        if (Input.GetKey(KeyCode.A))
        {
            cam_pos.x -= Time.deltaTime * (ortho_size * panSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cam_pos.y -= Time.deltaTime * (ortho_size * panSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam_pos.x += Time.deltaTime * (ortho_size * panSpeed);
        }
        //cam_pos.y = Mathf.Clamp(cam_pos.y, -(orthoMax - ortho_size), (orthoMax - ortho_size)); //The sum of the intercept and the half height of the viewport (as measured from the center) must not be greater or lower than the bounding box
        currentCamera.transform.position = cam_pos; //Modify the current camera's position by the cam_pos variable

        if (Input.GetKey(KeyCode.I))
        {
            currentCamera.orthographicSize -= zoomKeySpeed * (currentCamera.orthographicSize / 5);
            currentCamera.orthographicSize = Mathf.Clamp(currentCamera.orthographicSize, orthoMin, orthoMax);
        }
        if (Input.GetKey(KeyCode.O))
        {
            currentCamera.orthographicSize += zoomKeySpeed * (currentCamera.orthographicSize / 5);
            currentCamera.orthographicSize = Mathf.Clamp(currentCamera.orthographicSize, orthoMin, orthoMax);

        }

    }//Void
}//Class

//Useful Code   // for (var i = 0; i < GameObject.FindGameObjectsWithTag("Country").Length; i++) //For the length of game object array, sizeScale each gameobject by mouse defined sizeScale
//Useful Code  //gameObject.transform.localsizeScale = new Vector2(sizeScale, sizeScale);