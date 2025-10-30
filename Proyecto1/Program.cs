var bob = new Sale("alo");
bob.print(bob.getX());

class Sale
{
    string x { get; set; }

    public Sale(string message)
    {
        x = message;
    }

    public String getX()
    {
        return x;
    }
    public void print(string x)
    {
        Console.WriteLine("del void "+x);
    }
}
