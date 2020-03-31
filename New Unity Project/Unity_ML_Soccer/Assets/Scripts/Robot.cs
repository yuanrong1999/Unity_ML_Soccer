using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class Robot : Agent
{
    private Rigidbody rigRobot; //機器人剛體
    private Rigidbody rigBall; //足球剛體

    private void Start()
    {
        rigRobot = GetComponent<Rigidbody>();
        rigBall = GameObject.Find("Soccer Ball").GetComponent<Rigidbody>();
    }
    public override void OnEpisodeBegin() //事件開始時:重新設定機器人與足球位置
    {
        /*base.OnEpisodeBegin();*/
        rigRobot.velocity = Vector3.zero;
        rigRobot.angularVelocity = Vector3.zero;
        rigBall.velocity = Vector3.zero;
        rigBall.angularVelocity = Vector3.zero;

        Vector3 posRobot = new Vector3(Random.Range(-2f, 2f), 0.1f, Random.Range(-2f, 0)); //Robot隨機位置
        transform.position = posRobot;

        Vector3 posBall = new Vector3(Random.Range(-2f, 2f), 0.1f, Random.Range(1f, 2f)); //Soccer剛體隨機位置
        rigBall.position = posBall;
    }
}
