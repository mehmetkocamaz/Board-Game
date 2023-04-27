using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    List<Card> shuffledCards;
    public Locations location;

    //int playerOneIndex = 0;
    //int playerTwoIndex = 0;
    //int playerThreeIndex = 0;
    //int playerFourIndex = 0;


    public GameObject cardsPrefab;
    public GameObject emptyCardsPrefab;
    
    public bool isStarted = false;
    public int overallTurn = 0;
    public int turn = 0;
    public Camera mainCamera;
    public Button startButton;
    public Button nextButton;
    public Button exitButton;
    public Button forceQuit;

    #region Towers Game Object

    public GameObject mainTower;

    #region Bonus Towers
    public GameObject sevenBonusTowerOne;
    public GameObject sevenBonusTowerTwo;
    public GameObject fourBonusTowerOne;
    public GameObject fourBonusTowerTwo;
    #endregion

    #region Escape Towers
    public GameObject fiveEscapeTowerOne;
    public GameObject fiveEscapeTowerTwo;
    public GameObject fiveEscapeTowerThree;
    public GameObject fiveEscapeTowerFour;

    public GameObject tenEscapeTowerOne;
    public GameObject tenEscapeTowerTwo;
    public GameObject tenEscapeTowerThree;
    public GameObject tenEscapeTowerFour;
    #endregion
    
    #endregion

    #region Player Class Object
    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;
    #endregion

    #region Player Game Object
    public GameObject playerOne;
    public Camera playerOneCamera;
    public Canvas playerOneCanvas;
    public Canvas playerOneInventory;
    public Button playerOneInventoryOpen;
    public Button playerOneInventoryClose;
    public Button playerOneNextCardButton;
    public Button playerOnePreviousCardButton;

    public GameObject playerTwo;
    public Camera playerTwoCamera;
    public Canvas playerTwoCanvas;
    public Canvas playerTwoInventory;
    public Button playerTwoInventoryOpen;
    public Button playerTwoInventoryClose;
    public Button playerTwoNextCardButton;
    public Button playerTwoPreviousCardButton;

    public GameObject playerThree;
    public Camera playerThreeCamera;
    public Canvas playerThreeCanvas;
    public Canvas playerThreeInventory;
    public Button playerThreeInventoryOpen;
    public Button playerThreeInventoryClose;
    public Button playerThreeNextCardButton;
    public Button playerThreePreviousCardButton;

    public GameObject playerFour;
    public Camera playerFourCamera;
    public Canvas playerFourCanvas;
    public Canvas playerFourInventory;
    public Button playerFourInventoryOpen;
    public Button playerFourInventoryClose;
    public Button playerFourNextCardButton;
    public Button playerFourPreviousCardButton;
    
    public int playerOneCardIndex = 0;
    public int playerTwoCardIndex = 0;
    public int playerThreeCardIndex = 0;
    public int playerFourCardIndex = 0;

    public int turnForPlayerOne = 1;
    public int turnForPlayerTwo = 1;
    public int turnForPlayerThree = 1;
    public int turnForPlayerFour = 1;
    #endregion

    void Start()
    {
        #region Cards Last
        List<Card> cards = new List<Card>() {
                //Insan
                new Card(1,CardRaces.Insan,CardType.Zýrh,1,1),
                new Card(2,CardRaces.Insan,CardType.Zýrh,1,1),
                new Card(3,CardRaces.Insan,CardType.Zýrh,2,1),
                new Card(4,CardRaces.Insan,CardType.Zýrh,2,3),
                new Card(5,CardRaces.Insan,CardType.Zýrh,2,3),
                new Card(6,CardRaces.Insan,CardType.Zýrh,3,5),

                new Card(7,CardRaces.Insan,CardType.Kask,1,1),
                new Card(8,CardRaces.Insan,CardType.Kask,1,1),
                new Card(9,CardRaces.Insan,CardType.Kask,2,1),
                new Card(10,CardRaces.Insan,CardType.Kask,2,3),
                new Card(11,CardRaces.Insan,CardType.Kask,2,3),
                new Card(12,CardRaces.Insan,CardType.Kask,3,5),

                new Card(13,CardRaces.Insan,CardType.Çizme,1,1),
                new Card(14,CardRaces.Insan,CardType.Çizme,1,1),
                new Card(15,CardRaces.Insan,CardType.Çizme,2,1),
                new Card(16,CardRaces.Insan,CardType.Çizme,2,3),
                new Card(17,CardRaces.Insan,CardType.Çizme,2,3),
                new Card(18,CardRaces.Insan,CardType.Çizme,3,5),

                new Card(19,CardRaces.Insan,CardType.TekEl,1,1),
                new Card(20,CardRaces.Insan,CardType.TekEl,1,1),
                new Card(21,CardRaces.Insan,CardType.TekEl,2,1),
                new Card(22,CardRaces.Insan,CardType.TekEl,2,3),
                new Card(23,CardRaces.Insan,CardType.TekEl,2,3),
                new Card(24,CardRaces.Insan,CardType.TekEl,3,5),
                new Card(25,CardRaces.Insan,CardType.TekEl,1,1),
                new Card(26,CardRaces.Insan,CardType.TekEl,2,3),
                new Card(27,CardRaces.Insan,CardType.TekEl,3,3),

                new Card(28,CardRaces.Insan,CardType.ÇiftEl,1,2),
                new Card(29,CardRaces.Insan,CardType.ÇiftEl,2,2),
                new Card(30,CardRaces.Insan,CardType.ÇiftEl,2,4),
                new Card(31,CardRaces.Insan,CardType.ÇiftEl,2,4),
                new Card(32,CardRaces.Insan,CardType.ÇiftEl,3,6),

                //Büyücü
                new Card(33,CardRaces.Büyücü,CardType.TekEl,1,1),
                new Card(34,CardRaces.Büyücü,CardType.TekEl,1,1),
                new Card(35,CardRaces.Büyücü,CardType.TekEl,2,1),
                new Card(36,CardRaces.Büyücü,CardType.TekEl,2,3),
                new Card(37,CardRaces.Büyücü,CardType.TekEl,3,3),
                new Card(38,CardRaces.Büyücü,CardType.TekEl,3,5),
                new Card(39,CardRaces.Büyücü,CardType.TekEl,2,3),

                new Card(40,CardRaces.Büyücü,CardType.Zýrh,1,1),
                new Card(41,CardRaces.Büyücü,CardType.Zýrh,2,3),
                new Card(42,CardRaces.Büyücü,CardType.Zýrh,3,5),

                new Card(43,CardRaces.Büyücü,CardType.Kask,1,1),
                new Card(44,CardRaces.Büyücü,CardType.Kask,2,3),
                new Card(45,CardRaces.Büyücü,CardType.Kask,3,5),

                new Card(46,CardRaces.Büyücü,CardType.Çizme,1,1),
                new Card(47,CardRaces.Büyücü,CardType.Çizme,2,3),
                new Card(48,CardRaces.Büyücü,CardType.Çizme,3,5),

                //Þaman
                new Card(49,CardRaces.Saman,CardType.Zýrh,1,1),
                new Card(50,CardRaces.Saman,CardType.Zýrh,2,3),
                new Card(51,CardRaces.Saman,CardType.Zýrh,3,5),

                new Card(52,CardRaces.Saman,CardType.Kask,1,1),
                new Card(53,CardRaces.Saman,CardType.Kask,2,3),
                new Card(54,CardRaces.Saman,CardType.Kask,3,5),

                new Card(55,CardRaces.Saman,CardType.Çizme,1,1),
                new Card(56,CardRaces.Saman,CardType.Çizme,2,3),
                new Card(57,CardRaces.Saman,CardType.Çizme,3,5),

                new Card(58,CardRaces.Saman,CardType.TekEl,1,1),
                new Card(59,CardRaces.Saman,CardType.TekEl,2,1),
                new Card(60,CardRaces.Saman,CardType.TekEl,2,3),
                new Card(61,CardRaces.Saman,CardType.TekEl,2,3),
                new Card(62,CardRaces.Saman,CardType.TekEl,3,5),

                new Card(63,CardRaces.Saman,CardType.ÇiftEl,2,4),
                new Card(64,CardRaces.Saman,CardType.ÇiftEl,2,4),

                //Kahin
                new Card(65,CardRaces.Kahin,CardType.Zýrh,1,1),
                new Card(66,CardRaces.Kahin,CardType.Zýrh,2,3),
                new Card(67,CardRaces.Kahin,CardType.Zýrh,3,5),

                new Card(68,CardRaces.Kahin,CardType.Kask,1,1),
                new Card(69,CardRaces.Kahin,CardType.Kask,2,3),
                new Card(70,CardRaces.Kahin,CardType.Kask,3,5),

                new Card(71,CardRaces.Kahin,CardType.Çizme,1,1),
                new Card(72,CardRaces.Kahin,CardType.Çizme,2,3),
                new Card(73,CardRaces.Kahin,CardType.Çizme,3,5),

                new Card(74,CardRaces.Kahin,CardType.TekEl,1,1),
                new Card(75,CardRaces.Kahin,CardType.TekEl,2,3),
                new Card(76,CardRaces.Kahin,CardType.TekEl,3,5),
                new Card(77,CardRaces.Kahin,CardType.TekEl,2,1),
                new Card(78,CardRaces.Kahin,CardType.TekEl,3,3),

                new Card(79,CardRaces.Kahin,CardType.ÇiftEl,2,4),
                new Card(80,CardRaces.Kahin,CardType.ÇiftEl,2,4),
            };
        #endregion

        shuffledCards = ShuffleCards(cards);


        #region Player Objesi
        player1 = new Player(playerOne.transform);
        player2 = new Player(playerTwo.transform);
        player3= new Player(playerThree.transform);
        player4 = new Player(playerFour.transform);
        #endregion

        Debug.Log(shuffledCards[0].ID + " " + shuffledCards[1].ID + " " + shuffledCards[2].ID);
        Debug.Log("----------------------------------------");
        player1.AddNewCard(shuffledCards[0]);
        player1.AddNewCard(shuffledCards[1]);
        player1.AddNewCard(shuffledCards[2]);

        player1.DisplayCards();

        player2.AddNewCard(shuffledCards[0]);
        player2.AddNewCard(shuffledCards[1]);
        player2.AddNewCard(shuffledCards[2]);

        player2.DisplayCards();

        player3.AddNewCard(shuffledCards[0]);
        player3.AddNewCard(shuffledCards[1]);
        player3.AddNewCard(shuffledCards[2]);

        player3.DisplayCards();

        player4.AddNewCard(shuffledCards[0]);
        player4.AddNewCard(shuffledCards[1]);
        player4.AddNewCard(shuffledCards[2]);

        player4.DisplayCards();

        //for (int i = 0; i < 20; ++i)
        //{

        //    if (i % 4 == 0 && i < 12)
        //    {
        //        player1.cardInventory[playerOneIndex++] = shuffledCards[i].ID;
        //        player1.AddNewCard(shuffledCards[i]);
        //        player1.AddNewEmptyCard();
        //        var myNewCard = Instantiate(cardsPrefab, cardsPrefab.transform.position, Quaternion.identity);
        //        myNewCard.transform.SetParent(playerOneInventory.transform);
        //        myNewCard.transform.localScale = new Vector3(1, 1, 1);
        //        myNewCard.transform.Rotate(0, -45, 0);
        //    }
        //    else if (i % 4 == 1 && i < 13)
        //    {
        //        player2.cardInventory[playerTwoIndex++] = shuffledCards[i].ID;
        //        var myNewCard = Instantiate(cardsPrefab, cardsPrefab.transform.position, Quaternion.identity);
        //        myNewCard.transform.SetParent(playerTwoInventory.transform);
        //        myNewCard.transform.localScale = new Vector3(1, 1, 1);
        //        myNewCard.transform.Rotate(0, 45, 0);
        //    }
        //    else if (i % 4 == 2 && i < 12)
        //    {
        //        player3.cardInventory[playerThreeIndex++] = shuffledCards[i].ID;
        //        var myNewCard = Instantiate(cardsPrefab, cardsPrefab.transform.position, Quaternion.identity);
        //        myNewCard.transform.SetParent(playerThreeInventory.transform);
        //        myNewCard.transform.localScale = new Vector3(1, 1, 1);
        //        myNewCard.transform.Rotate(0, -135, 0);
        //    }
        //    else if (i % 4 == 3 && i < 12)
        //    {
        //        player4.cardInventory[playerFourIndex++] = shuffledCards[i].ID;
        //        var myNewCard = Instantiate(cardsPrefab, cardsPrefab.transform.position, Quaternion.identity);
        //        myNewCard.transform.SetParent(playerFourInventory.transform);
        //        myNewCard.transform.localScale = new Vector3(1, 1, 1);
        //        myNewCard.transform.Rotate(0, -135, 0);
        //    }
        //    else
        //    {
        //        player1.cardInventory[i % 18] = 0;
        //        player2.cardInventory[i % 18] = 0;
        //        player3.cardInventory[i % 18] = 0;
        //        player4.cardInventory[i % 18] = 0;

        //    }
        //}
        //for (int i = 4; i < 19; i++)
        //{
        //    if (player1.cardInventory[i % 18] == 0)
        //    {
        //        var myNewCard = Instantiate(emptyCardsPrefab, emptyCardsPrefab.transform.position, Quaternion.identity);
        //        myNewCard.transform.SetParent(playerOneInventory.transform);
        //        myNewCard.transform.localScale = new Vector3(1, 1, 1);
        //        myNewCard.transform.Rotate(0, -45, 0);
        //        Debug.Log(player1.cardInventory[0] + " " + player2.cardInventory[1] + " " + player2.cardInventory[2] + " " + player2.cardInventory[3] + " " + player2.cardInventory[4] + " " +
        //            player2.cardInventory[5] + " " + player2.cardInventory[6] + " " + player2.cardInventory[7] + " " + player2.cardInventory[8] + " " + player2.cardInventory[9] + " " +
        //            player2.cardInventory[10] + " " + player2.cardInventory[11] + " " + player2.cardInventory[12] + " " + player2.cardInventory[13] + " " + player2.cardInventory[14] + " " +
        //            player2.cardInventory[15] + " " + player2.cardInventory[16] + " " + player2.cardInventory[17] + " ");
        //    }

        //}
    }

    void Update()
    {
        if (isStarted == false)
        {
            playerOneCamera.gameObject.SetActive(false);
            playerTwoCamera.gameObject.SetActive(false);
            playerThreeCamera.gameObject.SetActive(false);
            playerFourCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }

        else if (isStarted == true) 
        {
            
            startButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);

            Debug.Log("Tur: " + overallTurn);
            if (turn % 5 == 0)
            {
                #region Player1 Camera and Button
                playerOneCamera.gameObject.SetActive(true);
                playerTwoCamera.gameObject.SetActive(false);
                playerThreeCamera.gameObject.SetActive(false);
                playerFourCamera.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(false);

                playerOneCanvas.gameObject.SetActive(true);
                playerTwoCanvas.gameObject.SetActive(false);
                playerThreeCanvas.gameObject.SetActive(false);
                playerFourCanvas.gameObject.SetActive(false);
                #endregion


            }
            else if (turn % 5 == 1) 
            {
                #region Player2 Camera and Button
                playerOneCamera.gameObject.SetActive(false);
                playerTwoCamera.gameObject.SetActive(true);
                playerThreeCamera.gameObject.SetActive(false);
                playerFourCamera.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(false);

                playerOneCanvas.gameObject.SetActive(false);
                playerTwoCanvas.gameObject.SetActive(true);
                playerThreeCanvas.gameObject.SetActive(false);
                playerFourCanvas.gameObject.SetActive(false);
                #endregion


            }

            else if (turn % 5 == 2)
            {
                #region Player3 Camera and Button
                playerOneCamera.gameObject.SetActive(false);
                playerTwoCamera.gameObject.SetActive(false);
                playerThreeCamera.gameObject.SetActive(true);
                playerFourCamera.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(false);

                playerOneCanvas.gameObject.SetActive(false);
                playerTwoCanvas.gameObject.SetActive(false);
                playerThreeCanvas.gameObject.SetActive(true);
                playerFourCanvas.gameObject.SetActive(false);
                #endregion


            }
            else if (turn % 5 == 3)
            {
                #region Player4 Camera and Button
                playerOneCamera.gameObject.SetActive(false);
                playerTwoCamera.gameObject.SetActive(false);
                playerThreeCamera.gameObject.SetActive(false);
                playerFourCamera.gameObject.SetActive(true);
                mainCamera.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(false);

                playerOneCanvas.gameObject.SetActive(false);
                playerTwoCanvas.gameObject.SetActive(false);
                playerThreeCanvas.gameObject.SetActive(false);
                playerFourCanvas.gameObject.SetActive(true);
                #endregion

            }
            else if (turn % 5 == 4)
            {
                #region Kuþ Bakýþý Kamera
                playerOneCamera.gameObject.SetActive(false);
                playerTwoCamera.gameObject.SetActive(false);
                playerThreeCamera.gameObject.SetActive(false);
                playerFourCamera.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(true);

                playerOneCanvas.gameObject.SetActive(false);
                playerTwoCanvas.gameObject.SetActive(false);
                playerThreeCanvas.gameObject.SetActive(false);
                playerFourCanvas.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
                #endregion
                
            }
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game ending.");
        Application.Quit();
    }

    public void StartGame()
    {
        turnForPlayerOne = 1;
        turnForPlayerTwo = 1;
        turnForPlayerThree = 1;
        turnForPlayerFour = 1;
        Debug.Log("Game starting.");
        isStarted = true;
        forceQuit.gameObject.SetActive(true);
    }

    public void NextStep()
    {
        ++turn;
        playerOneInventory.gameObject.SetActive(false);
        playerTwoInventory.gameObject.SetActive(false);
        playerThreeInventory.gameObject.SetActive(false);
        playerFourInventory.gameObject.SetActive(false);

        playerOneCardIndex = 0;
        playerTwoCardIndex = 0;
        playerThreeCardIndex = 0;
        playerFourCardIndex = 0;

        playerOneInventoryOpen.gameObject.SetActive(true);
        playerTwoInventoryOpen.gameObject.SetActive(true);
        playerThreeInventoryOpen.gameObject.SetActive(true);
        playerFourInventoryOpen.gameObject.SetActive(true);
        
        playerOneInventoryClose.gameObject.SetActive(false);
        playerTwoInventoryClose.gameObject.SetActive(false);
        playerThreeInventoryClose.gameObject.SetActive(false);
        playerFourInventoryClose.gameObject.SetActive(false);

        if (turn%5 == 4)
        {
            overallTurn++;
        }
    }

    public void Forward()
    {
        if(playerOneCanvas.gameObject.activeSelf == true && turnForPlayerOne == 1)
        {
            if (playerOne.transform.position == location.locationOne.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerOne.transform.position) 
            {
                playerOne.transform.position = location.tenEscapeTowerOne.transform.position;
                playerOne.transform.rotation = location.tenEscapeTowerOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerOne.transform.position = mainTower.transform.position;
            }
            else if (playerOne.transform.position == location.locationTwo.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerOne.transform.position = location.tenEscapeTowerTwo.transform.position;
                playerOne.transform.rotation = location.tenEscapeTowerTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerOne.transform.position = mainTower.transform.position;            
            }
            else if (playerOne.transform.position == location.locationThree.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerOne.transform.position = location.tenEscapeTowerThree.transform.position;
                playerOne.transform.rotation = location.tenEscapeTowerThree.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerOne.transform.position = mainTower.transform.position;
            }
            else if (playerOne.transform.position == location.locationFour.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerOne.transform.position = location.tenEscapeTowerFour.transform.position;
                playerOne.transform.rotation = location.tenEscapeTowerFour.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerOne.transform.position = mainTower.transform.position;
            }
            else
            {
                ++turnForPlayerOne;
            }
            --turnForPlayerOne;
        }
        else if (playerTwoCanvas.gameObject.activeSelf == true && turnForPlayerTwo == 1)
        {
            if (playerTwo.transform.position == location.locationTwo.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerTwo.transform.position = location.tenEscapeTowerTwo.transform.position;
                playerTwo.transform.rotation = location.tenEscapeTowerTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerTwo.transform.position = mainTower.transform.position;
            }
            else if (playerTwo.transform.position == location.locationOne.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerTwo.transform.position = location.tenEscapeTowerOne.transform.position;
                playerTwo.transform.rotation = location.tenEscapeTowerOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerTwo.transform.position = mainTower.transform.position;
            }
            else if (playerTwo.transform.position == location.locationThree.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerTwo.transform.position = location.tenEscapeTowerThree.transform.position;
                playerTwo.transform.rotation = location.tenEscapeTowerThree.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerTwo.transform.position = mainTower.transform.position;
            }
            else if (playerTwo.transform.position == location.locationFour.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerTwo.transform.position = location.tenEscapeTowerFour.transform.position;
                playerTwo.transform.rotation = location.tenEscapeTowerFour.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerTwo.transform.position = mainTower.transform.position;
            }
            else
            {
                ++turnForPlayerTwo;
            }
            --turnForPlayerTwo;
        }
        else if (playerThreeCanvas.gameObject.activeSelf == true && turnForPlayerThree == 1)
        {
            if (playerThree.transform.position == location.locationThree.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerThree.transform.position;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerThree.transform.position = location.tenEscapeTowerThree.transform.position;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerThree.transform.position = mainTower.transform.position;
            }
            else if (playerThree.transform.position == location.locationOne.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerThree.transform.position = location.tenEscapeTowerOne.transform.position;
                playerThree.transform.rotation = location.tenEscapeTowerOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerThree.transform.position = mainTower.transform.position;
            }
            else if (playerThree.transform.position == location.locationTwo.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerThree.transform.position = location.tenEscapeTowerTwo.transform.position;
                playerThree.transform.rotation = location.tenEscapeTowerTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerThree.transform.position = mainTower.transform.position;
            }
            else if (playerThree.transform.position == location.locationFour.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerThree.transform.position = location.tenEscapeTowerFour.transform.position;
                playerThree.transform.rotation = location.tenEscapeTowerFour.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerThree.transform.position = mainTower.transform.position;
            }
            else
            {
                ++turnForPlayerThree;
            }
            --turnForPlayerThree;
        }
        else if (playerFourCanvas.gameObject.activeSelf == true && turnForPlayerFour == 1)
        {
            if (playerFour.transform.position == location.locationFour.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerFour.transform.position = location.tenEscapeTowerFour.transform.position;
                playerFour.transform.rotation = location.tenEscapeTowerFour.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerFour.transform.position = mainTower.transform.position;
            }
            else if (playerFour.transform.position == location.locationOne.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerFour.transform.position = location.tenEscapeTowerOne.transform.position;
                playerFour.transform.rotation = location.tenEscapeTowerOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerFour.transform.position = mainTower.transform.position;
            }
            else if (playerFour.transform.position == location.locationTwo.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerFour.transform.position = location.tenEscapeTowerTwo.transform.position;
                playerFour.transform.rotation = location.tenEscapeTowerTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerFour.transform.position = mainTower.transform.position;
            }
            else if (playerFour.transform.position == location.locationThree.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerFour.transform.position = location.tenEscapeTowerThree.transform.position;
                playerFour.transform.rotation = location.tenEscapeTowerThree.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerFour.transform.position = mainTower.transform.position;
            }
            else
            {
                ++turnForPlayerFour;
            }
            --turnForPlayerFour;
        }
    }
    public void Backward()
    {
        if (playerOneCanvas.gameObject.activeSelf == true && turnForPlayerOne == 1)
        {
            if (playerOne.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerOne.transform.position = location.locationOne.transform.position;
                playerOne.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerOne.transform.position.x == 0 && playerOne.transform.position.z == 0) //MAIN TOWER
            {
                playerOne.transform.position = location.tenEscapeTowerOne.transform.position;
                playerOne.transform.rotation = location.tenEscapeTowerOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerOne.transform.position = location.locationTwo.transform.position;
                playerOne.transform.rotation = location.locationTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerOne.transform.position = location.locationThree.transform.position;
                playerOne.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else if (playerOne.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerOne.transform.position = location.locationFour.transform.position;
                playerOne.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerOne.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerOne.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerOne.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else
            {
                ++turnForPlayerOne;
            }
            --turnForPlayerOne;
        }
        else if (playerTwoCanvas.gameObject.activeSelf == true && turnForPlayerTwo == 1)
        {
            if (playerTwo.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerTwo.transform.position = location.locationTwo.transform.position;
                playerTwo.transform.rotation = location.locationTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerTwo.transform.position.x == 0 && playerTwo.transform.position.z == 0) //MAIN TOWER
            {
                playerTwo.transform.position = location.tenEscapeTowerTwo.transform.position;
                playerTwo.transform.rotation = location.tenEscapeTowerTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerTwo.transform.position = location.locationOne.transform.position;
                playerTwo.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerTwo.transform.position = location.locationThree.transform.position;
                playerTwo.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else if (playerTwo.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerTwo.transform.position = location.locationFour.transform.position;
                playerTwo.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerTwo.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerTwo.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerTwo.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else
            {
                ++turnForPlayerTwo;
            }
            --turnForPlayerTwo;
        }
        else if (playerThreeCanvas.gameObject.activeSelf == true && turnForPlayerThree == 1)
        {
            if (playerThree.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerThree.transform.position = location.locationThree.transform.position;
                playerThree.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else if (playerThree.transform.position.x == 0 && playerThree.transform.position.z == 0) //MAIN TOWER
            {
                playerThree.transform.position = location.tenEscapeTowerThree.transform.position;
                playerThree.transform.rotation= location.tenEscapeTowerThree.transform.rotation;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerThree.transform.position = location.locationOne.transform.position;
                playerThree.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerThree.transform.position = location.locationTwo.transform.position;
                playerThree.transform.rotation = location.locationTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerThree.transform.position = location.locationFour.transform.position;
                playerThree.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerThree.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerThree.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerThree.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else
            {
                ++turnForPlayerThree;
            }
            --turnForPlayerThree;
        }
        else if (playerFourCanvas.gameObject.activeSelf == true && turnForPlayerFour == 1)
        {
            if (playerFour.transform.position == location.fiveEscapeTowerFour.transform.position)
            {
                playerFour.transform.position = location.locationFour.transform.position;
                playerFour.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerFour.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerFour.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerFour.transform.rotation;
            }
            else if (playerFour.transform.position.x == 0 && playerFour.transform.position.z == 0) //MAIN TOWER
            {
                playerFour.transform.position = location.tenEscapeTowerFour.transform.position;
                playerFour.transform.rotation= location.tenEscapeTowerFour.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerOne.transform.position)
            {
                playerFour.transform.position = location.locationOne.transform.position;
                playerFour.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerOne.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerOne.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerTwo.transform.position)
            {
                playerFour.transform.position = location.locationTwo.transform.position;
                playerFour.transform.rotation = location.locationTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerTwo.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerTwo.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.fiveEscapeTowerThree.transform.position)
            {
                playerFour.transform.position = location.locationThree.transform.position;
                playerFour.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerFour.transform.position == location.tenEscapeTowerThree.transform.position)
            {
                playerFour.transform.position = location.fiveEscapeTowerThree.transform.position;
                playerFour.transform.rotation = location.fiveEscapeTowerThree.transform.rotation;
            }
            else
            {
                ++turnForPlayerFour;
            }
            --turnForPlayerFour;
        }
        
    }
    public void ToTheRight()
    {
        if (playerOneCanvas.gameObject.activeSelf == true && turnForPlayerOne == 1)
        {
            if (playerOne.transform.position == location.locationOne.transform.position)
            {
                playerOne.transform.position = location.locationBiggerOne.transform.position;
                playerOne.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationBiggerOne.transform.position)
            {
                playerOne.transform.position = location.locationThree.transform.position;
                playerOne.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationThree.transform.position)
            {
                playerOne.transform.position = location.locationSmallOne.transform.position;
                playerOne.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationSmallOne.transform.position)
            {
                playerOne.transform.position = location.locationFour.transform.position;
                playerOne.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationFour.transform.position)
            {
                playerOne.transform.position = location.locationBiggerTwo.transform.position;
                playerOne.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerOne.transform.position = location.locationTwo.transform.position;
                playerOne.transform.rotation = location.locationTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationTwo.transform.position)
            {
                playerOne.transform.position = location.locationSmallTwo.transform.position;
                playerOne.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationSmallTwo.transform.position)
            {
                playerOne.transform.position = location.locationOne.transform.position;
                playerOne.transform.rotation = location.locationOne.transform.rotation;
            }
            else
            {
                ++turnForPlayerOne;
            }
            --turnForPlayerOne;
        }
        else if(playerTwoCanvas.gameObject.activeSelf == true && turnForPlayerTwo == 1)
        {
            if (playerTwo.transform.position == location.locationTwo.transform.position)
            {
                playerTwo.transform.position = location.locationSmallTwo.transform.position;
                playerTwo.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationSmallTwo.transform.position)
            {
                playerTwo.transform.position = location.locationOne.transform.position;
                playerTwo.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationOne.transform.position)
            {
                playerTwo.transform.position = location.locationBiggerOne.transform.position;
                playerTwo.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationBiggerOne.transform.position)
            {
                playerTwo.transform.position = location.locationThree.transform.position;
                playerTwo.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationThree.transform.position)
            {
                playerTwo.transform.position = location.locationSmallOne.transform.position;
                playerTwo.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationSmallOne.transform.position){
                playerTwo.transform.position = location.locationFour.transform.position;
                playerTwo.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationFour.transform.position)
            {
                playerTwo.transform.position = location.locationBiggerTwo.transform.position;
                playerTwo.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if ( playerTwo.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerTwo.transform.position = location.locationTwo.transform.position;
                playerTwo.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerTwo;
            }
            --turnForPlayerTwo;
        }
        else if (playerThreeCanvas.gameObject.activeSelf == true && turnForPlayerThree == 1)
        {
            if (playerThree.transform.position == location.locationTwo.transform.position)
            {
                playerThree.transform.position = location.locationSmallTwo.transform.position;
                playerThree.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationSmallTwo.transform.position)
            {
                playerThree.transform.position = location.locationOne.transform.position;
                playerThree.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationOne.transform.position)
            {
                playerThree.transform.position = location.locationBiggerOne.transform.position;
                playerThree.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationBiggerOne.transform.position)
            {
                playerThree.transform.position = location.locationThree.transform.position;
                playerThree.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationThree.transform.position)
            {
                playerThree.transform.position = location.locationSmallOne.transform.position;
                playerThree.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationSmallOne.transform.position)
            {
                playerThree.transform.position = location.locationFour.transform.position;
                playerThree.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationFour.transform.position)
            {
                playerThree.transform.position = location.locationBiggerTwo.transform.position;
                playerThree.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerThree.transform.position = location.locationTwo.transform.position;
                playerThree.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerThree;
            }
            --turnForPlayerThree;
        }
        else if (playerFourCanvas.gameObject.activeSelf == true && turnForPlayerFour == 1)
        {
            if (playerFour.transform.position == location.locationTwo.transform.position)
            {
                playerFour.transform.position = location.locationSmallTwo.transform.position;
                playerFour.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationSmallTwo.transform.position)
            {
                playerFour.transform.position = location.locationOne.transform.position;
                playerFour.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationOne.transform.position)
            {
                playerFour.transform.position = location.locationBiggerOne.transform.position;
                playerFour.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationBiggerOne.transform.position)
            {
                playerFour.transform.position = location.locationThree.transform.position;
                playerFour.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationThree.transform.position)
            {
                playerFour.transform.position = location.locationSmallOne.transform.position;
                playerFour.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationSmallOne.transform.position)
            {
                playerFour.transform.position = location.locationFour.transform.position;
                playerFour.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationFour.transform.position)
            {
                playerFour.transform.position = location.locationBiggerTwo.transform.position;
                playerFour.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerFour.transform.position = location.locationTwo.transform.position;
                playerFour.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerFour;
            }
            --turnForPlayerFour;
        }
    }

    public void ToTheLeft()
    {
        if (playerOneCanvas.gameObject.activeSelf == true && turnForPlayerOne == 1)
        {
            if (playerOne.transform.position == location.locationOne.transform.position)
            {
                playerOne.transform.position = location.locationSmallTwo.transform.position;
                playerOne.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationBiggerOne.transform.position)
            {
                playerOne.transform.position = location.locationOne.transform.position;
                playerOne.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationThree.transform.position)
            {
                playerOne.transform.position = location.locationBiggerOne.transform.position;
                playerOne.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationSmallOne.transform.position)
            {
                playerOne.transform.position = location.locationThree.transform.position;
                playerOne.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationFour.transform.position)
            {
                playerOne.transform.position = location.locationSmallOne.transform.position;
                playerOne.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerOne.transform.position = location.locationFour.transform.position;
                playerOne.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationTwo.transform.position)
            {
                playerOne.transform.position = location.locationBiggerTwo.transform.position;
                playerOne.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerOne.transform.position == location.locationSmallTwo.transform.position)
            {
                playerOne.transform.position = location.locationTwo.transform.position;
                playerOne.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerOne;
            }
            --turnForPlayerOne;
        }
        else if (playerTwoCanvas.gameObject.activeSelf == true && turnForPlayerTwo == 1)
        {
            if (playerTwo.transform.position == location.locationOne.transform.position)
            {
                playerTwo.transform.position = location.locationSmallTwo.transform.position;
                playerTwo.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationBiggerOne.transform.position)
            {
                playerTwo.transform.position = location.locationOne.transform.position;
                playerTwo.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationThree.transform.position)
            {
                playerTwo.transform.position = location.locationBiggerOne.transform.position;
                playerTwo.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationSmallOne.transform.position)
            {
                playerTwo.transform.position = location.locationThree.transform.position;
                playerTwo.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationFour.transform.position)
            {
                playerTwo.transform.position = location.locationSmallOne.transform.position;
                playerTwo.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerTwo.transform.position = location.locationFour.transform.position;
                playerTwo.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationTwo.transform.position)
            {
                playerTwo.transform.position = location.locationBiggerTwo.transform.position;
                playerTwo.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerTwo.transform.position == location.locationSmallTwo.transform.position)
            {
                playerTwo.transform.position = location.locationTwo.transform.position;
                playerTwo.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerTwo;
            }
            --turnForPlayerTwo;
        }
        else if (playerThreeCanvas.gameObject.activeSelf == true && turnForPlayerThree == 1)
        {
            if (playerThree.transform.position == location.locationOne.transform.position)
            {
                playerThree.transform.position = location.locationSmallTwo.transform.position;
                playerThree.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationBiggerOne.transform.position)
            {
                playerThree.transform.position = location.locationOne.transform.position;
                playerThree.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationThree.transform.position)
            {
                playerThree.transform.position = location.locationBiggerOne.transform.position;
                playerThree.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationSmallOne.transform.position)
            {
                playerThree.transform.position = location.locationThree.transform.position;
                playerThree.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationFour.transform.position)
            {
                playerThree.transform.position = location.locationSmallOne.transform.position;
                playerThree.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerThree.transform.position = location.locationFour.transform.position;
                playerThree.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationTwo.transform.position)
            {
                playerThree.transform.position = location.locationBiggerTwo.transform.position;
                playerThree.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerThree.transform.position == location.locationSmallTwo.transform.position)
            {
                playerThree.transform.position = location.locationTwo.transform.position;
                playerThree.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerThree;
            }
            --turnForPlayerThree;
        }
        else if (playerFourCanvas.gameObject.activeSelf == true && turnForPlayerFour == 1)
        {
            if (playerFour.transform.position == location.locationOne.transform.position)
            {
                playerFour.transform.position = location.locationSmallTwo.transform.position;
                playerFour.transform.rotation = location.locationSmallTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationBiggerOne.transform.position)
            {
                playerFour.transform.position = location.locationOne.transform.position;
                playerFour.transform.rotation = location.locationOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationThree.transform.position)
            {
                playerFour.transform.position = location.locationBiggerOne.transform.position;
                playerFour.transform.rotation = location.locationBiggerOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationSmallOne.transform.position)
            {
                playerFour.transform.position = location.locationThree.transform.position;
                playerFour.transform.rotation = location.locationThree.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationFour.transform.position)
            {
                playerFour.transform.position = location.locationSmallOne.transform.position;
                playerFour.transform.rotation = location.locationSmallOne.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationBiggerTwo.transform.position)
            {
                playerFour.transform.position = location.locationFour.transform.position;
                playerFour.transform.rotation = location.locationFour.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationTwo.transform.position)
            {
                playerFour.transform.position = location.locationBiggerTwo.transform.position;
                playerFour.transform.rotation = location.locationBiggerTwo.transform.rotation;
            }
            else if (playerFour.transform.position == location.locationSmallTwo.transform.position)
            {
                playerFour.transform.position = location.locationTwo.transform.position;
                playerFour.transform.rotation = location.locationTwo.transform.rotation;
            }
            else
            {
                ++turnForPlayerFour;
            }
            --turnForPlayerFour;
        }
    }

    public void NextStepMain()
    {
        ++turn;
        if(turn%5 == 4)
        {
            overallTurn++;
        }
        turnForPlayerOne = 1;
        turnForPlayerTwo = 1;
        turnForPlayerThree = 1;
        turnForPlayerFour = 1;
    }

    public void OpenInventoryPlayerOne()
    {
        playerOneInventory.gameObject.SetActive(true);
        playerOneInventoryOpen.gameObject.SetActive(false);
        playerOneInventoryClose.gameObject.SetActive(true);
        playerOneCanvas.gameObject.SetActive(false);
        for (int c = 0; c < 20; ++c)
        {
            playerOneInventory.transform.GetChild(c).gameObject.SetActive(false);
            playerOneNextCardButton.gameObject.SetActive(true);
            if(playerOneCardIndex == 0 && playerOneCardIndex < 18)
            {
                playerOnePreviousCardButton.gameObject.SetActive(true);
            }
        }
    }
    public void OpenInventoryPlayerTwo()
    {
        playerTwoInventory.gameObject.SetActive(true);
        playerTwoInventoryOpen.gameObject.SetActive(false);
        playerTwoInventoryClose.gameObject.SetActive(true);
        playerTwoCanvas.gameObject.SetActive(false);
        for (int c = 0; c < 20; ++c)
        {
            playerTwoInventory.transform.GetChild(c).gameObject.SetActive(false);
            playerTwoNextCardButton.gameObject.SetActive(true);
            playerTwoPreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void OpenInventoryPlayerThree()
    {
        playerThreeInventory.gameObject.SetActive(true);
        playerThreeInventoryOpen.gameObject.SetActive(false);
        playerThreeInventoryClose.gameObject.SetActive(true);
        playerThreeCanvas.gameObject.SetActive(false);
        for (int c = 0; c < 20; ++c)
        {
            playerThreeInventory.transform.GetChild(c).gameObject.SetActive(false);
            playerThreeNextCardButton.gameObject.SetActive(true);
            playerThreePreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void OpenInventoryPlayerFour()
    {
        playerFourInventory.gameObject.SetActive(true);
        playerFourInventoryOpen.gameObject.SetActive(false);
        playerFourInventoryClose.gameObject.SetActive(true);
        playerFourCanvas.gameObject.SetActive(false);
        for (int c = 0; c < 20; ++c)
        {
            playerFourInventory.transform.GetChild(c).gameObject.SetActive(false);
            playerFourNextCardButton.gameObject.SetActive(true);
            playerFourPreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void CloseInventoryPlayerOne()
    {
        playerOneInventory.gameObject.SetActive(false);
        playerOneInventoryOpen.gameObject.SetActive(true);
        playerOneInventoryClose.gameObject.SetActive(false);
        playerOneCanvas.gameObject.SetActive(true);
    }
    public void CloseInventoryPlayerTwo()
    {
        playerTwoInventory.gameObject.SetActive(false);
        playerTwoInventoryOpen.gameObject.SetActive(true);
        playerTwoInventoryClose.gameObject.SetActive(false);
        playerTwoCanvas.gameObject.SetActive(true);
    }
    public void CloseInventoryPlayerThree()
    {
        playerThreeInventory.gameObject.SetActive(false);
        playerThreeInventoryOpen.gameObject.SetActive(true);
        playerThreeInventoryClose.gameObject.SetActive(false);
        playerThreeCanvas.gameObject.SetActive(true);
    }
    public void CloseInventoryPlayerFour()
    {
        playerFourInventory.gameObject.SetActive(false);
        playerFourInventoryOpen.gameObject.SetActive(true);
        playerFourInventoryClose.gameObject.SetActive(false);
        playerFourCanvas.gameObject.SetActive(true);
    }
    public void NextCardPlayerOne()
    {
        if(playerOneCardIndex < 19)
        {
            playerOneInventory.transform.GetChild(++playerOneCardIndex).gameObject.SetActive(true);
            playerOneCardIndex = playerOneCardIndex % 20;
            playerOneInventory.transform.GetChild(playerOneCardIndex - 1).gameObject.SetActive(false);
            playerOneNextCardButton.gameObject.SetActive(true);
            playerOnePreviousCardButton.gameObject.SetActive(true);
        }
        else if (playerOneCardIndex >= 18)
        {
            playerOneCardIndex = 0;
            for (int c = 0; c < 20; c++)
            {
                playerOneInventory.transform.GetChild(c).gameObject.SetActive(false);
                playerOneNextCardButton.gameObject.SetActive(true);
                playerOnePreviousCardButton.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Error!");
        }
    }
    public void NextCardPlayerTwo()
    {
        if (playerTwoCardIndex < 18)
        {
            playerTwoInventory.transform.GetChild(++playerTwoCardIndex).gameObject.SetActive(true);
            playerTwoCardIndex = playerTwoCardIndex % 18;
            playerTwoInventory.transform.GetChild(playerTwoCardIndex - 1).gameObject.SetActive(false);
            playerTwoNextCardButton.gameObject.SetActive(true);
            playerTwoPreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void NextCardPlayerThree()
    {
        if (playerThreeCardIndex < 18)
        {
            playerThreeInventory.transform.GetChild(++playerThreeCardIndex).gameObject.SetActive(true);
            playerThreeCardIndex = playerThreeCardIndex % 18;
            playerThreeInventory.transform.GetChild(playerThreeCardIndex - 1).gameObject.SetActive(false);
            playerThreeNextCardButton.gameObject.SetActive(true);
            playerThreePreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void NextCardPlayerFour()
    {
        if (playerFourCardIndex < 18)
        {
            playerFourInventory.transform.GetChild(++playerFourCardIndex).gameObject.SetActive(true);
            playerFourCardIndex = playerFourCardIndex % 18;
            playerFourInventory.transform.GetChild(playerFourCardIndex - 1).gameObject.SetActive(false);
            playerFourNextCardButton.gameObject.SetActive(true);
            playerFourPreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void PreviousCardPlayerOne()
    {

        if (playerOneCardIndex > -1 && playerOneCardIndex <= 18)
        {
            playerOneInventory.transform.GetChild(--playerOneCardIndex).gameObject.SetActive(true);
            playerOneCardIndex = playerOneCardIndex % 18;
            playerOneInventory.transform.GetChild(playerOneCardIndex + 1).gameObject.SetActive(false);
            playerOneNextCardButton.gameObject.SetActive(true);
            playerOnePreviousCardButton.gameObject.SetActive(true);
        }
        else if (playerOneCardIndex == -1)
        {
            playerOneCardIndex = 18;
            for (int c = 0; c < 20; c++)
            {
                playerOneInventory.transform.GetChild(c).gameObject.SetActive(false);
                playerOneNextCardButton.gameObject.SetActive(true);
                playerOnePreviousCardButton.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Error!");
        }
    }
    public void PreviousCardPlayerTwo()
    {
        if (playerTwoCardIndex < 18)
        {
            playerTwoInventory.transform.GetChild(--playerTwoCardIndex).gameObject.SetActive(true);
            playerTwoCardIndex = playerTwoCardIndex % 18;
            playerTwoInventory.transform.GetChild(playerTwoCardIndex + 1).gameObject.SetActive(false);
            playerTwoNextCardButton.gameObject.SetActive(true);
            playerTwoPreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void PreviousCardPlayerThree()
    {
        if (playerThreeCardIndex < 18)
        {
            playerThreeInventory.transform.GetChild(--playerThreeCardIndex).gameObject.SetActive(true);
            playerThreeCardIndex = playerThreeCardIndex % 18;
            playerThreeInventory.transform.GetChild(playerThreeCardIndex + 1).gameObject.SetActive(false);
            playerThreeNextCardButton.gameObject.SetActive(true);
            playerThreePreviousCardButton.gameObject.SetActive(true);
        }
    }
    public void PreviousCardPlayerFour()
    {
        if (playerFourCardIndex < 18)
        {
            playerFourInventory.transform.GetChild(--playerFourCardIndex).gameObject.SetActive(true);
            playerFourCardIndex = playerFourCardIndex % 18;
            playerFourInventory.transform.GetChild(playerFourCardIndex + 1).gameObject.SetActive(false);
            playerFourNextCardButton.gameObject.SetActive(true);
            playerFourPreviousCardButton.gameObject.SetActive(true);
        }
    }

    private List<Card> ShuffleCards(List<Card> list)
    {
        System.Random random = new System.Random();
        var newShuffledList = new List<Card>();
        var listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            var randomElementInList = random.Next(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }
}
