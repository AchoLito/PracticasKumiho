using UnityEngine;

public class WallType : MonoBehaviour
{
    public enum Type 
    {
        Light,
        Dark
    }

    public Type type = Type.Light;
}
