using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coinValue = 1;
    public static int coinCount = 0;
    private TextMeshProUGUI coinCountText;

 private void Start()
{
    coinCountText = FindObjectOfType<TextMeshProUGUI>();

    if (coinCountText == null)
    {
        Debug.LogError("Coin count text not found!");
    }

    UpdateCoinCountText();
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinCount += coinValue;
            UpdateCoinCountText();
            Destroy(gameObject);
        }
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }
}
