using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageShow : MonoBehaviour
{
    private TextMeshProUGUI message;

    // Start is called before the first frame update
    async void Start()
    {
        this.gameObject.SetActive(false);
        message = GetComponentInChildren<TextMeshProUGUI>();

        await Task.Delay(5000);

        ShowMessage("You Win!");
    }

    // wait for 1 second
    public void ShowMessage(string txt)
    {
        message.text = txt;
        this.gameObject.SetActive(true);
        Image image = GetComponent<Image>();
    }
}
