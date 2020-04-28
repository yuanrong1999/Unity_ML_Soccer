using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// 足球是否進入球門
    /// </summary>
    public static bool complete;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "進球判斷")
        {
            complete = true;
        }
    }
}
