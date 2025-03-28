using UnityEngine;
public class ColorCh : MonoBehaviour
{
    public Color[] colorArr;
    public SpriteRenderer ballSpRe;
    private AudioSource colorAud;
#pragma warning disable IDE0051 // Remove unused private members
    void Start()
#pragma warning restore IDE0051 // Remove unused private members
    {
        colorAud = GetComponent<AudioSource>();
        ColorChanger();
    }


#pragma warning disable IDE0051 // Remove unused private members
    void Update()
#pragma warning restore IDE0051 // Remove unused private members
    {

    }
    private void ColorChanger()
    {
        int randNum = Random.Range(0, colorArr.Length);
        ballSpRe.color = colorArr[randNum];
    }
#pragma warning disable IDE0051 // Remove unused private members
    private void OnTriggerEnter2D(Collider2D collision)
#pragma warning restore IDE0051 // Remove unused private members
    {
        if (collision.CompareTag("GetColor"))
        {

            ColorChanger();
            colorAud.Play();
            Destroy(collision.gameObject);
        }
    }
}
