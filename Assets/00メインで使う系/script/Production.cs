using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    //生産
    //素材に関するものが出来たらif文で確認する
    public PlayerManager playerManager;
    public GameObject nomatelial;
    bool nomatelialtrue=false;
    float nomatelialtime = 1;
    // Start is called before the first frame update
    void Start()
    {
        //playerManager = GetComponent<PlayerManager>();
        nomatelial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nomatelialtrue == true)
        {
            
            nomatelial.SetActive(true);
            nomatelialtime -= Time.deltaTime;
            if (nomatelialtime <= 0)
            {
                nomatelial.SetActive(false);
            }
        }
    }
    //全体的に弓の生産が剣より楽になっている　出来るなら同じぐらいにしたいが金属を使うか使わないかがでかい
    //最悪剣がいないとクリア出来ないようにするのもあり
    public void Bow2()
    {
        if (playerManager.wood >= 1 && playerManager.rope >= 1 && playerManager.leather >= 1)
        {
            playerManager.bow2++;//増えなかったもしかしたら++がいけないかもしれない
            //素材のマイナスも実装
            playerManager.wood--;//２でもいいかも
            playerManager.rope--;//2でもいいかも
            playerManager.leather--;//正直弓を付くるだけなら要らないから１個でもいいかも
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }


    }
    public void Bow3()
    {
        if (playerManager.wood >= 1 && playerManager.rope >= 1 && playerManager.iron >= 1)
        {
            playerManager.bow3++;
            playerManager.wood-=2;//確定
            playerManager.rope--;//２でもいいかも
            playerManager.gold--;//必要素材の量を増やすか無理やり金を入れてコストあげるべき 一旦鉄じゃなくて金という設定にする　コストあげた
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }
    }
    public void Sword2()
    {
        if (playerManager.wood >= 1 && playerManager.rope >= 1 && playerManager.iron >= 1)
        {
            playerManager.sword2++;
            playerManager.wood--;
            playerManager.rope--;
            playerManager.iron--;
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }

    }
    public void Sword3()
    {
        if (playerManager.wood >= 1 && playerManager.gold >= 1 && playerManager.iron >= 1)
        {
            playerManager.sword3++;
            playerManager.wood--;//確定
            playerManager.gold--;//確定
            playerManager.iron-=2;//二個でもいいかも３個以上は多すぎる
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }

    }
}
