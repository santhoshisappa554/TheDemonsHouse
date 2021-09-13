using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawning : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemyprefab;
    [SerializeField]
    private GameObject[] spawnLocations;
    float test = 0;
    public int enemySpawnCount;



    // Start is called before the first frame update
    void Start()
    {
        if (enemySpawnCount > 0)
        {
            InvokeRepeating("Spawn", 1.0f, 5.0f);
            StartCoroutine("cancelInvoke");
            enemySpawnCount--;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn()
    {
        test = test + 0.5f;
        var val = Random.Range(0, spawnLocations.Length);
        print(val);
        Instantiate(Enemyprefab, spawnLocations[val].transform.position+new Vector3(test,0,test) , Quaternion.identity);

    }
    IEnumerator cancelInvoke()
    {
        yield return new WaitForSeconds(50.0f);
        CancelInvoke();
        
        
    }


}
