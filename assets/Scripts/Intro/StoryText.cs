using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    RectTransform storyTextTransform;
    [SerializeField]float speed;
    void Start()
    {
       storyTextTransform = GetComponent<RectTransform>();
       /* StartCoroutine(WaitChangeScene());   */
    }

    
    void Update()
    {
        storyTextTransform.localPosition += new Vector3 (0,speed/100,0);
    }
    /* IEnumerator WaitChangeScene(){
        yield return new WaitForSeconds(25);
        SceneManager.LoadScene(1);
    } */
}
