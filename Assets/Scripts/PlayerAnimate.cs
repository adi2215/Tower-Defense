using UnityEngine;

namespace AdiSamController
{
    public class PlayerAnimate : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            
        }
    }
}
