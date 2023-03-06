using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private string attackWord = "";
    public GameObject laser;
    public TextMeshProUGUI score;
    public AudioClip laserSound,wrongSpelling;
    public AudioSource source;
  
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ManagerScript.stopWords == true)
            {
                return;
            }
            else
            {
                checkWord(attackWord);
                attackWord = "";
            }
        }
        else if(Input.anyKeyDown)
        {
            attackWord += Input.inputString;
            print(attackWord);
        }
    }
    public void checkWord(string s)
    {
        foreach (string w in ManagerScript.enemies.Keys)
        {
            print(w);
            if (w.Equals(s))
            {
                FireLaser(s);
                return;
            }
        }
        source.clip = wrongSpelling;
        source.Play();
    }

    public void FireLaser(string s)
    {
        GameObject temp = Instantiate(laser);
        GameObject enemy = ManagerScript.enemies[s];
        Transform t = enemy.transform;
       
        Vector2 dir = enemy.transform.position - temp.transform.position;
        float angle = Mathf.Atan2(dir.x,dir.y+1f);
        temp.transform.Rotate(0,0,-1*angle*Mathf.Rad2Deg);
        temp.GetComponent<Rigidbody2D>().AddForce(DataForGame.LaserSpeedFactor * dir);
        source.clip = laserSound;
        source.Play();
        DataForGame.score++;
        score.text = DataForGame.score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().asteroid.SetActive(false);
            collision.gameObject.GetComponent<EnemyScript>().blast.SetActive(true);
            Destroy(collision.gameObject, 1.5f);
            DataForGame.score = 0;
            score.text = DataForGame.score.ToString();
            ManagerScript.stopWords = true;
            
        }
    }
}
