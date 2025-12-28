using UnityEngine;

public class DepositadorController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube"))
        {
            DepositeCubeBehaviour();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            ElevateCubeBehaviour();
        }
    }

    protected virtual void DepositeCubeBehaviour() { }

    protected virtual void ElevateCubeBehaviour() { }
}
