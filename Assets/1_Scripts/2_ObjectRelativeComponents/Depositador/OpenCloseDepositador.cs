using UnityEngine;

public class OpenCloseDepositador : DepositadorController
{
    GameObject[] _walls;

    private void Awake()
    {
        InteractuableEnums.GetObjectsOfColor(_color, out _walls);

#if UNITY_EDITOR
        Debug.Log("He encontrado: " + _walls.Length);
#endif
        /*
        foreach (GameObject wall in _walls)
        {
            if (wall.GetComponent<WallType>().type == WallType.Type.Dark)
                wall.SetActive(false);
        }
        */
    }

    private void Start()
    {
        foreach (GameObject wall in _walls)
        {
            if (wall.GetComponent<WallType>().type == WallType.Type.Dark)
                wall.SetActive(false);
        }
    }

    protected override void DepositeCubeBehaviour()
    {
        foreach (GameObject wall in _walls)
        {
            wall.SetActive(!wall.activeSelf);
        }

        Debug.Log("Cubo ha sido apoyado " + name);
    }

    protected override void ElevateCubeBehaviour()
    {
        foreach (GameObject wall in _walls)
        {
            wall.SetActive(!wall.activeSelf);
        }          
    }
}
