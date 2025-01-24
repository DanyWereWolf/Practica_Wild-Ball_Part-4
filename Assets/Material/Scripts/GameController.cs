using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace WildBall.inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class GameController : MonoBehaviour
    {

        [SerializeField, Range(0, 20)] private float speed = 2f;
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Vector3 movement;
        [SerializeField] public float impactForce = 5f;
        [SerializeField] public bool hasKey = false;
        [SerializeField] public Text bonusText;
        [SerializeField] public int bonusInt = 0;
        internal object rb;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        void Update()
        {
            bonusText.text = bonusInt.ToString();

            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(-horizontal, 0, -vertical).normalized;
        }
        private void FixedUpdate()
        {
            MoveCaracter();
        }
        private void MoveCaracter()
        {
            playerRigidbody.AddForce(movement * speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (collision.gameObject.CompareTag("Barrel"))
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                otherRigidbody.AddForce(direction * impactForce, ForceMode.Impulse);
            }
        }

        private void OnTriggerEnter(Collider other)
        {            
            if (other.CompareTag("Key")) 
            {
                hasKey = true; 
                Destroy(other.gameObject); 
            }
            else if (other.CompareTag("Coin"))
            {
                bonusInt += 1;
                Destroy(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
          
        }
        public void Drag()
        {
            playerRigidbody.linearDamping = 100f;
        }

#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        public void ResetValues()
        {
            speed = 2f;
        }
#endif
    }
}