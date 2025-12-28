using UnityEngine;

public class CubeElevate
{
    public void ThingIDo(Transform transform)
    {
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.localPosition = new Vector3(transform.position.x, 0.36f, 1f);
        transform.localPosition = new Vector3(0, 0.36f, 2f);       
    }
}
