using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    static int level = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            level++;

            if (level >= SceneManager.sceneCountInBuildSettings)
            {
                level = 1;
            }

            SceneManager.LoadScene(level - 1);
        }            
    }
}
