using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsToken : MonoBehaviour
{
    GameObjectPool tokenPool;
    bool firstTimeDisabled = true;

    void Awake()
    {
        tokenPool = GameObject.Find("Token Pool").GetComponent<GameObjectPool>();
    }

    void OnDisable()
    {
        if (!firstTimeDisabled)
            DropToken();    
        else
            firstTimeDisabled = false;
    }

    void DropToken ()
    {
        GameObject token = tokenPool.GetNext();
        token.transform.position = transform.position;
        token.SetActive(true);
    }
}
