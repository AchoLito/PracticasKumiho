using UnityEngine;

public class CubeElevate
{
    public void ThingIDo(Transform transform)
    {
        transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
