using System.Collections ; 
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public BatEnemy enemyPrefab ; 
    public float followDuration = 5f ; 
    private bool isFollowingPlayer ; 

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("trap")) 
        {
            if(!isFollowingPlayer)
            {
                
                StartCoroutine(FollowPlayer());
            }
        }
    }
    IEnumerator FollowPlayer() 
    {
        BatEnemy Enemy = Instantiate(enemyPrefab,this.transform.position,this.transform.rotation) ; 
        yield return new WaitForSeconds(followDuration); 
        Destroy(Enemy) ; 
        isFollowingPlayer = false ; 
    }


}


