using UnityEngine;
using UnityEngine.UI;
public class PlayerCooldownUI : MonoBehaviour
{
    [SerializeField] private Image cooldownBar;

    [SerializeField] private PlayerMovement playerMovement;
    void Update()
    {
        cooldownBar.fillAmount = playerMovement.GetCooldownPercent();
    }
}
