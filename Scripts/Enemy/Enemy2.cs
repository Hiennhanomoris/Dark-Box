using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyAbstract
{
    private Vector2 startPos;
    private void Start() 
    {
        startPos = new Vector2(this.transform.position.x, this.transform.position.y);
    }
    public override void Move()
    {
        //follow player when he is nearing
        if(PlayerStatus.Instance.transform.position.x > startPos.x - moveDistance &&
            PlayerStatus.Instance.transform.position.x < startPos.x + moveDistance)
        {
            //move to player
            Vector2 temp = PlayerStatus.Instance.transform.position - this.transform.position;
            temp.y = 0;
            enemyRb.velocity = temp;
        }
        else
        {
            //turn back to startPosistion
            Vector2 temp = startPos - new Vector2(this.transform.position.x, this.transform.position.y);
            temp.y = 0;
            enemyRb.velocity = temp;
        }
    }
}
