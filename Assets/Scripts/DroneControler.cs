using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DroneControler : MonoBehaviour
{
    public float speed;
    public float turnSeed;
    public GameObject drone;
    private Vector3 velocity = new Vector3(0f,0f,0f);
    private int force = 0;
    private int turn = 0;
    private int forceSide = 0;
    private int forceUp = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            force = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            force = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            forceSide = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            forceSide = -1;
        }

        if (Input.GetKey(KeyCode.E))
        {
            turn = 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            turn = -1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            forceUp = 1;
        }

        if (Input.GetKey(KeyCode.C))
        {
            forceUp = -1;
        }

        velocity.x = force * (2 * drone.transform.rotation.y * drone.transform.rotation.w);//x = f * 2sinAcosA; f = {-1,0,1}  сила по оси x
        velocity.z = force * (math.pow(drone.transform.rotation.w, 2) - math.pow(drone.transform.rotation.y, 2));//z = f * cos^2A-sin^2A; f = {-1,0,1}  сила по оси z
        //velocity.y = forceUp;

        drone.GetComponent<Rigidbody>().AddForce(velocity * speed * Time.deltaTime);
        drone.GetComponent<Rigidbody>().AddTorque(new Vector3(0, turn * turnSeed, 0) * Time.deltaTime);

        force = 0;
        forceUp = 0;
        forceSide = 0;
        turn = 0;
    }
}
