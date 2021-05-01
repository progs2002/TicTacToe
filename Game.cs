using System;
namespace Game
{
    class TicTac
    {
        char[,]board = new char[3,3];
        int[,] refe={{7,8,9},{4,5,6},{1,2,3}};
        
        void clearboard()
        {
            int i,j;
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                    board[i,j]=' ';
            }
        }
        void displayboard()
        {
            Console.Clear();
            int i,j;
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                    Console.Write("["+board[i,j]+"] ");
                Console.WriteLine();
            }
        }
        void check(int num, char ch)
        {
            int i,j,m=0,n=0;
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                {
                    if(refe[i,j]==num)
                    {
                        m=i;
                        n=j;
                        goto LoopEnd;
                    }
                }
            }
            LoopEnd:
            {
                board[m,n]=ch;
            }
        }
        Boolean endgame(char ch)
        {
            int i;
            for(i=0;i<3;i++)
            {
                if(board[i,0]==board[i,1] && board[i,1]==board[i,2] && board[i,2]==ch)
                    return true;
                if(board[0,i]==board[1,i] && board[1,i]==board[2,i]&& board[2,i]==ch)
                    return true;
            }
            if(board[0,0]==board[1,1] && board[1,1]==board[2,2] && board[2,2]==ch)
                    return true;
            if(board[0,2]==board[1,1] && board[1,1]==board[2,0] && board[2,0]==ch)
                    return true;
            return false;
        }
        static void Main(String[]args)
        {
            TicTac g1 = new TicTac();
            int n;
            
            startgame:
            g1.clearboard();
            g1.displayboard();
            Console.WriteLine("PLAYER 1 is X PLAYER 2 is O");
            while(true)
            {
                
                Console.WriteLine("PLAYER 1 turn");
                n=Convert.ToInt32(Console.ReadLine());
                if(n==0)
                    goto startgame;
                g1.check(n,'X');
                g1.displayboard();
                if(g1.endgame('X') == true)
                {
                    Console.WriteLine("Player 1 wins");
                    Console.ReadKey();
                    break;
                   
                }
                Console.WriteLine("PLAYER 2 turn");
                n=Convert.ToInt32(Console.ReadLine());
                if(n==0)
                    goto startgame;
                g1.check(n,'O');
                g1.displayboard();
                if(g1.endgame('O') == true)
                {
                    Console.WriteLine("Player 2 wins");
                    Console.ReadKey();
                    break;
                }
            }
            
        }
    }
}

