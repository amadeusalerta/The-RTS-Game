using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    public LayerMask ground;

    private void Start()
    {
        cam = ReferanceManager.instance.mainCamera;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit,Mathf.Infinity,ground))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
