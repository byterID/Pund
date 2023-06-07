using System.Collections;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private float respawnTime;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    private void Spawn()
    {
        GameObject a = Instantiate(asteroid) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }
}
