using UnityEngine;
using System;

sealed class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationSpeed = 5f;

    private Transform _target;

    public event Action OnReachedDestination;

    private void Update()
    {
        if (_target != null)
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _target.position) < 0.1f)
        {
            OnReachedDestination?.Invoke();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}