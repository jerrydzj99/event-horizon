using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Program
{
    public int width = 5;
    public int height = 5;
    public bool TorF = false;
    public char room = '.';
    public char empty = '#';
    public char[,] field;
    List<Tuple<Vector2, Vector2>> frontier = new List<Tuple<Vector2, Vector2>>();

    void Start() 
    {
        char [,] field = new char[height, width];
        for (int i = 0; i < field.Length; i++)
        {
            char[] row = new char[width];
            for (int j = 0; j < row.Length; j++)
            {
                field[i,j] = '?';
            }
            Console.WriteLine(row);
        }
        Console.WriteLine(field);
    }

    void Carve(int y, int x)
    {
        List<Tuple<Vector2, Vector2>> extra = new List<Tuple<Vector2, Vector2>>();
        field[y,x] = '.';
        if (x > 0)
        {
            if(field[y, x-1] == '?')
            {
                field[y,x-1] = ','
                extra.Add(new Vector2(y, x-1));
            }
        } 
        if (x < width - 1)
        {
            if (field[y,x+1] == '?')
            {
                field[y,x+1] = ',';
                extra.Add(new Vector2(y, x+1));
            }
        }
        if (y > 0)
        {
            if (field[y-1, x] == '?')
            {
                field[y-1, x] = ',';
                extra.Add(new Vector2(y-1, x));
            }
        }
        if (y < height - 1)
        {
            if (field[y+1, x] == '?')
            {
                field[y+1,x] = ','
                extra.Add(new Vector2(y+1, x));
            }
        }

        random.shuffle(extra);
        frontier.add(extra);
    }

    void harden(int y, int x)
    {
        field[y, x] = empty;
    }

    void check(int y, int x)
    {
        int edgestate = 0;
        if (x > 0)
        {
            if (field[y,x-1] == room)
            {
                edgestate++;
            }

        }
        if (x < width - 1)
        {
            if (field[y,x+1] == room)
            {
                edgestate = edgestate + 10;
            }
        }
        if (y > 0)
        {
            if (field [y-1,x] == room)
            {
                edgestate = edgestate + 100;
            }

        }
        if (y < height-1)
        {
            if (field[y+1, x] == room)
            {
                edgestate = edgestate + 1000;
            }
        }
        if (edgestate == 1 || edgestate == 10 || edgestate == 100 || edgestate == 1000)
        {
            TorF = true;
        }
        else
        {
            TorF = false;
        }
        
    }

    public int start_x = random.Next(0, width-1);
    public int start_y = random.Next(0, height-1);
    public int final_x;
    public int final_y;
    public int size = 0;

    private void Main()
    {
        Carve(start_y, start_x);

        while(frontier.Length)
        {
            vector2 choice = frontier[frontier.length-1];
            if (check (choice))
            {
                Carve(choice);
            }
            else 
            {
                harden(choice);
            }
            frontier.Remove(choice);

            if(frontier.length >= size)
            {
                (final_y, final_x) = frontier[frontier.length - 1];
                size = frontier.length
            }
        }

        for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i,j] == '?')
                    {
                        field [i,j] = empty;
                    }
                }
            }
        field[start_y,start_x] = 'S';
        field[final_y, final_x] = 'G';
    }

}

    
    // public List<string> frontier = new List<string>();

    // private void Carve()
    // {
    //     private List<string> extra = new List<string>();

    // }

    // private void Awake() 
    // {

    // }