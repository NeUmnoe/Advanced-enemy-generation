using UnityEngine;

[RequireComponent(typeof(Movement))]

sealed class Entity : MonoBehaviour
{
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        _movement.ReachedDestination += OnReachedDestination;
    }

    private void OnDestroy()
    {
        _movement.ReachedDestination -= OnReachedDestination;
    }

    public void Initialize(Transform target)
    {
        _movement.SetTarget(target);
    }

    private void OnReachedDestination()
    {
        Destroy(gameObject);
    }
}