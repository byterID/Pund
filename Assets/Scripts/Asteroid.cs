using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(transform.position.x < screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
}
