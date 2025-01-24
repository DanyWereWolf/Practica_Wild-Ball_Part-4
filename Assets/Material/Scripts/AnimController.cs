using System.Collections;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string[] animationTriggers;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(RandomAnimationSwitch());
    }

    private IEnumerator RandomAnimationSwitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            // ��������� ����� ��������
            int randomIndex = Random.Range(0, animationTriggers.Length);
            string selectedTrigger = animationTriggers[randomIndex];

            // ��������� ��������� �������
            Debug.Log("Playing Animation: " + selectedTrigger);
            animator.SetTrigger(selectedTrigger);
        }
    }
}
