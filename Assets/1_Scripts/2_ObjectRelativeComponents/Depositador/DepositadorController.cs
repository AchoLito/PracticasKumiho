using UnityEngine;

public class DepositadorController : MonoBehaviour
{
    [SerializeField] protected InteractuableEnums.Colors _color;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube") && other.GetComponent<CubeController>().color == _color)
        {
            DepositeCubeBehaviour();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube") && other.GetComponent<CubeController>().color == _color)
        {
            ElevateCubeBehaviour();
        }
    }

    protected virtual void DepositeCubeBehaviour() { }

    protected virtual void ElevateCubeBehaviour() { }
}
