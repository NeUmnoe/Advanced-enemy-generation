using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _curentWaypointIndex = 0;

    private void Update()
    {
        if(_waypoints.Length ==0) return;

        Transform targetWaypoint = _waypoints[_curentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            _curentWaypointIndex = (_curentWaypointIndex +1) % _waypoints.Length;
        }
    }
}
