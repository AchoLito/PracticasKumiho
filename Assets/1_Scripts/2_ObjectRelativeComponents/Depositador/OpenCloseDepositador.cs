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
    }

    protected override void DepositeCubeBehaviour()
    {
        foreach (GameObject wall in _walls)
            wall.SetActive(false);
    }

    protected override void ElevateCubeBehaviour()
    {
        foreach (GameObject wall in _walls)
            wall.SetActive(true);
    }
}
