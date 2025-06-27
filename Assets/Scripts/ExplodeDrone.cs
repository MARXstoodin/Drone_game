using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodeDrone
{
    GameObject drone;
    public ExplodeDrone(GameObject droneOb)
    {
        drone = droneOb;
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(drone.transform.position, 10f);
        foreach (Collider c in colliders)
        {
            if (c.tag == "infantry")
            {
                MonoBehaviour.print("die");

            }
        }
        drone.transform.GetChild(0).gameObject.SetActive(false);
        drone.transform.GetChild(1).gameObject.SetActive(true);
        drone.GetComponent<DroneControler>().enabled = false;
    }
}
