using UnityEngine;
using UnityEngine.AI;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Camera c;
    [SerializeField] NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y>100)
            {
                Ray r = c.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(r, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
            
        }
    }
}
