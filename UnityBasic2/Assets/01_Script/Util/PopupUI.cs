using UnityEngine;

public class PopupUI : MonoBehaviour
{
    protected virtual void Awake()
    {
        transform.position = UIControl.Instance.PopupPos.position;
        this.gameObject.SetActive(false);
    }

    public virtual void Initialize()
    {
        ActivePopUp();
    }

    public virtual void ActivePopUp()
    {
        this.gameObject.SetActive(true);
    }

    protected virtual void Close()
    {
        this.gameObject.SetActive(false);
    }
}
