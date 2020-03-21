using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject tab;
    // Start is called before the first frame update
    private void Start() =>
        this.GetComponent<Button>().onClick.AddListener(() => Execute());

    public void Execute()
    {
        button.onClick.Invoke();
        if (tab != null)
        {
            AudioManager.Instance.TabSound.SetActive(false);
            AudioManager.Instance.TabSound.SetActive(true);
            tab.transform.SetAsLastSibling();
        }
    }

}
