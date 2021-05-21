using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    #region Fields

    [SerializeField] Button abilityButton;
    [SerializeField] Sprite emptySprite;

    public GameObject Ability
    {
        get { return ability; }
        set 
        { 
            ability = value;
            abilityButton.image.sprite = value.GetComponent<AbilityImage>().sprite;
        }
    }
    GameObject ability;
    
    #endregion Fields


    #region Methods

    void Start()
    {
        abilityButton.onClick.AddListener(SpawnAbility);
        abilityButton.image.sprite = emptySprite;
    }

    void SpawnAbility ()
    {
        if (ability)
        {
            ability = Instantiate(ability);
            ability.GetComponent<Moveable>().Selected = true;
            abilityButton.image.sprite = emptySprite;
            ability = null;
        }
    }

    #endregion Methods
}
