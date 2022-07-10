using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDrop : MonoBehaviour {
    public GameObject hazard;
    public int hazardCount;
    public float startWait;
    public Vector3 spawnValues;
    public float spawnWait;
    public float waveWait;

    void Start ()
    {
      StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves () {
      yield return new WaitForSeconds (startWait);
      while (true) {
        for (int i = 0; i < hazardCount; i++) {
          Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(1, spawnValues.z));
          Quaternion spawnRotation = Quaternion.identity;
          Instantiate (hazard, spawnPosition, spawnRotation);
          yield return new WaitForSeconds(spawnWait); //물체 생성 수 다음 물체 생성까지 n초 대기
        }
        yield return new WaitForSeconds(waveWait);  //물체 집단 생성 후 n 초 후 다시 생성
      }
    }
}
