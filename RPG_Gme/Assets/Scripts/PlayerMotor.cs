using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {
    NavMeshAgent agent;
    Transform target;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    // Update is called once per frame
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.interactionTransform;
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;
    }
    public void StopFollowingTarget()
    {
        target = null;
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
    }

    void FaceTarget()
    {
        //Math Heavy
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
