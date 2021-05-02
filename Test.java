public class Test
{
    int l,b;
    Test(Test o)
    {
        l=o.l;
        b=o.b;
    }
    Test()
    {
        l=5;
        b=10;
    }
    void display()
    {
        System.out.println("l = "+l+"b = "+b);
    }
    void change()
    {
        l+=5;
        b+=5;
    }
    public static void main(String[] args) 
    {
        Test g1 = new Test();
        Test clone = new Test(g1);
        clone.change();
        g1.display();
        clone.display();
    }
}
