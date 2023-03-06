using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    static public  Dictionary<string,GameObject>enemies;
    
    public GameObject enemy;
    public TextMeshProUGUI gameOver;
    public int currSize=0;
    static public bool stopWords = false;
    public GameObject container;
    GameObject nextContainer;

    void Start()
    {

        //spawnEnemy("hello");
        nextContainer=Instantiate(container);
        enemies = new Dictionary<string, GameObject>();
        StartCoroutine(FetchWord());
    }

    // Update is called once per frame
    void Update()
    {
        if (DataForGame.score >= DataForGame.limitScoreAfterChange)
        {
            DataForGame.increaseEnemiesSpeed();
            DataForGame.decreaseDelayTime();
            DataForGame.increaseLaserSpeedFactor();
            DataForGame.limitScoreAfterChange *= 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) && stopWords)
        {
            gameOver.gameObject.SetActive(false);
            startGameAgain();
            stopWords = false;
            StartCoroutine(FetchWord());
        }

        if (stopWords)
        {
            gameOver.gameObject.SetActive(true);

            StopAllCoroutines();
            Destroy(container);
        }
    }

    void spawnEnemy(string s)
    {
        Vector2 pos = new Vector2((Random.Range(DataForGame.xMin, DataForGame.xMax)), DataForGame.ySpawn);

        GameObject temp = Instantiate(enemy);
        temp.transform.position = pos;
        temp.GetComponent<EnemyScript>().WordOfTheAsteroid.text = s;
        enemies[s] = temp;
        temp.transform.parent = container.transform;
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

            if (temp.Length > 10) temp = temp.Substring(0, 10);
            spawnEnemy(temp);
            yield return new WaitForSeconds(DataForGame.delayTime);
        }
        
        
    }
    public void  startGameAgain()
    {
        container = nextContainer;
        nextContainer=Instantiate(container);
    }
    
}
