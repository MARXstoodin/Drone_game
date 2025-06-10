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
    private float zTurn = 0;
    private float forceUp = 0;

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
            zTurn += 0.003f;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            zTurn -= 0.003f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            forceUp += 0.01f;
        }

        if (Input.GetKey(KeyCode.C))
        {
            forceUp -= 0.01f;
        }

        force -= math.pow(force, 3) / drag + force / drag;
        forceUp -= math.pow(forceUp, 3) / drag + forceUp / drag;

        velocity.x = force * math.cos(zTurn) * math.sqrt(math.cos(forceUp)-0.06f);
        velocity.z = force * math.sin(zTurn) * math.sqrt(math.cos(forceUp)-0.06f);
        velocity.y = forceUp * math.sqrt(math.cos(force)-0.06f);

        print((math.abs(velocity.x) + math.abs(velocity.y) + math.abs(velocity.z)) / 3);

        drone.transform.rotation = new Quaternion(0, math.cos(zTurn/2) * Time.deltaTime, 0, math.sin(zTurn/2) * Time.deltaTime);
        drone.transform.position += velocity * speed * Time.deltaTime;
    }
}
