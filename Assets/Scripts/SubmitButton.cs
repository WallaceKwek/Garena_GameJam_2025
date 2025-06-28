using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    public void TurnOffButton()
    {
        gameObject.SetActive(false);
    }

    public void TurnOnButton()
    {
        gameObject.SetActive(true);
    }
}
