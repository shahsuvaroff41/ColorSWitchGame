using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControll : MonoBehaviour
{
    private SpriteRenderer _ballSpRe;
    private Rigidbody2D _ballRb;
    private Collider2D _ballCollider;
    private int _score = 0;
    private int _theWholeScore = 8;
    private int _currentCollisionTime = 0;
    private int _lastCollisionTime = -1;
    private int _collisionDistance = 0;
    public float jumpVar;
    public TextMeshPro ScoreTxt, GameOverTxt;
    public AudioSource bounceAud, loseAud, winAud, colorAud;
    public AudioClip audClip;
    public AudioSource[] getStar;
    public Color[] colorArr;
#pragma warning disable IDE0051 // Remove unused private members
    private void Start()
#pragma warning restore IDE0051 // Remove unused private members
    {
        _ballCollider = GetComponent<CircleCollider2D>();
        _ballSpRe = GetComponent<SpriteRenderer>();
        _ballRb = GetComponent<Rigidbody2D>();
        ColorChanger();
    }
    private void ColorChanger()
    {
        int randNum = Random.Range(0, colorArr.Length);
        _ballSpRe.color = colorArr[randNum];
    }
#pragma warning disable IDE0051 // Remove unused private members
    private void Update()
#pragma warning restore IDE0051 // Remove unused private members
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ballRb.linearVelocity = Vector2.up * jumpVar;
            bounceAud.Play();
        }
    }
#pragma warning disable IDE0051 // Remove unused private members
    private void OnTriggerEnter2D(Collider2D collision)
#pragma warning restore IDE0051 // Remove unused private members

    {
        if (collision.CompareTag("arc") && collision.GetComponent<ColorStorage>().color != _ballSpRe.color)
        {
            StartCoroutine(WaitTillNew());
        }
        else if (collision.CompareTag("Star"))
        {
            _currentCollisionTime = Mathf.FloorToInt(Time.time);
            int randVoice = Random.Range(0, 2);
            getStar[randVoice].Play();
            if (_lastCollisionTime != -1)
            {
                _collisionDistance = _currentCollisionTime - _lastCollisionTime;
                if (_collisionDistance < _theWholeScore)
                {
                    _theWholeScore -= _collisionDistance;
                }
                else
                {
                    _theWholeScore = 1;
                }
            }
            else
            {
                _collisionDistance = _currentCollisionTime;
                _theWholeScore = 1;
            }
            _lastCollisionTime = _currentCollisionTime;

            _score += _theWholeScore;
            ScoreTxt.text = "Score : " + _score;
            Destroy(collision.gameObject);
            _theWholeScore = 15;
        }
        else if (collision.CompareTag("flag"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(WinTheGame());
        }
        else if (collision.CompareTag("GetColor"))
        {
            ColorChanger();
            colorAud.Play();
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator WaitTillNew()
    {
        _ballRb.constraints = RigidbodyConstraints2D.FreezeAll;
        _ballRb.position = new Vector2(0, _ballRb.position.y);
        _ballSpRe.enabled = false;
        _ballCollider.enabled = false;
        loseAud.PlayOneShot(audClip);
        GameOverTxt.text = "Game over";
        _currentCollisionTime = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator WinTheGame()
    {
        winAud.Play();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex != 2) sceneIndex++;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }
}