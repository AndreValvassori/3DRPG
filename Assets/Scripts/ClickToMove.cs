using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent mNavMeshAgent;
    public Interactable focus;
    Transform target;

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
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) // Hits a Interactable object.. Like a Chest,Item  or a Box;
                {
                    SetFocus(interactable);
                }
                else
                {
                    RemoveFocus();
                    mNavMeshAgent.destination = hit.point;
                }
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

        if (target != null)
        {
            mNavMeshAgent.SetDestination(target.position);
            FaceTarget();
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            
            focus = newFocus;

            FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        StopFollowingTarget();
    }

    public void FollowTarget(Interactable newTarget)
    {
        mNavMeshAgent.stoppingDistance = newTarget.radius * .8f;
        mNavMeshAgent.updateRotation = false;

        target = newTarget.transform;

    }

    public void StopFollowingTarget()
    {
        mNavMeshAgent.stoppingDistance = 0f;
        mNavMeshAgent.updateRotation = true;    
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
