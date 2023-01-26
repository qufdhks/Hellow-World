using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSnow : MonoBehaviour
{
    public GameObject snowEff;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(snowEff);//ÀÌÆåÆ® ÇÁ¸®ÆÕ »ý¼º
        eff.transform.position = transform.position;//ÀÌÆåÆ® ÇÁ¸®ÆÕ À§Ä¡ ¼³Á¤
        Destroy(gameObject);//ÇÁ¸®ÆÕ ÆÄ±«
    }
}
