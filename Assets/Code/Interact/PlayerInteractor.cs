using CustomInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private LayerMask _interactableLM;
    private bool _edge;
    private AbstractInputReader _inputReader;
    private void Awake()
    {
        _interactableLM = LayerMask.GetMask("Interactable");
        _inputReader = GetComponentInParent<AbstractInputReader>();
    }
    private void Update()
    {
        if(_inputReader.isInteract && !_edge)
        {
            _edge = true;
            StartInteract();
        }
        if (!_inputReader.isInteract)
        {
            _edge = false;
            EndInteract();
        }
    }
    public void StartInteract()
    {
        Debug.Log("start interaction");
        Collider2D[] output = Physics2D.OverlapCircleAll(this.transform.position, 1.0f, _interactableLM);
        foreach(Collider2D c in output)
        {
            Debug.Log("start foreach");
            IInteractable obj = c.GetComponent<IInteractable>();
            if (obj == null) continue;
            obj.OnInteractEnter(this);
        }
    }

    public void EndInteract()
    {

    }
}
