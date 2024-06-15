using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESpawn : MonoBehaviour
{
    //敵をプレハブでそれぞれ保存
    //ターンが進むごとにカウントするものを用意してその数値が決まった数で割り切れたら沸かす
    //しかし、指定数分沸かしたら沸かさないようにカウントするintを用意する
    //沸いて生き残っているものを保存するリストがほしい
    //行動順番等で使う可能性がある
    public Wave[] waves;
    [Serializable]
    public class Wave
    {
        public List<EnemyPattern> patterns;
    }
    [Serializable]
    public class EnemyPattern
    {
        public float time;
        public EnemyController enemy;
        public Route route;
    }
    public GameObject Enemy;
    TrunSystem trunSystem;
    EnemyManager enemyManager;

    int nowtrun = 0;
    int wave = 0;
    int time;


    // Start is called before the first frame update
    void Start()
    {
        trunSystem = GetComponent<TrunSystem>();
        enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       public void CreateEnemy()
        {
            int trun = nowtrun;
            Debug.Log(trun);//なぜかここにくると0になっている
                            //条件指定して値があれば実行とかにするのもいいかも　そうじゃないとforeachの時にエラーでるかもだし
                            //２ターン毎に湧くようにしてそのターンで湧く要素を決めて的なのを今あるのをいじったらある程度は形になる
            if (nowtrun % 2 == 0)//なぜかここでだけtrunSystem.truncount
            {
                Debug.Log("クリエイトエネミー");
                //Debug.Log(trunSystem);
                //waveが対応している値と自分が考えている値が違う可能性
                Debug.Log(wave);
                foreach (var pattern in waves[wave].patterns)//Wavesのwave番のpatternsの数だけ実行 多分 ここは多分そのまま使える
                {

                    //var enemy = pattern.enemy;//今回動かす敵のenemycontrollerを取得
                    //enemy.GetComponent<EnemyController>().route = pattern.route;
                    var enemy = Instantiate(pattern.enemy, pattern.route.points[0].transform.position, Quaternion.identity);
                    enemy.route = pattern.route;//enemycontrollerのrouteにpatternのrouteを代入
                                                //Instantiate(pattern.enemy, enemy.route.points[0].transform.position, Quaternion.identity);//エネミー生成
                                                //二体目以降湧かない

                    if (enemy.GetComponent<GroundEnemyAction>())
                    {
                        enemy.GetComponent<GroundEnemyAction>().route = pattern.route;
                        Debug.Log("リストに追加");
                       enemyManager.groundEnemyActions.Add(enemy.GetComponent<GroundEnemyAction>());
                    }
                   enemyManager.enemynumber.Add(enemy.gameObject);//敵をリストの中に追加するもの　追加出来たし望み道理gameObjectがしっかり入っていたから
                                                      //すべての敵を管理するために作ったけど死んだらターンシステムに直接アクセスして数いじればいい気がする
                                                      //enemyscount++;//敵の数のカウントを増やす
                                                      //考えとしてはgameObjectの変数を作ってエネミーを生成した時にそこに入れてその変数をリストに追加
                                                      //その際要素名で追加するとその要素が入るから要素の中身だけを追加するようにする　変数名.gameObjectで行けると思うがそのままでも大丈夫かも
                                                      //enemyscount++;//敵を作る時にenemyscountの数値を増やす


                }
            waves[wave].patterns.RemoveAll(pattern => pattern.time <= time);//呼び出したものをクラスやリストから消す
                wave++;
                enemyManager.TrunEnd();

            }
            else
            {
                enemyManager.TrunEnd();
            }
        }
    }
