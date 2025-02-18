using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Dungeon");
    }
}
