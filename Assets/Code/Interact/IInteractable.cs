
using UnityEngine;

public interface IInteractable
{
    public void OnInteractEnter(PlayerInteractor obj);
    public void OnInteractExit(PlayerInteractor obj);
}
