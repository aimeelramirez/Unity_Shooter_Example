using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBall : MonoBehaviour
{
    //get target
    GameObject ball;
    //check 
    bool mouseMoving;

    Vector3 newLocation;
    Vector3 locationScreen;

    public RaycastHit isHit;
    // Use this for initialization
    void Start()
    {
        Debug.Log(this);
    }

    void Update()
    {
       
       
        //on event click on drag
        if (Input.GetMouseButtonDown(0))
        {
            GetObject();
        }

        //when letting go of the ball
        if (Input.GetMouseButtonUp(0))
        {
            mouseMoving = false;

        }
        //if its moving still
        if (mouseMoving)
        {
            SetObjectDrag();
        }

    }
    public void SetObjectDrag()
    {
        Vector3 getMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, locationScreen.z);

        //converting screen position to world position with offset changes.
        Vector3 parseNewLocation = Camera.main.ScreenToWorldPoint(getMousePosition) + newLocation;

        //set the position as the parsed
        ball.transform.position = parseNewLocation;
    }
    public void GetObject()
    {
        //get the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //check target
        ball = RecieveObject(ray, out isHit);

        if (ball != null)
        {
            //bool getting dragging event
            mouseMoving = true;
            //camera to see where ther target is 
            locationScreen = Camera.main.WorldToScreenPoint(ball.transform.position);
            Debug.Log($"position of screen: {locationScreen}");
            newLocation = ball.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, locationScreen.z));
            Debug.Log($"get the new location: {newLocation}");

        }
        else
        {
             
           
           
        }
    }
    //get game object on method
  public GameObject RecieveObject(Ray ray, out RaycastHit sendHit)
    {
        GameObject target = null;
        //get the ball
        //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html

        if (Physics.Raycast(ray.origin, ray.direction * 20, out sendHit))
        {
            target = sendHit.collider.gameObject;
        }
        return target;
    }
}