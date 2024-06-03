using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timer = 2f;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Entity _entity;
    [SerializeField] private Transform[] _targets;

    private bool _isSpawning = true;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timer);

        while (_isSpawning)
        {
            Transform spawnPoint = _points[Random.Range(0, _points.Length)];
            Transform target = _targets[Random.Range(0, _targets.Length)];
            Entity entity = Instantiate(_entity, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward));

            entity.Initialize(target);

            yield return waitForSeconds;
        }
    }
}