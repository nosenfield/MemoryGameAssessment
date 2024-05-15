using UnityEngine;
using UnityEngine.UI;

public class CardDisplayer : MonoBehaviour
{
    private Material currentDesign;
    [SerializeField] private Image cardImage;

    public void SetDesign(Material design)
    {
        currentDesign = cardImage.material = design;
    }
}