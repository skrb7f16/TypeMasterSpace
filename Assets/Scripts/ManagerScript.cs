using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    static public  Dictionary<string,GameObject>enemies;
    
    public GameObject enemy;

    public int currSize=0;
    static public bool stopWords = false;
    void Start()
    {

        //spawnEnemy("hello");
        enemies = new Dictionary<string, GameObject>();
        StartCoroutine(FetchWord());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy(string s)
    {
        GameObject temp = Instantiate(enemy);
        temp.transform.position = new Vector2(Random.Range(-7, 8), 3.8f);
        temp.GetComponent<EnemyScript>().WordOfTheAsteroid.text = s;
        enemies[s] = temp;
        currSize++;
    }

    IEnumerator FetchWord()
    {

        /*Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("X-Api-Key", "KuEIkMDVKfgkAfOKMplNOw==zFZpFC7QJYyq97LO");
        WWW www = new WWW("https://api.api-ninjas.com/v1/randomword", null, headers);
        yield return www;*/
        /*
        while (!stopWords)
        {
            UnityWebRequest req = UnityWebRequest.Get("https://api.api-ninjas.com/v1/randomword");
            req.SetRequestHeader("X-Api-Key", "KuEIkMDVKfgkAfOKMplNOw==zFZpFC7QJYyq97LO");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(req.error);
            }
            else
            {
                WordClass w = new WordClass();
                w = JsonUtility.FromJson<WordClass>(req.downloadHandler.text);
                spawnEnemy(w.word);
            }
            yield return new WaitForSeconds(5f);
        }*/
        
        while (!stopWords) {
            UnityWebRequest req = UnityWebRequest.Get("https://randomword.com/");
            yield return req.SendWebRequest();

            string temp = req.downloadHandler.text.Split("random_word")[1].Split("</")[0].Split(">")[1];
         
            spawnEnemy(temp);
            yield return new WaitForSeconds(5f);
        }
        
        
    }
    
    
}
