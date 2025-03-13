using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_PowerUpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _nameTextBackground;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.1f, .2f).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, .2f).SetUpdate(true);
    }

    public void SetupPowerUpData()
    {
        _nameText.text = "";
        _nameTextBackground.text = "";
    }

    public void SelectPower()
    {
        GameManager.Instance.UIManager.PowerUpMenu.CloseMenu();
        transform.localScale = Vector3.one;
    }
}
