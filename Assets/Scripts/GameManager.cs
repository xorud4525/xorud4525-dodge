using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    public GameObject level;
    public GameObject BulletSpawnerPrefab;
    public GameObject itemPrefab;
    int prevltemCheck;

    private Vector3[] BulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime;
    private bool isGameover;
    void Start()
    {
        surviveTime = 0;
        isGameover = false;

        BulletSpawners[0].x = -8f;
        BulletSpawners[0].y = 1f;
        BulletSpawners[0].z = 8f;

        BulletSpawners[1].x = 8f;
        BulletSpawners[1].y = 1f;
        BulletSpawners[1].z = 8f;

        BulletSpawners[2].x = 8f;
        BulletSpawners[2].y = 1f;
        BulletSpawners[2].z = -8f;

        BulletSpawners[3].x = -8f;
        BulletSpawners[3].y = 1f;
        BulletSpawners[3].z = -8f;

    }

    // Update is called once per frame
    void Update()
    {
       if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;

            if(surviveTime%5f<=0.01f&&prevltemCheck==4)
            {
                Vector3 randpos = new Vector3(Random.Range(-8, 8f), 0f, Random.Range(-8f, 8f));

                GameObject item = Instantiate(itemPrefab, randpos, Quaternion.identity);
                item.transform.parent = level.transform;
                item.transform.localPosition = randpos;
            }
            prevltemCheck = (int)(surviveTime % 5f);
            if(surviveTime<5f&&spawnCounter==0)
            {
                GameObject BulletSpawner = Instantiate(BulletSpawnerPrefab, BulletSpawners[spawnCounter], Quaternion.identity);
                BulletSpawner.transform.parent = level.transform;
                BulletSpawner.transform.localPosition = BulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if(surviveTime>=5&&surviveTime<10&&spawnCounter==1)
            {
                GameObject BulletSpawner = Instantiate(BulletSpawnerPrefab, BulletSpawners[spawnCounter], Quaternion.identity);
                BulletSpawner.transform.parent = level.transform;
                BulletSpawner.transform.localPosition = BulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 10 && surviveTime < 15 && spawnCounter == 2)
            {
                GameObject BulletSpawner = Instantiate(BulletSpawnerPrefab, BulletSpawners[spawnCounter], Quaternion.identity);
                BulletSpawner.transform.parent = level.transform;
                BulletSpawner.transform.localPosition = BulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 15 && surviveTime < 20 && spawnCounter == 3)
            {
                GameObject BulletSpawner = Instantiate(BulletSpawnerPrefab, BulletSpawners[spawnCounter], Quaternion.identity);
                BulletSpawner.transform.parent = level.transform;
                BulletSpawner.transform.localPosition = BulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15;
                spawnCounter++;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime>bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
