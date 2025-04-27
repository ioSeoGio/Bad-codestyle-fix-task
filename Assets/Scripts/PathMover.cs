using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(TargetMover))]
public class PathMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _arrayPlaces;
    [SerializeField] private float _pointAchievementRange;
    [SerializeField] private float _speed;

    private int _currentPlaceKey = 0;
    private TargetMover _targetMover;

    private void Awake()
    {
        _targetMover = GetComponent<TargetMover>();
        _targetMover.Move(_arrayPlaces[_currentPlaceKey].transform, _speed);
    }

    private void FixedUpdate()
    {
        Transform currentPlace = _arrayPlaces[_currentPlaceKey];

        if (Vector3Extension.IsInRange(transform.position, currentPlace.transform.position, _pointAchievementRange))
        {
            SwitchToNextPlace();
            _targetMover.Move(_arrayPlaces[_currentPlaceKey].transform, _speed);
        }
    }

    private void SwitchToNextPlace()
    {
        _currentPlaceKey++;

        if (_currentPlaceKey == _arrayPlaces.Count)
        {
            _currentPlaceKey = 0;
        }
    }
}
