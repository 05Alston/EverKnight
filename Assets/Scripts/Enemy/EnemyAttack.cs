using UnityEngine;
using TMPro;
public class EnemyAttack : MonoBehaviour
{
    private float enemy =0;
    public GameObject game;
    public GameObject changeScene;
    public TextMeshProUGUI count;
    public void OnTriggerEnter2D(Collider2D o){
        if(o.transform.tag == "Enemy"){
            enemy++;
            count.text=enemy.ToString();
            Destroy(o.gameObject);
        }
        if(enemy==10){
            game.SetActive(false);
            changeScene.SetActive(true);
        }
    }

}
