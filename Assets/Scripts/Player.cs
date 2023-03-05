using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private string attackWord = "";
    public GameObject laser;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkWord(attackWord);
            attackWord = "";
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

            }
        }
    }

    public void FireLaser(string s)
    {
        GameObject temp = Instantiate(laser);
        GameObject enemy = ManagerScript.enemies[s];
        Transform t = enemy.transform;
       
        Vector2 dir = enemy.transform.position - temp.transform.position;
        float angle = Mathf.Atan2(dir.x,dir.y+2f);
        temp.transform.Rotate(0,0,-1*angle*Mathf.Rad2Deg);
        temp.GetComponent<Rigidbody2D>().AddForce(20 * dir);
    }

}
