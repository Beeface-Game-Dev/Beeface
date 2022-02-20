using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Colonist : MonoBehaviour
{
   /* public TaskList task;
    private ActionList AL;
    GameObject targetNode;

    public NodeManager.ResourceTypes heldResourceType;
    public ResourceManager RM;

    public bool isGathering = false;

    private NavMeshAgent agent;

    public int heldResource;
    public int maxHeldResource;

    public GameObject[] drops;
    public float distToTarget;
    public bool isGatherer = false;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GatherTick());
        agent = GetComponent<NavMeshAgent>();
        AL = FindObjectOfType<ActionList>();
    }

    // Update is called once per frame
    void Update()
    {
        if (task == TaskList.Gathering)
        {
            offset = targetNode.transform.position - transform.position;
            distToTarget = offset.sqrMagnitude;
            //distToTarget = Vector3.Distance(targetNode.transform.position, transform.position);
            Debug.Log(distToTarget);

            if (distToTarget <= 3.5f * 3.5f)
            {
                Gather();
            }
        }

        if(task == TaskList.Delivering)
        {
            if(distToTarget <= 3.5f)
            {
                if(RM.Food >= RM.maxFood)
                {
                    task = TaskList.Idle;
                }
                else
                {
                    RM.Food += heldResource;
                    heldResource = 0;
                    task = TaskList.Gathering;
                    agent.destination = targetNode.transform.position;
                    isGatherer = false;
                }
            }
        }

        if (targetNode == null)
        {         
            if (heldResource != 0)
            {
                drops = GameObject.FindGameObjectsWithTag("Drops");
                agent.destination = GetClosestDropOff(drops).transform.position;
              //  distToTarget = Vector3.Distance(GetClosestDropOff(drops).transform.position, transform.position);
                offset = GetClosestDropOff(drops).transform.position - transform.position;
                distToTarget = offset.sqrMagnitude;
                drops = null;
                task = TaskList.Delivering;
            }
            else
            {
                task = TaskList.Idle;
            }
        }

        if (heldResource >= maxHeldResource)
        {
            targetNode.GetComponent<NodeManager>().gatherers--;
            isGathering = false;
            drops = GameObject.FindGameObjectsWithTag("Drops");
            agent.destination = GetClosestDropOff(drops).transform.position;
           // distToTarget = Vector3.Distance(GetClosestDropOff(drops).transform.position, transform.position);
            offset = GetClosestDropOff(drops).transform.position - transform.position;
            distToTarget = offset.sqrMagnitude;
            drops = null;
            task = TaskList.Delivering;
            GetComponent<NavMeshObstacle>().enabled = false;
            //GetCompnent<NavMeshAgent>().enabled = true;
        }
        if (Input.GetMouseButtonDown(1) && GetComponent<ObjectInfo>().isSelected)
        {
            RightClick();
        }
    }

    GameObject GetClosestDropOff(GameObject[] dropOffs)
    {
        GameObject closestDrop = null;
        float closestDistance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject targetDrop in dropOffs)
        {
            Vector3 direction = targetDrop.transform.position - position;
            float distance = direction.sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestDrop = targetDrop;
            }
        }
        return closestDrop;
    }

    public void RightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag == "Ground")
            {
                targetNode.GetComponent<NodeManager>().gatherers--;
                isGathering = false;
                AL.Move(agent, hit);
                task = TaskList.Moving;
                GetComponent<NavMeshObstacle>().enabled = true;
                GetComponent<NavMeshAgent>().enabled = false;
            }
            else if (hit.collider.tag == "Resource")
            {
                AL.Move(agent, hit);
                targetNode = hit.collider.gameObject;
                task = TaskList.Gathering;
            }
            else if (hit.collider.tag == "Drops") 
            {
                targetNode.GetComponent<NodeManager>().gatherers--;
                isGathering = false;
                drops = GameObject.FindGameObjectsWithTag("Drops");
                agent.destination = GetClosestDropOff(drops).transform.position;
               // distToTarget = Vector3.Distance(GetClosestDropOff(drops).transform.position, transform.position);
                offset = GetClosestDropOff(drops).transform.position - transform.position;
                distToTarget = offset.sqrMagnitude;
                drops = null;
                task = TaskList.Delivering;
                GetComponent<NavMeshObstacle>().enabled = false;
               // GetCompnent<NavMeshAgent>().enabled = true;
            }
        }
    }
    public void Gather()
    {
        isGathering = true;
        if(!isGatherer)
        {
            targetNode.GetComponent<NodeManager>().gatherers++;
            isGatherer = true;
        }
        heldResourceType = targetNode.GetComponent<NodeManager>().resourceType;
        GetComponent<NavMeshObstacle>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = false;
    }
  /*  public void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if (hitObject.tag == "Resource" && task == TaskList.Gathering)
        {
            isGathering = true;
            hitObject.GetComponent<NodeManager>().gatherers++;
            heldResourceType = hitObject.GetComponent<NodeManager>().resourceType;
            GetComponent<NavMeshObstacle>().enabled = false;
            GetCompnent<NavMeshAgent>().enabled = true;

        }
        else if (hitObject.tag == "Drops" && task == TaskList.Delivering)
        {
            if (RM.Food >= RM.maxFood)
            {
                task = TaskList.Idle;
            }
            else
            {
                RM.Food += heldResource;
                heldResource = 0;
                task = TaskList.Gathering;
                agent.destination = targetNode.transform.position;
            }
        }

    }

    IEnumerator GatherTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (isGathering)
            {
                heldResource++;
            }
        }
    }*/
}
