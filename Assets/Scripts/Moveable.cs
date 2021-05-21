using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moveable : MonoBehaviour
{

    #region Fields

    [SerializeField] float rotationSpeed = 90;
    [SerializeField] bool intangibleWhileMoving;
    
    public bool Selected
    {
        get { return selected; }
        set
        {
            selected = value;
            Cursor.visible = !value;
            if (intangibleWhileMoving)
                thisCollider.enabled = !value;
        }
    }
    bool selected = false;

    Camera mainCamera;
    Transform thisTransform;
    Collider thisCollider;

    #endregion Fields


    #region Methods

    private void Awake()
    {
        mainCamera = Camera.main;
        thisTransform = transform;
        thisCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Selected = false;
        }

        if (selected)
        {
            Vector3 updatedPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            updatedPosition.y = thisTransform.position.y;
            thisTransform.position = updatedPosition;

            float rotationInput = Input.GetAxis("Mouse ScrollWheel");
            thisTransform.Rotate(Vector3.up, rotationSpeed * rotationInput);
        }
    }

    private void OnMouseDown()
    {
        Selected = true;
    }

    private void OnDisable()
    {
        Selected = false;
    }

    #endregion Methods
}
