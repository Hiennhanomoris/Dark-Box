using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private Transform[] enemy1SpawnTranform;

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start() 
    {
        StartCoroutine(SpawnEnemy1());    
    }

    private IEnumerator SpawnEnemy1()
    {
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < enemy1SpawnTranform.Length; i++)
        {
            Instantiate(enemy1, enemy1SpawnTranform[i].position, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }
}