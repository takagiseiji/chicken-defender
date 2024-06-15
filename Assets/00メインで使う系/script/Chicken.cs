using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    //攻撃の呼び出しをどうするか検討中　同じ関数で命令出来るといいけど弓と剣で攻撃系変わるからそれは無理　ここに書いても中で分ける
    //矢を出すか出さないかがあるから同じは無理だと思う　剣と弓でリスト分けて剣→弓の順番で攻撃するのあり
    //個体値
    public int hp=5;//一発か二発で倒されるぐらいのHP　防具は防御力として計算する予定だけどHPをその分増やすでもあり


    //武器系数値
    public int level = 0;//レベルを確認するもの
    int[] power = new int[3]{1,2,3};//攻撃力の配列
    int attack;
    //アセットから消去しようとしてデータの損失がおきるかも的な感じでエラー出るから
    //リストをやめてそれぞれ別の関数で用意する　学校始まったら聞いてみる
    //ちなみにもしこれでもダメならプレハブ作り直したり等の細かいところやってみて出来なければ別から行う
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    //public GameObject[] weapons = new GameObject[3];//武器を入れておく配列
    //public GameObject[] armors = new GameObject[3];//防具というものを作る場合なら使う
    //int[] guard = { 1, 2, 3 };
    GameObject nowWeapon;//念のため用意した今持ってる武器を確認するもの　しかしDestroyするとこれ自体が消えないか心配 資料では大丈夫だった
    public Transform weaponpoint;//武器が湧く位置
    //被ダメージ
    public int takendamage;
    Vector3 weponrotation;//武器の方向を入れる変数
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(weapons[0], weaponpoint);//ここの武器の向きは大丈夫になった
        nowWeapon = weapon2;
        Instantiate(nowWeapon,weaponpoint);
        attack = power[level];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void Weaponup()
    {//思いつく方法を試したけどリスト内のものだからできないらしい　クローンを消す方法があるのならそれもありだけど
     //レベルダウンさせるつもりもないから要素を消すでもいいかも
        //Destroy(weapons[level - 1].gameObject);
        //Instantiate(weapons[level].gameObject, weaponpoint);
        Destroy(nowWeapon);
        //nowWeapon.GetComponent<Weapons>().Change();
        nowWeapon = weapons[level].gameObject; Debug.Log("チェンジ");
        Instantiate(nowWeapon,weaponpoint);Debug.Log("生成");
        attack = power[level];
    }*/
    public void Weapon2()
    {
        DestroyImmediate(nowWeapon,true);
        nowWeapon = weapon2;
        Instantiate(nowWeapon, weaponpoint);
        attack = power[level];
    }
    public void Weapon3()
    {
        Destroy(nowWeapon.gameObject);
        nowWeapon = weapon3;
        Instantiate(nowWeapon, weaponpoint);
        attack = power[level];
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
    public void Damage()
    {
        Debug.Log("ダメージ");
        hp -= takendamage;
        if (hp <= 0) Destroy(gameObject);
    }
}
