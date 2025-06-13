using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DroneControler : MonoBehaviour
{
    public float speed;
    public float turnSeed;
    public float camSens;
    public GameObject drone;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    private Vector3 mousePos = new Vector3(Screen.height/2, Screen.width/2, 0f);
    private int force = 0;
    private int forceSide = 0;
    private int forceUp = 0;
    private float turn = 0;
    private float sin2x;
    private float cos2x;
    private float forceModifier = 0;

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

        if (Input.GetKey(KeyCode.Space))
        {
            forceUp = 1;
        }

        if (Input.GetKey(KeyCode.C))
        {
            forceUp = -1;
        }

        mousePos = Input.mousePosition - mousePos;
        print(mousePos);
        mousePos = new Vector3(transform.eulerAngles.x - mousePos.y, transform.eulerAngles.y + mousePos.x, 0);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, mousePos, 0.2f);
        mousePos = Input.mousePosition;

        sin2x = 2 * drone.transform.rotation.y * drone.transform.rotation.w;// 2sinAcosA;  вектор силы по локальной оси x
        cos2x = math.pow(drone.transform.rotation.w, 2) - math.pow(drone.transform.rotation.y, 2);// cos^2A-sin^2A;  вектор силы по локальной оси z
        forceModifier = 0 + math.sqrt(math.abs(force) + math.abs(forceUp) + math.abs(forceSide)) / (math.abs(force) + math.abs(forceUp) + math.abs(forceSide));// модуль векторов
        if (float.IsNaN(forceModifier)) {
            forceModifier = 0;
        }

        velocity.x = force * forceModifier * sin2x + forceSide * forceModifier * -cos2x;
        velocity.z = force * forceModifier * cos2x + forceSide * forceModifier * sin2x;
        velocity.y = forceUp * forceModifier;

        //print(math.sqrt(math.pow(velocity.x, 2) + math.pow(velocity.z, 2) + math.pow(velocity.y, 2)));

        drone.GetComponent<Rigidbody>().AddForce(velocity * speed * Time.deltaTime);
        drone.GetComponent<Rigidbody>().AddTorque(new Vector3(0, turn * turnSeed, 0) * Time.deltaTime);

        force = 0;
        forceUp = 0;
        forceSide = 0;
        turn = 0;
    }
}
