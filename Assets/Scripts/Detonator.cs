using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public float radius = 5.0f;
    public float power = 10.0f;
    public GameObject timerTextGameObject;
    public AudioSource explosionSound;
    public bool explode = false;

    public GameObject explosion;

    void Update()
    {
        if (timerIsRunning)
        {
            SetTimer();
        }
        if (explode)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSound.PlayOneShot(explosionSound.GetComponent<AudioSource>().clip);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
            }
        }
        Destroy(gameObject);
    }

    void SetTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            explode = true;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // float milliSeconds = (timeToDisplay % 1) * 1000;
        TextMeshProUGUI timerText = timerTextGameObject.GetComponent<TextMeshProUGUI>();
        // timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
