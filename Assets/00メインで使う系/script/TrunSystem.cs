using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrunSystem : MonoBehaviour
{
    float truntime = 10f;
    bool playertrun = false;
    bool enemytrun = false;
    
    public GameObject trunobject;
    //public TextMeshProUGUI truntext;
    public int truncount = 0;//実験で1にしている本番は0の予定
    //順番に動かす方法は最初に全て沸いている場合はなんとなく分かるけど
    //今回はターンで少しづつわくから沸いた数と固体を保存している沸くのに使ったスクリプトも重要かも
    //そこの中に移動支持を書くかもしれないがそれぞれの移動用のスクリプトを取る方法が分からない
    PlayerManager playerManager;
    EnemyManager enemyManager;//ひとまずこれでエネミーのターン管理するけど変わるかもしれない
    //public Text enemyText;
    private void Start()
    {
        //敵のターンから始めたほうが進行ルートより分かりやすいし攻められている感でると思う　もちろん沸かすだけ
        playerManager = GetComponent<PlayerManager>();
        enemyManager = GetComponent<EnemyManager>();
        trunobject.SetActive(false);
        enemyManager.TrunStart();
    }
    //ターン数を数えるもの追加
    //ターン終了時どうするか迷ってるけど正直どちらかを呼び出すだけな気もする
    //そのため他のちょっとした部分も書くかも
    //あと始めどうしようか迷い中　Updateに秒数を書いて一定時間たったら実行とか検討中
    //コルーチンもあり
    //もしくは最初からプレイヤーのターンで毎回ターン表示させるか検討中
    //UI表記の場合どこかで時間作らないといけない　今のところここでUpdateにif文のboolでどちらか判断してカウントするの検討中
    public void Ptrunend()
    {
        Debug.Log("pターン後");
        enemytrun = true;
    }
    public void Etrunend()
    {
        Debug.Log("eターン後");
        playertrun = true;
    }
    private void Update()
    {
        if (playertrun == true)
        {
            truntime -= Time.deltaTime;
            //Debug.Log("pスタート前");
                //playerManager.TrunStart();
                
                //playertrun = false;
                //truncount++;
            if (truntime <= 0)
            {
                trunobject.SetActive(false);
                Debug.Log("pスタート前");
                playerManager.TrunStart();
                truntime = 10f;
                playertrun = false;
                truncount++;
            }
        }else if (enemytrun == true)
        {
            //enemyManager.TrunStart();
            truntime -= Time.deltaTime;
            if (truntime <= 0)
            {
                enemyManager.TrunStart();
                truntime = 10f;
                enemytrun = false;
            }
        }
    }
    public void GameOver()
    {
        //ゲームオーバー関連のものを表示する 時間を止めてUI表示 倒した敵の数と残りの数を表示
    }
    public void GameClear()
    {
        Debug.Log("クリア");
        //ゲームクリア関連のものを表示する
    }
    float count = 1;
    public void Count()
    {
        trunobject.SetActive(true);
        //textの表示を変更する
        truntime = 3f;
        playertrun = true;
    }
}
