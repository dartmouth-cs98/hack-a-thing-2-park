using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    //movement target
    public Transform[] targets;

    //speed
    public float speed=10;

    bool isMoving=false;

    //next destination index
    int nextIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position=targets[0].position;
    
        nextIndex=1;
    
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (isMoving){
            HandleMovement();
        }
    }

    void HandleInput(){
        if (Input.GetButtonDown("Fire1")){
            isMoving=true;
        }
    }

    void HandleMovement(){
                //calculate distance from target
        float distance = Vector3.Distance(transform.position, targets[nextIndex].position);
        //have we arrived?
            //calculate how much we need to move (step)
        if (distance > 0) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targets[nextIndex].position, step);
        
        }

        //if we have arrived
        else {
            nextIndex++;
            isMoving=false;
            if (nextIndex==4){
                nextIndex=0;
            }
        }
            //move by that step
    }
}
