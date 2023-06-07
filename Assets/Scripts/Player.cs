using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private Text livesText;
    [SerializeField] int hp = 4;
    [SerializeField] private Sprite[] ShipDamageSprites;
    private SpriteRenderer _sp;
    [SerializeField] private GameObject EndPanel;
    [SerializeField] private Text TimerText;
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
}
