using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;

    [SerializeField] private GameObject losePanel, winPanel;

    [SerializeField] private GameObject sound;

    private bool isparent;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, 0);
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
        scoreText3.text = score.ToString();

        if (transform.position.y >= 300f)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Click()
    {

        if (isparent)
        {
            transform.Translate(Vector2.right * jumpForce);
            isparent = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Met")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Sputnik")
        {
            score += 1000;
            if (score >= 225000)
            {
                winPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            Instantiate(sound, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Planet")
        {
            speed = 0;
            transform.position = other.gameObject.transform.position;
            isparent = true;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        isparent = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            isparent = false;
            speed = 6.5f;
        }
    }

}
