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
        _movement.OnReachedDestination += HandleDeath;
    }

    private void OnDestroy()
    {
        _movement.OnReachedDestination -= HandleDeath;
    }

    public void Initialize(Transform target)
    {
        _movement.SetTarget(target);
    }

    private void HandleDeath()
    {
        Destroy(gameObject);
    }
}