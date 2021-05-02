using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnPoints;
    public GameObject roundText;
    public Round currentRound;
    public bool roundStarted;
    public int score;
    public float roundCountdown;
    public int spawnsRemaining;
    public List<Round> rounds = new List<Round>();

    private void Awake()
    {
        #region rounds 1-100
        rounds.Add(new Round(1, 10, 0));
        rounds.Add(new Round(2, 10, 0));
        rounds.Add(new Round(3, 10, 0));
        rounds.Add(new Round(4, 10, 0));
        rounds.Add(new Round(5, 10, 2));
        rounds.Add(new Round(6, 10, 2));
        rounds.Add(new Round(7, 10, 2));
        rounds.Add(new Round(8, 10, 2));
        rounds.Add(new Round(9, 10, 2));
        //round 10
        rounds.Add(new Round(10, 10, 0));
        rounds.Add(new Round(11, 10, 0));
        rounds.Add(new Round(12, 10, 0));
        rounds.Add(new Round(13, 10, 0));
        rounds.Add(new Round(14, 10, 0));
        rounds.Add(new Round(15, 10, 0));
        rounds.Add(new Round(16, 10, 0));
        rounds.Add(new Round(17, 10, 0));
        rounds.Add(new Round(18, 10, 0));
        rounds.Add(new Round(19, 10, 0));
        //round 20
        rounds.Add(new Round(20, 10, 0));
        rounds.Add(new Round(21, 10, 0));
        rounds.Add(new Round(22, 10, 0));
        rounds.Add(new Round(23, 10, 0));
        rounds.Add(new Round(24, 10, 0));
        rounds.Add(new Round(25, 10, 0));
        rounds.Add(new Round(26, 10, 0));
        rounds.Add(new Round(27, 10, 0));
        rounds.Add(new Round(28, 10, 0));
        rounds.Add(new Round(29, 10, 0));
        //round 30
        rounds.Add(new Round(30, 10, 0));
        rounds.Add(new Round(31, 10, 0));
        rounds.Add(new Round(32, 10, 0));
        rounds.Add(new Round(33, 10, 0));
        rounds.Add(new Round(34, 10, 0));
        rounds.Add(new Round(35, 10, 0));
        rounds.Add(new Round(36, 10, 0));
        rounds.Add(new Round(37, 10, 0));
        rounds.Add(new Round(38, 10, 0));
        rounds.Add(new Round(39, 10, 0));
        //round 40
        rounds.Add(new Round(40, 10, 0));
        rounds.Add(new Round(41, 10, 0));
        rounds.Add(new Round(42, 10, 0));
        rounds.Add(new Round(43, 10, 0));
        rounds.Add(new Round(44, 10, 0));
        rounds.Add(new Round(45, 10, 0));
        rounds.Add(new Round(46, 10, 0));
        rounds.Add(new Round(47, 10, 0));
        rounds.Add(new Round(48, 10, 0));
        rounds.Add(new Round(49, 10, 0));
        //round 50
        rounds.Add(new Round(50, 10, 0));
        rounds.Add(new Round(51, 10, 0));
        rounds.Add(new Round(52, 10, 0));
        rounds.Add(new Round(53, 10, 0));
        rounds.Add(new Round(54, 10, 0));
        rounds.Add(new Round(55, 10, 0));
        rounds.Add(new Round(56, 10, 0));
        rounds.Add(new Round(57, 10, 0));
        rounds.Add(new Round(58, 10, 0));
        rounds.Add(new Round(59, 10, 0));
        //round 60
        rounds.Add(new Round(60, 10, 0));
        rounds.Add(new Round(61, 10, 0));
        rounds.Add(new Round(62, 10, 0));
        rounds.Add(new Round(63, 10, 0));
        rounds.Add(new Round(64, 10, 0));
        rounds.Add(new Round(65, 10, 0));
        rounds.Add(new Round(66, 10, 0));
        rounds.Add(new Round(67, 10, 0));
        rounds.Add(new Round(68, 10, 0));
        rounds.Add(new Round(69, 10, 0));
        //round 70
        rounds.Add(new Round(70, 10, 0));
        rounds.Add(new Round(71, 10, 0));
        rounds.Add(new Round(72, 10, 0));
        rounds.Add(new Round(73, 10, 0));
        rounds.Add(new Round(74, 10, 0));
        rounds.Add(new Round(75, 10, 0));
        rounds.Add(new Round(76, 10, 0));
        rounds.Add(new Round(77, 10, 0));
        rounds.Add(new Round(78, 10, 0));
        rounds.Add(new Round(79, 10, 0));
        //round 80
        rounds.Add(new Round(80, 10, 0));
        rounds.Add(new Round(81, 10, 0));
        rounds.Add(new Round(82, 10, 0));
        rounds.Add(new Round(83, 10, 0));
        rounds.Add(new Round(84, 10, 0));
        rounds.Add(new Round(85, 10, 0));
        rounds.Add(new Round(86, 10, 0));
        rounds.Add(new Round(87, 10, 0));
        rounds.Add(new Round(88, 10, 0));
        rounds.Add(new Round(89, 10, 0));
        //round 90
        rounds.Add(new Round(90, 10, 0));
        rounds.Add(new Round(91, 10, 0));
        rounds.Add(new Round(92, 10, 0));
        rounds.Add(new Round(93, 10, 0));
        rounds.Add(new Round(94, 10, 0));
        rounds.Add(new Round(95, 10, 0));
        rounds.Add(new Round(96, 10, 0));
        rounds.Add(new Round(97, 10, 0));
        rounds.Add(new Round(98, 10, 0));
        rounds.Add(new Round(99, 10, 0));
        rounds.Add(new Round(100, 10, 0));
        #endregion
    }
    void Start()
    {
        roundStarted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartRound ()
    {
        roundText.GetComponent<Text>().text = "" + currentRound.roundNumber;
    }
    
}
public class Round
{
    public int roundNumber;
    public int zombie;
    public int demon;
    public Round(int roundNumber, int zombie, int demon)
    {
        this.roundNumber = roundNumber;
        this.zombie = zombie;
        this.demon = demon;
    }
}
