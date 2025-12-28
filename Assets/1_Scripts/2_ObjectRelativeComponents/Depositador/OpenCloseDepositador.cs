using UnityEngine;

public class OpenCloseDepositador : DepositadorController
{
    [SerializeField] GameObject[] _walls;
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
