using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    public Transform puntGeneracio;

    private int selectorPlataforma;
    private int contZone;

    public ObjectPooler[] poolFons;
    public ObjectPooler[] poolPlatformsBasic;
    public ObjectPooler[] poolPlatformsBounce;

    public enum mapa {Basic, Bounce, Jetpack, Change};
    public mapa cas;

    public GeneradorPlataformes genP;
    public GeneradorBackground genB;

	public Player_Movement myPlayer;

    public GameObject changeZone;

	// Use this for initialization
	void Start () {
        cas = mapa.Basic;
        contZone = 1;
	}

    // Update is called once per frame
    void Update() {
        if (transform.position.x < puntGeneracio.position.x)
        {
            switch (cas) {
                case mapa.Basic:
                    {
                        genB.newFons = getBackground((int)cas);
                        genP.newPlatform = getPlatform((int)cas);
                        ++contZone;
                        break;
                    }
                case mapa.Bounce:
                    {
                        genB.newFons = getBackground((int)cas);
                        genP.newPlatform = getPlatform((int)cas);
                        ++contZone;
                        break;
                    }
                case mapa.Jetpack:
                    {
                        genB.newFons = getBackground((int)cas);
                        ++contZone;
                        break;
                    }
                case mapa.Change:
                    {
                        changeZone = Instantiate(changeZone);
                        contZone = 1;
                        break;
                    }
            }
            cas = setZone((int)cas, contZone);

            /*if (myPlayer.changeM == true) {
                if (genB.cas == GeneradorBackground.mapa.Basic)
                {
                    myPlayer.bouncingActive = false;
                    myPlayer.jetpackActive = false;
                }
                else if (genB.cas == GeneradorBackground.mapa.Rebot)
                {
                    myPlayer.jetpackActive = false;
                    myPlayer.bouncingActive = true;
                }
                else if (genB.cas == GeneradorBackground.mapa.Jetpack)
                {
                    myPlayer.bouncingActive = false;
                    myPlayer.jetpackActive = true;

                }
                myPlayer.changeM = false;
            }*/
        }
    }
    GameObject getBackground(int backgroundType)
    {
        return poolFons[backgroundType].GetPooledObject();
    }

    GameObject getPlatform(int platformType)
    {
        int platformSelector = Random.Range(0, 4);
        if (platformType == 1)
        {
            return poolPlatformsBasic[platformSelector].GetPooledObject();
        }
        else
        {
            return poolPlatformsBounce[platformSelector].GetPooledObject();
        }
    }

    mapa setZone(int zoneType, int contZone)
    {

        if (contZone == 5)
        {
            return mapa.Change;
        }
        else if (contZone == 1)
        {
            return (mapa)Random.Range(0, 3);
        }
        else
        {
            return (mapa)zoneType;
        }
    }
}
