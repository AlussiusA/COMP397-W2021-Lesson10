using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnableEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float delay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableNavMeshAgent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to wait before enabling AI
    IEnumerator EnableNavMeshAgent()
    {
        yield return new WaitForSeconds(delay);
        agent.enabled = true;
        StopCoroutine(EnableNavMeshAgent());
    }
}
