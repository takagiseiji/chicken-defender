using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    TrunSystem trunSystem;
    //鶏小屋の体力
    int chickenhouse = 5;
    //2ターンで湧く場合の数を入れる変数
    int eggtrun;
    //卵、ひよこ、鶏の数 始めに入れる数は初期の卵の数
    public int egg = 0;
    public int chick = 0;
    public int chicken = 0;
    int beforechick = 0;
    int beforeegg = 0;

    //装備の数
    public int bow2 = 0;
    public int bow3 = 0;
    public int sword2 = 0;
    public int sword3 = 0;
    //素材を管理する数値を用意する　多すぎるのはよくないからこれぐらいかも
    //素材の収集はそのターンが終わった時か次のターン開始に入手するがどのようにそれを行うか
    //派遣した数を保管する関数を持っておき数分ランダムを行う　問題は場所
    //鶏の増やし方の方法で素材収集から餌を入手してとかも考えたけどそれは始めの鶏の数とかいろいろ調整し直さないと行けないから
    //ひとまずなしで行く
    //素材
    public int wood = 0;//弓の必須素材
    public int iron = 0;//剣とクロスボウに必用
    public int leather = 0;//二個目の弓と剣
    public int gold = 0;//最後の剣の素材
    public int rope = 0;//弓の必用素材
    //場所 今のところ二か所だけど追加するならあと一か所　その場所で二個は素材がとれるのが条件
    public int forest = 0;
    public int mine = 0;
    public int silverax;
    public int goldax;
    public int silverpickaxe;
    public int goldpickaxe;
    //出ている鶏をリストで管理する　拠点から近い順にリストを並べて実行予定　どうやって近い順にするのか分からない
    //たしか3Dタワーディフェンスの教材の動画に塔に近いものを攻撃するものがあったから参考に出来ると思う
    //剣と弓で分けていて剣からやる予定　しかし全て合わせて拠点から近い順にするのもありかな
    // Start is called before the first frame update
    void Start()
    {
        trunSystem = GetComponent<TrunSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TrunStart()//ターンはじめ
    {//毎回たまごを増やしているがもし別固体(牛や羊など)を出すようにした場合いまのステージの範囲では狭すぎる
        //そのため最初から決まった数だけ出せるようにするのもありな気がするけどそれは難しい
        //その場合は数を少なくするしかないかも　というかコスト関係を違うものにした方がいいかも　細かい調整まつりな気はする
        //ひとまずは鶏だけのままでいく
        Debug.Log("ｐスタート");
        egg += 4;
        chick = beforeegg;
        chicken += beforechick;
        beforeegg = egg;
        beforechick = chick;
        eggtrun++;
        //毎回の計算をどうするか迷い中　毎ターン卵が増えるより　２ターンに一回とか他にも増える数検討中
        //増える目安は2,3個ずつ 派遣があるから毎ターン増えた方がいいと思う　大体一回派遣出来るかどうかぐらいがいいのかも
        //じゃないと派遣しない場合多すぎることになるかも　しかしこれだと途中で派遣が間に合わなくて強化出来ないとかあるかも
        //だけど始めの襲撃まで時間あるからそれまでに増やすことが出来ればいいけどって感じ
        //そのため一定のターンがたったら多めに卵貰えるとか(5ターンに一回とか)遊んでもらわないと分からないから一旦取り入れる
        if (eggtrun == 5)//一定ターンがきたら追加で貰える
        {
            egg +=2;
            eggtrun = 0;
        }
        //Debug.Log("スタート");
        //Getmaterial();//ひとまず素材の入手はターン開始時に実行
        //ここの最後に卵とひよこの数を入れる
        //TrunEnd();
    }
    public void TrunEnd()//ターン終わり
    {
        trunSystem.Ptrunend();
        //ここでターン管理の自分のターンが終わったことを表すものを出す
    }
    public void Housedamege()
    {
        chickenhouse--;
        if (chickenhouse == 0)
        {
            trunSystem.GameOver();
        }
    }
    public void Getmaterial()//反映されるか確認のためにこれを実行するボタンを作る　実装出来たら消す
    {//素材ランダムだけど運要素になってしまうから固定にするか検討中
        //ランダムの場合どれぐらいにするか迷い　最大値は最低でも3以上　固定なら２　6は多すぎるかも
        for(int i = 0; i < forest; i++)
        {
            int material = Random.Range(0, 4);
            wood += material;
            //material = Random.Range(0, 4);
            //leather += material;//敵から落ちるようにして派遣ではとれなくするかも
            material = Random.Range(0, 4);
            rope += material;
        }
        for(int i = 0; i < mine; i++)
        {
            int material = Random.Range(0, 6);
            iron += material;
            int r = Random.Range(0, 2);//金が取れる確率は50%は高い気もする　３分の1ぐらいでいい気がする
            if (r == 1)
            {
                material = Random.Range(1, 4);
                gold += material;
            }
        }
        forest = 0;
        mine = 0;
    }
}
