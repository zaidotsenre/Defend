using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    Transform bulletTransform;

    private void Start()
    {
        bulletTransform = transform;
    }

    void Update()
    {
        bulletTransform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);

        if (Vector3.Distance(bulletTransform.position, Vector3.zero) > 20)
            gameObject.SetActive(false);
    }

}
