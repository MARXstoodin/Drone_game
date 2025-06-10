using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DroneControler : MonoBehaviour
{
    public float speed;
    public float drag;
    public GameObject drone;
    private Vector3 velocity;
    private float force = 0;
    private float xTurn = 0;
    private float zTurn = 0;
    private float yTurn = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            force += 0.01f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            force -= 0.01f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            zTurn += 0.01f;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            zTurn -= 0.01f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            yTurn += 0.01f;
        }

        if (Input.GetKey(KeyCode.C))
        {
            yTurn -= 0.01f;
        }

        force -= math.pow(force, 3) / 204 + force / 204;
        yTurn -= math.pow(yTurn, 3) / 204 + yTurn / 204;

        velocity.x = force * math.cos(zTurn) * math.cos(yTurn);
        velocity.z = force * math.sin(zTurn) * math.cos(yTurn);
        velocity.y = force * math.sin(yTurn);

        print(velocity.x + velocity.y + velocity.z);

        drone.transform.position = velocity;
    }
}
