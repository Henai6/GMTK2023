using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullable : MonoBehaviour, IInteractable
{
    private bool _isInteracting;
    public PlayerInteractor _pulledBy;
    private Vector3 _relativeLocation;
    private Vector3 _targetLocation;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnInteractEnter(PlayerInteractor obj)
    {
        _pulledBy = obj;
        _relativeLocation = this.transform.position - obj.transform.position;
        _isInteracting = true;
    }

    public void OnInteractExit(PlayerInteractor obj)
    {
        _isInteracting = false;
    }

    private void Update()
    {
        if (_isInteracting)
        {
            _targetLocation = _pulledBy.transform.position + _relativeLocation;
            _rb.velocity = (_targetLocation - transform.position)*10;
        }
    }
}
