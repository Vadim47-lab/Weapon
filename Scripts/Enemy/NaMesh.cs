using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NaMesh : MonoBehaviour 
{
	[SerializeField] private Transform target;

	private NavMeshAgent agent;

	private void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		agent.SetDestination(target.position);
	}
}