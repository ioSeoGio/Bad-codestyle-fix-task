using System.Collections;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    private Coroutine _coroutine;

    public void Move(Transform target, float speed)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        Vector3 direction = (target.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        _coroutine = StartCoroutine(MoveCoroutine(target, speed));
    }

    public IEnumerator MoveCoroutine(Transform target, float speed)
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        while (enabled)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return wait;
        }
    }
}