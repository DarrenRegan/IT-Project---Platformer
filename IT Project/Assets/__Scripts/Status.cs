using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    //Variables
    [SerializeField] //Makes private variables show up in editor
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

    void Start()
    {
        if (healthBarRect == null){
            Debug.LogError("STATUS BAR: NO HP bar OBJECT REFERENCED");
        }
        if (healthText == null){
            Debug.LogError("STATUS BAR: NO HP text OBJECT REFERENCED");
        }
    }//start()

    public void SetHealth(int _cur, int _max)
    {
        float _value = ((float) _cur / _max);

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = _cur + "/" + _max + " HP";
    }
}
