using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public TrunSystem trunSystem;
    ESpawn eSpawn;
    //湧く数が決まっているから倒れるたびに数を増やし、最大と同じになったら終了にする　勝利画面はどこで出すか迷い中
    //数の管理は同じところでやりたいからここでやろうかな ひとまず始めのステージということで湧く量は少なめ
    public int maxenemys = 10;
    public int enemyscount=0;
    public int nowenemys = 0;
    public  Wave[] waves;
    private int wave;
    public float time;
    public GroundEnemyAction groundaction;
    public List<GroundEnemyAction> groundEnemyActions;
    public List<FlyEnemyAction> flyEnemyActions;
    public List<GameObject> enemynumber;
    public int groundenemys = 0;
    int flyenemys = 0;
    
    private int nowtrun = 0;
    
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
    // Start is called before the first frame update
    void Start()
    {
        trunSystem = GetComponent<TrunSystem>();
        eSpawn = GetComponent<ESpawn>();
    }
    /*void Update()
    {
        wave = 0;
        time += Time.deltaTime;//ここよくわかっていない　多分使わない
        CreateEnemy();
    }*/
    public void TrunStart()
    {
        Debug.Log("eターンスタート");
        Debug.Log(trunSystem.truncount);
        Debug.Log(nowtrun);
        //沸かせるところからと思ったけどそうすると始めのターン二回行動する可能性があるそれが起きる場合は最後にわかしたほうがいい
        //上記のことも踏まえて始めに移動させて終わったら湧くようにする
        //CreateEnemy();
        groundenemys = 0;
        Enemysmove();

    }
    public void TrunEnd()
    {
        nowtrun++;
        Debug.Log(nowtrun);
        Debug.Log("eエンド");
        trunSystem.Etrunend();
    }
    public void EnemyDead()
    {
        enemyscount++;
        if (enemyscount >= maxenemys)
        {
            Debug.Log("クリア1");
            //trunSystem.GameClear();
        }
    }


    //void CreateEnemy()
    //{
    //    eSpawn.CreateEnemy();
    //}

    public void CreateEnemy()
    {
        Debug.Log(nowtrun);//なぜかここにくると0になっている
        //条件指定して値があれば実行とかにするのもいいかも　そうじゃないとforeachの時にエラーでるかもだし
        //２ターン毎に湧くようにしてそのターンで湧く要素を決めて的なのを今あるのをいじったらある程度は形になる
        if (nowtrun % 2 == 0)//なぜかここでだけtrunSystem.truncount
        {
            Debug.Log("クリエイトエネミー");
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
                    groundEnemyActions.Add(enemy.GetComponent<GroundEnemyAction>());
                }
                enemynumber.Add(enemy.gameObject);//敵をリストの中に追加するもの　追加出来たし望み道理gameObjectがしっかり入っていたから
                                                  //すべての敵を管理するために作ったけど死んだらターンシステムに直接アクセスして数いじればいい気がする
                                                  //enemyscount++;//敵の数のカウントを増やす
                                                  //考えとしてはgameObjectの変数を作ってエネミーを生成した時にそこに入れてその変数をリストに追加
                                                  //その際要素名で追加するとその要素が入るから要素の中身だけを追加するようにする　変数名.gameObjectで行けると思うがそのままでも大丈夫かも
                                                  //enemyscount++;//敵を作る時にenemyscountの数値を増やす

                /*if (pattern.time <= time)//timeの時間を使うけど今回は使わないからターン数になるかも
                {

                }*/
            }
            //waves[wave].patterns.RemoveAll(pattern => pattern.time <= time);//呼び出したものをクラスやリストから消す
            waves[wave].patterns = waves[wave].patterns;
            wave++;
            TrunEnd();

        }
        else
        {
            TrunEnd();
        }

    }


    public void Enemysmove()//敵の行動始めについて　リスト中のオブジェクトの行動を開始
    {
        //ひとまず地上と空中で湧ける予定だけど一緒でもいいかも
        if (enemynumber.Count > nowenemys)
        {
            groundaction = enemynumber[nowenemys].GetComponent<GroundEnemyAction>();
            if (groundaction != null)
            {
                //groundaction.raytrue = true;
                groundaction.Action();
                Debug.Log("gエネミーアクション");
            }
            //var enemy = enemynumber[nowenemys].GetComponent<EnemyController>();
        }
        else
        {
            //eSpawn.CreateEnemy();
            CreateEnemy();
        }
        
        
    }
    public void Nextenemys()//敵の行動終わりに呼び出し
    {
        Enemysmove();
    }
}
