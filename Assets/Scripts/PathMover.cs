using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetMover))]
public class PathMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _places;
    [SerializeField] private float _pointAchievementRange;
    [SerializeField] private float _speed;

    private int _currentPlaceKey = 0;
    private TargetMover _targetMover;

    private void Awake()
    {
        _targetMover = GetComponent<TargetMover>();
        _targetMover.Move(_places[_currentPlaceKey].transform, _speed);
    }

    private void Update()
    {
        Transform currentPlace = _places[_currentPlaceKey];

        if (Vector3Extension.IsInRange(transform.position, currentPlace.transform.position, _pointAchievementRange))
        {
            SwitchToNextPlace();
            _targetMover.Move(_places[_currentPlaceKey].transform, _speed);
        }
    }

    private void SwitchToNextPlace()
    {
        _currentPlaceKey = ++_currentPlaceKey % _places.Count;
    }
}
