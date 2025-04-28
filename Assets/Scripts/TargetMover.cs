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

        _coroutine = StartCoroutine(MoveCoroutine(target, speed));
    }

    public IEnumerator MoveCoroutine(Transform target, float speed)
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        while (enabled)
        {
            transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);

            yield return wait;
        }
    }
}