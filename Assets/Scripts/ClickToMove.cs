using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent mNavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {

        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        
        if (Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                transform.position = hit.point;
                mNavMeshAgent.destination = hit.point;
            }
        }
    }
}
