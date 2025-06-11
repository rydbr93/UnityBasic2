using System.Collections;
using UnityEngine;

public class UISlider : MonoBehaviour
{
    [SerializeField] bool isActiveStart;

    [SerializeField] Transform menu;
    [SerializeField] Transform activationPos;
    [SerializeField] Transform deActivationPos;
    [SerializeField] float constantDeltaTime;
    [SerializeField] float minSpeed = 0.1f;               // 최저속도
    Coroutine cor_MoveMenu;

    bool isActive;
    public bool IsActive
    {
        get{return isActive;}
        set
        {
            if(isActive == value) return;

            isActive = value;
            if(cor_MoveMenu != null) StopCoroutine(cor_MoveMenu);
            cor_MoveMenu = StartCoroutine(MoveMenuCoroutine());
        }
    }

    private void Awake() 
    {
        menu.position = isActiveStart ? activationPos.position : deActivationPos.position;
    }

    IEnumerator MoveMenuCoroutine()
    {
        float deltaTime = Time.fixedDeltaTime;
        float factor = 0;
        float nowConstantDeltaTime = 0;
        float addSpeed = 1;

        while (factor < 1)
        {
            if (constantDeltaTime != 0F)
            {
                addSpeed -= 2 * deltaTime;
                addSpeed = minSpeed < addSpeed ? addSpeed : minSpeed;

                nowConstantDeltaTime += addSpeed * deltaTime;
                factor = nowConstantDeltaTime / constantDeltaTime;

                if (isActive)
                {
                    menu.position = factor > 1F ? activationPos.position : Vector3.Lerp(deActivationPos.position, activationPos.position, factor);
                }
                else
                {
                    Vector3 active = new Vector3(menu.position.x, activationPos.position.y, menu.position.z);
                    Vector3 deActive = new Vector3(menu.position.x, deActivationPos.position.y, menu.position.z);

                    menu.position = factor > 1F ? deActivationPos.position : Vector3.Lerp(active, deActive, factor);
                }
            }

            yield return Util.waitFixed;
        }
    }
}
