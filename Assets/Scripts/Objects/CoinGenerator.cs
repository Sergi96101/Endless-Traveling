using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {
    public ObjectPooler myCoinPool;

    public float distBetwCoins;

    public void GenerateCoins(Vector3 startPos)
    {
        GameObject coin1 = myCoinPool.GetPooledObject();
        coin1.transform.position = startPos;
        coin1.SetActive(true);

        GameObject coin2 = myCoinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPos.x - distBetwCoins, startPos.y, startPos.z);
        coin2.SetActive(true);
    }
}
