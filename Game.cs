using System;
namespace Game
{
    class TicTac
    {
        char[,]board;
        static int[,] refe={{7,8,9},{4,5,6},{1,2,3}};

        TicTac(TicTac o)
        {
            this.board = o.board;
            //this.refe = refe;
        }

        TicTac()
        {
            this.board = new char[3,3];
        }
        
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
                this.board[m,n]=ch;
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
            TicTac cloneboard = new TicTac(this);
            for(i=0;i<=2;i++)
            {
                for(j=0;j<=2;j++)
                {
                    if(cloneboard.board[i,j]==' ')
                    {
                        cloneboard.check(refe[i,j],'X');
                        if(cloneboard.endgame('X',board) == false && cloneboard.checkifdraw()==true)
                            return true;
                        
                    }
                }
            }
            return false;
        }
        
        void copyboard(char [,] ar)
    {
        int i,j;
        for(i=0;i<3;i++)
        {
            for(j=0;j<3;j++)
            {
                ar[i,j]=board[i,j];
            }
        }
    }
        bool endgame(char ch, char [,] boardt)
        {
            int i;
            for(i=0;i<3;i++)
            {
                if(boardt[i,0]==boardt[i,1] && boardt[i,1]==boardt[i,2] && boardt[i,2]==ch)
                    return true;
                if(boardt[0,i]==boardt[1,i] && boardt[1,i]==boardt[2,i]&& boardt[2,i]==ch)
                    return true;
            }
            if(boardt[0,0]==board[1,1] && boardt[1,1]==boardt[2,2] && boardt[2,2]==ch)
                    return true;
            if(boardt[0,2]==boardt[1,1] && boardt[1,1]==boardt[2,0] && boardt[2,0]==ch)
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
                
                Console.WriteLine("PLAYER 1 turn ");
                turn++;
                n=Convert.ToInt32(Console.ReadLine());
                if(n==0)
                    goto startgame;
                g1.check(n,'X');
                g1.displayboard();
                
                
                    
                if(g1.endgame('X',g1.board) == true)
                {
                    Console.WriteLine("Player 1 wins");
                    Console.ReadKey();
                    break;
                   
                }
                

                
               

                Console.WriteLine("PLAYER 2 turn ");
                //turn++;
                if(turn== 7)
                {
                    int i,j,counter=0;
                    char [,] clone1 = new char[3,3];
                    char [,] clone2 = new char[3,3];
                    g1.copyboard(clone1);
                    g1.copyboard(clone2);
                    for(i=0;i<=2;i++)
                    {
                        for(j=0;j<=2;j++)
                        {
                            counter++;
                            if(counter==1)
                            {
                                clone1[i,j]='O';
                                clone2[i,j]='X';
                            }
                            if(counter==2)
                            {
                                clone1[i,j]='X';
                                clone2[i,j]='O';
                            }
                        }
                    }
                    if(g1.endgame('X',clone1)==false && g1.endgame('O',clone2)==false && g1.endgame('O',clone1)==false && g1.endgame('X',clone2)==false)
                    {
                        Console.WriteLine("Game is drawn");
                        Console.ReadKey();
                        break;
                    }

                }
                turn++;
                n=Convert.ToInt32(Console.ReadLine());
                if(n==0)
                    goto startgame;
                g1.check(n,'O');
                g1.displayboard();
                
                if(g1.endgame('O',g1.board) == true)
                {
                    Console.WriteLine("Player 2 wins");
                    Console.ReadKey();
                    break;
                }
            }
            
        }
    }
}