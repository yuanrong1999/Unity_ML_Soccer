using UnityEngine;

public class Ball : MonoBehaviour
{
    public static bool complete; //足球是否進門

    private void OnTriggerEnter(Collider other) //觸發開始事件:碰到勾選Is Trigger物件會執行一次
    {
        if(other.name== "Football_goal_cube") //若碰到物件為Football_goal_cube(球門感應區)is true,則進入球門
        {
            complete = true;
        }
    }
}
