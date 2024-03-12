using UnityEngine;

namespace Bomb
{
    public class blast : MonoBehaviour
    {
        protected bool letPlay = true;
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("space"))
            {
                letPlay = !letPlay;
            }
     
            if(!letPlay)
            {
                if(!gameObject.GetComponent<ParticleSystem>().isPlaying)
                {
                    gameObject.GetComponent<ParticleSystem>().Play();
                    letPlay = !letPlay;
                }
            }else{
                if(gameObject.GetComponent<ParticleSystem>().isPlaying)
                {
                    gameObject.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
    }
}
