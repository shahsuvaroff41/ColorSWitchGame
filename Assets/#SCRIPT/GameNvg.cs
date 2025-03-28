using UnityEngine;

public class GameNvg : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            this.enabled = false;
        }
    }
}
