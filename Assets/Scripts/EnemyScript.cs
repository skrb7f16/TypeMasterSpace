using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    public bool isDestroyed = false;
    public TextMeshProUGUI WordOfTheAsteroid;
    public GameObject blast,asteroid;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, -0.1f);
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isDestroyed) Destroy(this.gameObject);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            Destroy(collision.gameObject);
            asteroid.SetActive(false);
            blast.SetActive(true);
            Destroy(this.gameObject, 1.5f);
        }
    }
}
