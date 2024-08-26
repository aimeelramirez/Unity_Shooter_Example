using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBall : MonoBehaviour
{

    public float force = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            //distance to where the ball goes.
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Rigidbody rigidBody;
                    if (rigidBody = hit.transform.GetComponent<Rigidbody>())
                    {
                        LaunchBall(rigidBody);
                        PrintName(hit.transform.gameObject);

                    }
                }
            }

        }
    }
    private void PrintName(GameObject ball)
    {
        print(ball.name);
    }
    private void LaunchBall(Rigidbody rig)
    {
        rig.AddForce(rig.transform.up * force, ForceMode.Impulse);
    }
}
