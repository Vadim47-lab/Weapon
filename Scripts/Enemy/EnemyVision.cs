using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private int rays = 8;
    [SerializeField] private int distance = 33;
    [SerializeField] private float angle = 40;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

    private NavMeshAgent Nana;

    public event UnityAction SeePlayer;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        Nana = GetComponent<NavMeshAgent>();
    }

    private bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;

        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }

        return result;
    }

    private bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;

        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));

            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;

        return result;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            if (RayToScan())
            {
               Nana.enabled = true;
                PlayerDetected();// Контакт с целью
            }
            else
            {
                  // Поиск цели...
            }
        }
    }

    public void PlayerDetected()
    {
        SeePlayer?.Invoke();
    }
}