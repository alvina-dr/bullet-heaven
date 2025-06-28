using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _nameTextBackground;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private UpgradeData _upgradeData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.1f, .2f).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, .2f).SetUpdate(true);
    }

    public void SetupPowerUpData(UpgradeData data)
    {
        _upgradeData = data;
        _nameText.text = data.Name;
        _nameTextBackground.text = data.Name;
        _descriptionText.text = data.Description;
    }

    public void SelectPower()
    {
        GameManager.Instance.UIManager.PowerUpMenu.CloseMenu();
        transform.localScale = Vector3.one;
    }
}
