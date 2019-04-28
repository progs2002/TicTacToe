import java.util.*;
class TTT
{
    public static void main(String[] args) 
    {
        System.out.println("WELCOME");
        char arr[][] = new char[3][3];
        System.out.println("Player 1 is X and Player 2 is O");
        while(true)
        {
            System.out.println("Player 1's turn");
            int x,y;
            Scanner in = new Scanner(System.in);
            x = in.nextInt();
            y = in.nextInt();
            if(arr[x][y]=='X'||arr[x][y]=='O')
            {
            	System.out.println("Position already taken");
            	continue;
            }
            arr[x][y]='X';
            printboard(arr);
            if(win(arr)=='X')
            {
                System.out.println("PLAYER 1 WINS");
                break;
            }
            else if(win(arr)=='O')
            {
                System.out.println("PLAYER 2 WINS");
                break;
            }
            System.out.println("Player 2's turn");
            x = in.nextInt();
            y = in.nextInt();
            if(arr[x][y]=='X'||arr[x][y]=='O')
            {
            	System.out.println("Position already taken");
            	continue;
            }
            arr[x][y]='O';
            printboard(arr);
            if(win(arr)=='O')
            {
                System.out.println("PLAYER 1 WINS");
                break;
            }
            else if(win(arr)=='O')
            {
                System.out.println("PLAYER 2 WINS");
                break;
            }

        }



        
    }
    public static void printboard(char arr[][])
    {
        for(int i = 0; i<3;i++)
        {
            for(int j=0; j<3;j++)
            {
                System.out.print("|"+arr[i][j]+"|");
            }
            System.out.println();
        }
    }
    public static char win(char arr[][])
    {
        int i,j;
        for(i=0;i<3;i++)
        {
            if(arr[i][0]==arr[i][1]&&arr[i][1]==arr[i][2]&&arr[i][2]=='X')
                return 'X';
            if(arr[i][0]==arr[i][1]&&arr[i][1]==arr[i][2]&&arr[i][2]=='O')
                return 'O';
        }
        for(i=0;i<3;i++)
        {
            if(arr[0][i]==arr[1][i]&&arr[1][i]==arr[2][i]&&arr[2][i]=='X')
                return 'X';
            if(arr[0][i]==arr[1][i]&&arr[1][i]==arr[2][i]&&arr[2][i]=='X')
                return 'O';
        }
        if(arr[0][0]==arr[1][1]&&arr[1][1]==arr[2][2]&&arr[2][2]=='X')
            return 'X';
        if(arr[0][0]==arr[1][1]&&arr[1][1]==arr[2][2]&&arr[2][2]=='O')
            return 'O';
        if(arr[0][2]==arr[1][1]&&arr[1][1]==arr[2][0]&&arr[2][0]=='X')
            return 'X';
        if(arr[0][2]==arr[1][1]&&arr[1][1]==arr[2][0]&&arr[2][0]=='O')
            return 'O';
        
        return 'a';
    }
}
