using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NPCController : MonoBehaviour
{
    public static NPCController instance;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount = 10;
    public float spawnWait = 1;
    public float startWait = 1;
    public float waveWait = 4;
   
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    void Update()
    {
       
        
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(
                   Random.Range(-spawnValues.x, spawnValues.x),
                   Random.Range(1, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    
}
