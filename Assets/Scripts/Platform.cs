using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
 //           if (transform.position.y > player.CurrentPlatform.transform.position.y)
 //           {
 //               Invoke("Destroy", 1f);
//                player.breakAudio.PlayDelayed(1f);
//            }
        }
    }

 //   private void Destroy()
 //   {
 //       gameObject.SetActive(false);
 //   }
}
