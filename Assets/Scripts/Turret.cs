using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform cannonTip;
    [SerializeField] float turningRange;
    [SerializeField][Range(0, 1)] float turningSpeed;
    [SerializeField] float shootingRate;

    GameObjectPool bulletPool;
    Quaternion aimingLeft;
    Quaternion aimingRight;

    void Awake()
    {
        aimingLeft.eulerAngles = new Vector3(0, -turningRange / 2, 0);
        aimingRight.eulerAngles = new Vector3(0, turningRange / 2, 0);
    }

    void Start()
    {
        bulletPool = GetComponent<GameObjectPool>();
    }

    void OnEnable()
    {
        InvokeRepeating("Shoot", shootingRate, shootingRate);
        StartCoroutine("Turn");
    }

    void OnDisable()
    {
        CancelInvoke("Shoot");
        StopCoroutine("Turn");
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetNext();
        bullet.transform.position = cannonTip.position;
        bullet.transform.rotation = cannonTip.rotation;
        bullet.SetActive(true);
    }

    IEnumerator Turn()
    {
        
        while (true)
        {
            turretHead.localRotation = Quaternion.Lerp(aimingLeft, aimingRight, Mathf.PingPong(Time.time * turningSpeed, 1));
            yield return null;
        }
    }
}
