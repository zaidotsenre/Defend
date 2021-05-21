using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    [SerializeField] float lifeSpan;

    private void OnEnable()
    {
        Invoke("SelfDisable", lifeSpan);
    }

    void SelfDisable ()
    {
        gameObject.SetActive(false);
    }
}
