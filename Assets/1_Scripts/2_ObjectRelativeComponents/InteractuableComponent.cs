using UnityEngine;

public class InteractuableComponent : MonoBehaviour, IInteractuableComponent
{
    ICanInteractComponent _playerInteract;

    private void Awake()
    {
        _playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<ICanInteractComponent>();
    }

    public virtual void ThingIDo()
    {
        Debug.Log("Estoy interactuando");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Has entrado en el rango");
        if (_playerInteract != null && other.CompareTag("Player"))
            _playerInteract.interactFunction += ThingIDo;
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Has salido del rango");
        if (_playerInteract != null && other.CompareTag("Player"))
            _playerInteract.interactFunction -= ThingIDo;
    }
}
