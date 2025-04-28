using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private float _shootForce;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Transform _objectToShoot;
    
    private void OnEnable()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            Vector3 vector3direction = (_objectToShoot.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.transform.up = vector3direction;
            newBullet.velocity = vector3direction * _shootForce;

            yield return wait;
        }
    }
}