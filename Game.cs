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
                Console.Write("\t\t");
                for(j=0;j<=2;j++)
                    Console.Write("["+refe[i,j]+"] ");
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
                    if(refe[i,j]==num && refe[i,j]!=0)
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
        bool checkifdraw()
        {
            int i,j;
            bool flag=true;
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                {
                    if(board[i,j]==' ')
                        flag = false;
                }
            }
            return flag;
            
        }

        bool predictdraw()
        {
            int i,j;
            TicTac cloneboard = this;
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                {
                    if(cloneboard.board[i,j]==' ')
                    {
                        cloneboard.check(refe[i,j],'X');
                        if(cloneboard.endgame('X') == false && cloneboard.checkifdraw()==true)
                            return true;
                        
                    }
                }
            }
            return false;
        }
        bool predictdraw2()
        {
            int i,j,counter=0;
            TicTac clone1 = this;
            TicTac clone2 = this;
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                {
                    if(clone1.board[i,j]==' ')
                    {
                        counter++;
                        if(counter==1)
                        {
                            clone1.check(refe[i,j],'O');
                            clone2.check(refe[i,j],'X');
                        }
                        if(counter==2)
                        {
                            clone1.check(refe[i,j],'X');
                            clone2.check(refe[i,j],'O');
                        }
                    }
                }
            }
            if((clone1.endgame('X') == false && clone1.checkifdraw()==true)&&(clone2.endgame('X') == false && clone2.checkifdraw()==true))
                return true;
            else
                return false;
        }
        bool endgame(char ch)
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
            int n,turn=0;
            
            startgame:
            g1.clearboard();
            g1.displayboard();
            Console.WriteLine("PLAYER 1 is X PLAYER 2 is O");
            while(true)
            {
                if(turn== 8 && g1.predictdraw()==true)
                {
                    Console.WriteLine("GAME IS DRAWN");
                    Console.ReadKey();
                    break;
                }
                
                Console.WriteLine("PLAYER 1 turn");
                turn++;
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
                
                
                // if(turn== 7 && g1.predictdraw2()==true)
                // {
                //     Console.WriteLine("GAME IS DRAWN");
                //     Console.ReadKey();
                //     break;
                // }

                Console.WriteLine("PLAYER 2 turn");
                turn++;
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