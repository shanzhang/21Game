using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _21Game
{
    
    /*
     * 这里分为几种情况考虑
     * 有一个总体的控制器委托消息的处理个各消息处理函数比较好控制
     * 根据接收到的来自UI的消息确定做什么操作
     * 1. 接收到来自button1的消息 
     *      新建一个游戏/重建一下玩家和庄家的数据
     *      返回一个三个数值 分别表示亮出的三张牌
     * 2. 接收到new hand的消息
     *      新建一盘游戏/与newgame不同的只有不兴建玩家庄家数据
     *      返回三个数值
     *      数值在数组中的序号有操作的契约约定好 只是作为改变UI的返回并不具其他用处
     *      当然如果直接出现结果的可能也要考虑进去即玩家直接获得BJ
     * 3. 接收到hit或者stay的消息
     *       hit轮流要牌
     *       stay直接出结果/具体的数组编码方式还要考虑
     */
    
    class GameController
    {
        private Banker banker;
        private Player player;
        private Deck deck;

        public List<int> Controller(int i, int bet)
        {
            switch (i)
            {
                case 1:
                    return NewGamehandler();
                case 2:
                    return NewHandhandler();
                case 3:
                    return Hithandler();
                case 4:
                    return Stayhandler();
                case 5:
                    return Bethandler(bet);
                default:
                    return null;
            }
        }

        public List<int> NewGamehandler()
        {
            banker=new Banker();
            player=new Player();
            deck=new Deck();
            player.drawCard(deck.drawCard());
            Thread.Sleep(30);
            banker.drawCard(deck.drawCard());
            Thread.Sleep(30);
            player.drawCard(deck.drawCard());
            Thread.Sleep(30);
            banker.drawCard(deck.drawCard());
            Thread.Sleep(30);

            int who_win=0, bj=0;

            if (player.isBlackJack() || banker.isBlackJack())
                bj = 1;
            if (player.isBlackJack() && !banker.isBlackJack())
            {
                who_win = 2;
                player.plusBet();
            }
            if (!player.isBlackJack() && banker.isBlackJack())
            {
                who_win = 1;
                player.minusBet();
            }
            if (player.isBlackJack() && banker.isBlackJack())
            {
                who_win = 0;
            }
            
            List<int> a = new List<int>();
            a.Add(bj);
            a.Add(who_win);
            foreach (int i in banker.cardNumbers())
            {
                a.Add(i);
            }
            foreach (int i in player.cardNumbers())
            {
                a.Add(i);
            }

            //考虑改为泛型
            
            //初始化各个成员变量即可
            //返回三个亮牌值 同时返回是否直接出现此盘结果即有人拿到BJ

            return a;
        }
        public List<int> NewHandhandler()
        {
            deck.initializeCard();
            player.clearCard();
            banker.clearCard();
            player.drawCard(deck.drawCard());
            Thread.Sleep(30);
            banker.drawCard(deck.drawCard());
            Thread.Sleep(30);
            player.drawCard(deck.drawCard());
            Thread.Sleep(30);
            banker.drawCard(deck.drawCard());
            Thread.Sleep(30);

            int who_win = 0, bj = 0;

            if (player.isBlackJack() || banker.isBlackJack())
                bj = 1;
            if (player.isBlackJack() && !banker.isBlackJack())
                who_win = 2;
            if (!player.isBlackJack() && banker.isBlackJack())
                who_win = 1;
            if (player.isBlackJack() && banker.isBlackJack())
                who_win = 0;

            List<int> b = new List<int>();
            b.Add(bj);
            b.Add(who_win);
            foreach (int i in banker.cardNumbers())
            {
                b.Add(i);
            }
            foreach (int i in player.cardNumbers())
            {
                b.Add(i);
            }
            //考虑改为泛型

            //修改各个对象的成员 玩家庄家手上的牌 牌组初始化
            //返回值与newgame相同

            return b;
        }
        public List<int> Hithandler()
        {
            List<int> retData = new List<int>();
            if (deck.getCardRemain() != 0)
            {
                Poke temp = deck.drawCard();
                player.drawCard(temp);
                if (player.isBurst())
                {
                    //1 3玩家 庄家 1 8
                    retData.Add(1);//爆了
                    retData.Add(player.cardNumbers().Count);
                    retData.Add(temp.getCardNumber());

                    List<int> tmp;
                    tmp = banker.cardNumbers();
                    foreach (int i in tmp)
                    {
                        retData.Add(i);
                    }
                    player.minusBet();
                    return retData;
                }
                else
                {
                    retData.Add(0);
                    retData.Add(player.cardNumbers().Count);
                    retData.Add(temp.getCardNumber());
                    return retData;
                }
            }
            else
                return null;


        }

        public List<int> Stayhandler()
        {
            List<int> returnData = new List<int>();
            List<int> bankercard;

            int whoWin = -1;//2:banker;1:palyer;0:tie

            while (banker.needDrawCard() && !banker.isBurst())
                banker.drawCard(deck.drawCard());

            if (!banker.isBurst())
            {
                if (banker.getCardTotal() > player.getCardTotal())
                { player.minusBet(); whoWin = 2; }//-money,banker win

                else if (banker.getCardTotal() == player.getCardTotal())
                    whoWin = 0;//tie

                else
                { whoWin = 1; player.plusBet(); }//+money,player win
            }
            else //banker brust,player win +money
            { player.plusBet(); whoWin = 1; }

            //返回banker's card给UI
            returnData.Add(whoWin);
            bankercard = banker.cardNumbers();
            returnData.Add(bankercard.Count());
            foreach (int i in bankercard)
                returnData.Add(i);
            return returnData;
        }

        public List<int> Bethandler(int bet)
        {
            player.setBet(bet);
            return null;
        }

        public int getPlayerScore()
        {
            return player.remainScore();
        }
    }
}
