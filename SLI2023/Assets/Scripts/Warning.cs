using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warning : MonoBehaviour
{
    public static Warning Instance;
    public TMP_Text text;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        Warning.Instance = this;
        animator = GetComponent<Animator>();
    }

    public void ShowWarning(string message)
    {
        text.SetText(message);
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        animator.SetBool("IsWarning", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("IsWarning", false);
    }
}
