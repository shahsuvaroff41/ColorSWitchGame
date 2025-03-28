using UnityEngine;

public class LevelGnrtr : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject flag, getNewColor;
    public float distanceNumb;
    public int objectCount;

#pragma warning disable IDE0051 // Remove unused private members
    void Start()
#pragma warning restore IDE0051 // Remove unused private members
    {
        int n = gameObjects.Length;
        Vector2 position0 = new Vector2(0, 0); //circle
        Vector2 position1 = new Vector2(0, 6); //color changer
        for (int i = 0; i < objectCount - 1; i++)
        {
            int objectNumb = Random.Range(0, n);
            Instantiate(gameObjects[objectNumb], position0, Quaternion.identity);
            Instantiate(getNewColor, position1, Quaternion.identity);
            position0 = new Vector2(0, position0.y + distanceNumb);
            position1 = new Vector2(0, position1.y + distanceNumb);

        }
        position1 = new Vector2(0, position1.y - distanceNumb / 2);
        Instantiate(gameObjects[Random.Range(0, n)], position1, Quaternion.identity);
        Vector2 position2 = new Vector2(0, position1.y + distanceNumb - 4);
        Instantiate(flag, position2, Quaternion.identity);

    }


}
