using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityToken : MonoBehaviour
{
    [SerializeField] GameObject ability;
    AbilityManager abilityManager;

    private void Start()
    {
        abilityManager = GameObject.Find("AbilityManager").GetComponent<AbilityManager>();
    }

    private void OnMouseDown()
    {
        abilityManager.Ability = ability;
        gameObject.SetActive(false);
    }
}
