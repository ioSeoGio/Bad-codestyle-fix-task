using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private float _shootForce;
    [SerializeField] private Bullet _prefab;
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
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            newBullet.AddForce(direction, _shootForce);

            yield return wait;
        }
    }
}