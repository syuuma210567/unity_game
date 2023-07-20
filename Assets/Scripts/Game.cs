using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : SingletonMonoBehaviour<Game>
{
    public static readonly int XNum = 8;
    public static readonly int ZNum = 8;

    public static int BlackScore_ = 0;
    public static int WhiteScore_ = 0;

    public enum State
    { 
        None,
        Initializing,
        BlackTurn,
        WhiteTurn,
        Result,
    }

    public enum ResultText
    {
        None,
        BlackWin,
        Draw,
        WhiteWin,
    }

    public enum Handicap
    {
        Lv1,
        Lv2,
        Lv3,
    }

    [SerializeField]
    private Stone _stonePrefab;

    [SerializeField]
    private Transform _stoneBase;

    [SerializeField]
    private Player _selfPlayer;

    [SerializeField]
    private Player _enemyPlayer;

    [SerializeField]
    private TextMeshPro _blackScoreText;

    [SerializeField]
    private TextMeshPro _whiteScoreText;

    [SerializeField]
    private TextMeshPro _nowTurn;


    [SerializeField]
    private GameObject _cursor;
    public GameObject Cursor { get { return _cursor; } }


    public Stone[][] Stones { get; private set; }

    public State CurrentState { get; private set; } = State.None;

    public static ResultText Result = ResultText.None;

    public static Handicap CPULv = Handicap.Lv1;

    public int CurrentTurn
    {
        get
        {
            var turnCount = 0;
            for(var z = 0; z < ZNum; z++)
            {
                for(var x = 0; x < XNum; x++)
                {
                    if (Stones[z][x].CurrentState != Stone.State.None)
                    {
                        turnCount++;
                    }
                }
            }
            return turnCount;
        }
    }

    private void Start()
    {
        Stones = new Stone[ZNum][];
        for(var z = 0; z < ZNum; z++)
        {
            Stones[z] = new Stone[XNum];
            for(var x = 0; x < XNum; x++)
            {
                var stone = Instantiate(_stonePrefab, _stoneBase);
                var t = stone.transform;
                t.localPosition = new Vector3(x * 10, 0,z * 10);
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;
                //stone.SetActive(false, Stone.Color.Black);
                Stones[z][x] = stone;
            }
        }

        _cursor.SetActive(false);
        CurrentState = State.Initializing;
    }


    private void Update()
    {
        switch(CurrentState) 
        {
            case State.Initializing:
                {
                    for(var z = 0; z< ZNum; z++)
                    {
                        for( var x = 0;x < XNum; x++)
                        {
                            Stones[z][x].SetActive(false, Stone.Color.Black);
                        }
                    }
                    if (CPULv == Handicap.Lv1)
                    {
                        Stones[3][3].SetActive(true, Stone.Color.Black);
                        Stones[3][4].SetActive(true, Stone.Color.White);
                        Stones[4][3].SetActive(true, Stone.Color.White);
                        Stones[4][4].SetActive(true, Stone.Color.Black);
                    }
                    else if(CPULv == Handicap.Lv2)
                    {
                        int handicap = Random.Range(0, 4);

                        Stones[3][3].SetActive(true, Stone.Color.Black);
                        Stones[3][4].SetActive(true, Stone.Color.White);
                        Stones[4][3].SetActive(true, Stone.Color.White);
                        Stones[4][4].SetActive(true, Stone.Color.Black);

                        switch (handicap)
                        {
                            case 0:
                                {
                                    Stones[7][0].SetActive(true, Stone.Color.White);
                                    break;
                                }
                            case 1:
                                {
                                    Stones[0][7].SetActive(true, Stone.Color.White);
                                    break;
                                }
                            case 2:
                                {
                                    Stones[0][0].SetActive(true, Stone.Color.White);
                                    break;
                                }
                            case 3:
                                {
                                    Stones[7][7].SetActive(true, Stone.Color.White);
                                    break;
                                }
                        }

                    }
                    else if (CPULv == Handicap.Lv3)
                    {
                        //int handicap = Random.Range(0, 6);

                        Stones[3][3].SetActive(true, Stone.Color.Black);
                        //Stones[3][4].SetActive(true, Stone.Color.White);
                        //Stones[4][3].SetActive(true, Stone.Color.White);
                        //Stones[4][4].SetActive(true, Stone.Color.Black);
                        Stones[3][4].SetActive(true, Stone.Color.Black);
                        Stones[4][3].SetActive(true, Stone.Color.White);
                        Stones[4][4].SetActive(true, Stone.Color.White);


                        //Stones[7][0].SetActive(true, Stone.Color.White);
                        //Stones[7][1].SetActive(true, Stone.Color.White);
                        //Stones[7][2].SetActive(true, Stone.Color.White);
                        //Stones[7][3].SetActive(true, Stone.Color.White);
                        //Stones[7][4].SetActive(true, Stone.Color.White);
                        //Stones[7][5].SetActive(true, Stone.Color.White);
                        //Stones[7][6].SetActive(true, Stone.Color.White);
                        //Stones[7][7].SetActive(true, Stone.Color.White);

                        Stones[1][1].SetActive(true, Stone.Color.White);
                        Stones[1][2].SetActive(true, Stone.Color.White);
                        Stones[1][3].SetActive(true, Stone.Color.White);
                        Stones[1][4].SetActive(true, Stone.Color.White);
                        Stones[1][5].SetActive(true, Stone.Color.White);
                        Stones[1][6].SetActive(true, Stone.Color.White);

                        Stones[2][1].SetActive(true, Stone.Color.White);
                        Stones[3][1].SetActive(true, Stone.Color.White);
                        Stones[4][1].SetActive(true, Stone.Color.White);
                        Stones[5][1].SetActive(true, Stone.Color.White);
                        Stones[6][1].SetActive(true, Stone.Color.White);

                        Stones[6][1].SetActive(true, Stone.Color.White);
                        Stones[6][2].SetActive(true, Stone.Color.White);
                        Stones[6][3].SetActive(true, Stone.Color.White);
                        Stones[6][4].SetActive(true, Stone.Color.White);
                        Stones[6][5].SetActive(true, Stone.Color.White);
                        Stones[6][6].SetActive(true, Stone.Color.White);

                        Stones[1][6].SetActive(true, Stone.Color.White);
                        Stones[2][6].SetActive(true, Stone.Color.White);
                        Stones[3][6].SetActive(true, Stone.Color.White);
                        Stones[4][6].SetActive(true, Stone.Color.White);
                        Stones[5][6].SetActive(true, Stone.Color.White);
                        Stones[6][6].SetActive(true, Stone.Color.White);

                        //Stones[1][1].SetActive(true, Stone.Color.White);
                        //Stones[1][2].SetActive(true, Stone.Color.White);
                        //Stones[2][1].SetActive(true, Stone.Color.White);
                        //Stones[0][0].SetActive(true, Stone.Color.White);

                        //Stones[1][6].SetActive(true, Stone.Color.White);
                        //Stones[1][5].SetActive(true, Stone.Color.White);
                        //Stones[2][6].SetActive(true, Stone.Color.White);
                        //Stones[0][7].SetActive(true, Stone.Color.White);

                        //Stones[5][1].SetActive(true, Stone.Color.White);
                        //Stones[6][1].SetActive(true, Stone.Color.White);
                        //Stones[6][2].SetActive(true, Stone.Color.White);

                        //Stones[5][6].SetActive(true, Stone.Color.White);
                        //Stones[6][6].SetActive(true, Stone.Color.White);
                        //Stones[6][5].SetActive(true, Stone.Color.White);
                        //Stones[7][7].SetActive(true, Stone.Color.White);
                        //Stones[7][0].SetActive(true, Stone.Color.White);


                        //switch (handicap)
                        //{
                        //    case 0:
                        //        {
                        //            Stones[7][0].SetActive(true, Stone.Color.White);
                        //            Stones[7][7].SetActive(true, Stone.Color.White);
                        //            break;
                        //        }
                        //    case 1:
                        //        {
                        //            Stones[7][0].SetActive(true, Stone.Color.White);
                        //            Stones[0][7].SetActive(true, Stone.Color.White);
                        //            break;
                        //        }
                        //    case 2:
                        //        {
                        //            Stones[7][0].SetActive(true, Stone.Color.White);
                        //            Stones[0][0].SetActive(true, Stone.Color.White);
                        //            break;
                        //        }
                        //    case 3:
                        //        {
                        //            Stones[0][0].SetActive(true, Stone.Color.White);
                        //            Stones[0][7].SetActive(true, Stone.Color.White);
                        //            break;
                        //        }
                        //    case 4:
                        //        {
                        //            Stones[0][0].SetActive(true, Stone.Color.White);
                        //            Stones[7][7].SetActive(true, Stone.Color.White);
                        //            break;
                        //        }
                        //    case 5:
                        //        {
                        //            Stones[7][7].SetActive(true, Stone.Color.White);
                        //            Stones[0][7].SetActive(true, Stone.Color.White);
                        //            break;
                        //        }
                        //}
                    }
                    //_cursor.SetActive(false);
                    UpdateScore();

                    CurrentState = State.BlackTurn;

                }
                break;

            case State.BlackTurn:
                {
                    if(IsAnimating())
                    {
                        break;
                    }

                    if (_selfPlayer.TryGetSelected(out var x, out var z))
                    {
                        Stones[z][x].SetActive(true, Stone.Color.Black);
                        Reverse(Stone.Color.Black, x, z);
                        UpdateScore();
                        if (_enemyPlayer.CanPut())
                        {
                            CurrentState = State.WhiteTurn;
                            _nowTurn.text = "White Turn";
                            _nowTurn.color = Color.white;
                        }
                        else if(!_selfPlayer.CanPut())
                        {
                            CurrentState = State.Result;
                        }
                    }
                }
                break;

            case State.WhiteTurn:
                {
                    if (IsAnimating())
                    {
                        break;
                    }

                    if (_enemyPlayer.TryGetSelected(out var x, out var z))
                    {
                        Stones[z][x].SetActive(true, Stone.Color.White);
                        Reverse(Stone.Color.White, x, z);
                        UpdateScore();
                        if (_selfPlayer.CanPut())
                        {
                            CurrentState = State.BlackTurn;
                            _nowTurn.text = "Black Turn";
                            _nowTurn.color = Color.black;
                        }
                        else if(!_enemyPlayer.CanPut())
                        {
                            CurrentState = State.Result;
                        }
                    }
                }
                break;

            case State.Result:
                int blacks;
                int whites;
                CalcScore(out blacks, out whites);
                if(blacks > whites)
                {
                    //SceneManager.LoadScene("BlackWinScene");
                    Result = ResultText.BlackWin;
                }
                else if(blacks == whites)
                {
                    //SceneManager.LoadScene("DrawScene");
                    Result = ResultText.Draw;
                }
                else
                {
                    //SceneManager.LoadScene("WhiteWinScene");
                    Result = ResultText.WhiteWin;
                }
                SceneManager.LoadScene("ResultScene");

                BlackScore_ = blacks;
                WhiteScore_ = whites;

                break;

            case State.None:
            default:
                break;
        }
    }

    private bool IsAnimating()
    {
        for(var z = 0; z < ZNum; z++)
        {
            for(var x = 0; x < XNum; x++)
            {
                switch (Stones[z][x].CurrentState)
                {
                    case Stone.State.Appearing:
                    case Stone.State.Reversing:
                        return true;
                }
            }
        }
        return false;
    }


    private void UpdateScore()
    {
        int blackScore;
        int whiteScore;

        CalcScore(out blackScore, out whiteScore);
        _blackScoreText.text = blackScore.ToString();
        _whiteScoreText.text = whiteScore.ToString();

        //BlackScore_ = blackScore;
        //WhiteScore_ = whiteScore;
    }

    private void CalcScore(out int blackScore, out int whiteScore)
    {
        blackScore = 0;
        whiteScore = 0;

        for(var z = 0; z < ZNum; z++)
        {
            for(var x = 0; x < XNum; x++)
            {
                if (Stones[z][x].CurrentState != Stone.State.None)
                {
                    switch (Stones[z][x].CurrentColor)
                    {
                        case Stone.Color.Black:
                            blackScore++;
                            break;

                        case Stone.Color.White:
                            whiteScore++; 
                            break;
                    }
                }
            }
        }

    }

    private void Reverse(Stone.Color color, int putX, int putZ)
    {
        for(var dirZ = -1; dirZ <= 1; dirZ++)
        {
            for(var dirX = -1; dirX <= 1; dirX++)
            {
                var reverseCount = CalcReverseCount(color, putX, putZ, dirX, dirZ);
                for(var i = 1; i <= reverseCount; i++)
                {
                    Stones[putZ + dirZ * i][putX + dirX * i].Reverse();
                }
            }
        }
    }

    private int CalcReverseCount(Stone.Color color, int putX, int putZ, int dirX, int dirZ)
    {
        var x = putX;
        var z = putZ;
        var reverseCount = 0;
        for(var i = 0; i < 8; i++)
        {
            x += dirX;
            z += dirZ;
            if(x < 0 || x >= XNum || z < 0 || z >= ZNum)
            {
                reverseCount = 0;
                break;
            }

            var stone = Stones[z][x];
            if(stone.CurrentState == Stone.State.None)
            {
                reverseCount = 0;
                break;
            }
            else
            {
                if(stone.CurrentColor != color)
                {
                    reverseCount++;
                }
                else
                {
                    break;
                }
            }
        }

        return reverseCount;
    }

    public int CalctotalReverseCount(Stone.Color color, int putX, int putZ)
    {
        if (Stones[putZ][putX].CurrentState != Stone.State.None)
            return 0;

        var totalReverseCount = 0;
        for(var dirZ = -1; dirZ <= 1; dirZ++)
        {
            for(var dirX = -1; dirX <= 1;dirX++)
            {
                totalReverseCount += CalcReverseCount(color, putX, putZ, dirX, dirZ);
            }
        }
        return totalReverseCount;
    }
}




