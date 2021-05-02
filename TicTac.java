import java.util.*;
class TicTac
{
    char[][]board;
    int[][] refe={{7,8,9},{4,5,6},{1,2,3}};

    TicTac(char[][] x)
    {
        board = x;
        //this.refe = refe;
    }

    TicTac(TicTac o)
    {
        this.board = o.board;
    }

    TicTac()
    {
        this.board = new char[3][3];
    }
    
    void clearboard()
    {
        int i,j;
        for(i=0;i<=2;i++)
        {
            for(j=0;j<=2;j++)
                board[i][j]=' ';
        }
    }
    void displayboard()
    {
        //Console.Clear();
        int i,j;
        for(i=0;i<=2;i++)
        {
            for(j=0;j<=2;j++)
                System.out.print("["+board[i][j]+"] ");
            System.out.print("\t\t");
            for(j=0;j<=2;j++)
                System.out.print("["+refe[i][j]+"] ");
            System.out.println();
        }
    }
    void check(int num, char ch)
    {
        int i,j,m=0,n=0;
        for(i=0;i<=2;i++)
        {
            for(j=0;j<=2;j++)
            {
                if(refe[i][j]==num && refe[i][j]!=0)
                {
                    
                    m=i;
                    n=j;
                    //goto LoopEnd;
                    board[m][n]=ch;
                }
            }
        }
        
    }
    boolean checkifdraw()
    {
        int i,j;
        boolean flag=true;
        for(i=0;i<=2;i++)
        {
            for(j=0;j<=2;j++)
            {
                if(board[i][j]==' ')
                    flag = false;
            }
        }
        return flag;
        
    }

    boolean predictdraw()
    {
        int i,j;
        TicTac cloneboard = new TicTac(this);
        for(i=0;i<=2;i++)
        {
            for(j=0;j<=2;j++)
            {
                if(cloneboard.board[i][j]==' ')
                {
                    cloneboard.check(refe[i][j],'X');
                    if(cloneboard.endgame('X',cloneboard.board) == false && cloneboard.checkifdraw()==true)
                        return true;
                    
                }
            }
        }
        return false;
    }
    
    boolean endgame(char ch , char boardt[][])
    {
        int i;
        for(i=0;i<3;i++)
        {
            if(boardt[i][0]==boardt[i][1] && boardt[i][1]==boardt[i][2] && boardt[i][2]==ch)
                return true;
            if(boardt[0][i]==boardt[1][i] && boardt[1][i]==boardt[2][i]&& boardt[2][i]==ch)
                return true;
        }
        if(boardt[0][0]==boardt[1][1] && boardt[1][1]==boardt[2][2] && boardt[2][2]==ch)
                return true;
        if(boardt[0][2]==boardt[1][1] && boardt[1][1]==boardt[2][0] && boardt[2][0]==ch)
                return true;
        return false;
    }

    void copyboard(char ar[][])
    {
        int i,j;
        for(i=0;i<3;i++)
        {
            for(j=0;j<3;j++)
            {
                ar[i][j]=board[i][j];
            }
        }
    }
    public static void main(String[]args) 
    {
        TicTac g1 = new TicTac();
        int n,turn=0;
        
        Scanner in = new Scanner(System.in);
        g1.clearboard();
        g1.displayboard();
        System.out.println("PLAYER 1 is X PLAYER 2 is O");
        while(true)
        {
            if(turn== 8 && g1.predictdraw()==true)
            {
                System.out.println("GAME IS DRAWN");
                //Console.ReadKey();
                break;
            }
            
            System.out.println("PLAYER 1 turn "+turn);
            turn++;
            n=in.nextInt();
            if(n==0)
                continue;
            g1.check(n,'X');
            g1.displayboard();
            
            
                
            if(g1.endgame('X',g1.board) == true)
            {
                System.out.println("Player 1 wins");
                //Console.ReadKey();
                break;
               
            }
            
            
           

            System.out.println("PLAYER 2 turn "+ turn);
            
            if(turn==7)
            {
             
                char clone1[][] = new char[3][3];
                char clone2[][] = new char[3][3];
                g1.copyboard(clone1);
                g1.copyboard(clone2);
                int i,j,counter=0;
                for(i=0;i<=2;i++)
                {   
                    for(j=0;j<=2;j++)
                    {
                        if(g1.board[i][j]==' ')
                        {
                            counter++;
                            if(counter==1)
                            {
                                clone1[i][j]='O';
                                clone2[i][j]='X';
                            }
                            if(counter==2)
                            {
                                clone1[i][j]='X';
                                clone2[i][j]='O';
                            }
                        }
                    }
                }
                if(g1.endgame('X',clone1)==false && g1.endgame('O',clone2)==false && g1.endgame('O',clone1)==false && g1.endgame('X',clone2)==false)
                {
                    System.out.println("Game is drawn");
                    break;
                }   
            }
            turn++;
            n=in.nextInt();
            if(n==0)
                continue;
            g1.check(n,'O');
            g1.displayboard();
            
            if(g1.endgame('O',g1.board) == true)
            {
                System.out.println("Player 2 wins");
                //Console.ReadKey();
                break;
            }
        }
        
        
    }
}