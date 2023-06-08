using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] int hp = 4;
    [SerializeField] private Sprite[] ShipDamageSprites;
    private SpriteRenderer _sp;
    [SerializeField] private GameObject EndPanel;
    [SerializeField] private TMP_Text TimerText;

    [SerializeField] private TMP_Text m_score;
    [SerializeField] private TMP_Text m_scoreFinal;
    [SerializeField] private int _score = 0;
    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "asteroid")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        switch (hp)
        {
            case 4:
                _sp.sprite = ShipDamageSprites[3];
                break;
            case 3:
                _sp.sprite = ShipDamageSprites[2];
                break;
            case 2:
                _sp.sprite = ShipDamageSprites[1];
                break;
            case 1:
                _sp.sprite = ShipDamageSprites[0];
                break;
        }
        livesText.text = hp.ToString();

        if(hp <=0)
            EndGame();

        Timer += Time.deltaTime;
        m_score.text = _score.ToString();
        m_scoreFinal.text = _score.ToString();
    }

    private void EndGame()
    {
        EndPanel.SetActive(true);
        Time.timeScale = 0;
        TimerText.text = Timer.ToString();
        this.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void RecountScore()
    {
        _score++;
    }
}
