using UnityEngine;
using UnityEditor.AI;
using Unity.VisualScripting;
using UnityEngine.AI;

public class InfantryAI : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = player.transform.position;
    }
}
