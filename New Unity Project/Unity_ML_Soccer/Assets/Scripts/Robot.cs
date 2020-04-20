using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class Robot : Agent
{
    [Header("速度"), Range(1, 50)]
    public float speed = 10;
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

        Ball.complate = false;//設事件開始時通關條件尚未成功(足球尚未進入球門)
    }

    public override void CollectObservations(VectorSensor sensor)//事件開始時:重新設定機器人與足球位置
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(rigBall.position);
        sensor.AddObservation(rigRobot.velocity.x);
        sensor.AddObservation(rigRobot.velocity.z);
    }

    public override void AgentAction(float[] vectorAction)
    {
        Vector3 control = Vector3.zero;
        control.x = vectorAction[0];
        control.z = vectorAction[0];
        rigRobot.AddForce(control * speed);

        if (Ball.complate)
        {
            SetReward(1);
            EndEpisode();
        }
        if (transform.position.y < 0 || rigBall.position.y < 0) //失敗 扣1分並結束(機器人or除足球掉至地板下)
        {
            SetReward(-1);
            EndEpisode();
        }
    }

    public override float[] Heuristic() //探索:讓開發者測試環境(官方提供的測試方式) 
    {
        var action = new float[2];
        action[0] = Input.GetAxis("Horizontal");
        action[1] = Input.GetAxis("Vertical");
        return action;
    }

}
