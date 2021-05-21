using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;

    Transform target;
    Transform enemyTransform;

    void Awake()
    {
        target = GameObject.Find("Target").transform;
        enemyTransform = transform;
    }

    private void OnEnable()
    {
        StartCoroutine("MoveTowardsTarget");
    }

    private void OnDisable()
    {
        StopCoroutine("MoveTowardsTarget");
    }

    IEnumerator MoveTowardsTarget ()
    {
        while (Vector3.Distance(enemyTransform.position, target.position) > 0.5f)
        {
            enemyTransform.LookAt(target);
            enemyTransform.Translate(Vector3.forward * Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnMouseOver()
    {
        gameObject.SetActive(false);
    }
}
