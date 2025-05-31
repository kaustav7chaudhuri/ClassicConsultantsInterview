using System;

namespace Testing
{
    //INHERITANCE
   //public class MyClass
   // {
   //     public string Method()
   //     {
   //         return "Hello world";
   //     }
   // }
   // public class MyClass1:MyClass
   // {
         
   // }
   // public class Testing
   // {
   //     public static void Main(string[] args)
   //     {
   //         MyClass1 obj = new MyClass1();
   //         string result = obj.Method();
   //         Console.WriteLine(result);
   //     }

   // }


    //POLYMORPHISM & Method Overloading

    //public class MyClass
    //{
    //    public int Add(int x, int y)
    //    {
    //        return x + y;
    //    }
    //    public int Add(int x, int y, int z)
    //    {
    //        return x + y + z;
    //    }
    //    public int Add(int x, int y, int z, int k)
    //    {
    //        return x + y + z + k;
    //    }
    //    public static void Main(string[] args)
    //    {
    //        MyClass c = new MyClass();
    //        int result1 = c.Add(1, 2);
    //        int result2 = c.Add(2, 3, 6);
    //        int result3 = c.Add(8, 9, 7);
    //        Console.WriteLine($"{result1}\n{result2}\n {result3}") ;
    //    }
    //}

    //Method Overriding

    public class MyClass
    {
        public virtual string Method1()
        {
            return "Hello World ";
        }
    }
    public class MyClass2:MyClass
    {

    }   
    public class MainClass:MyClass
    {        
        public override string Method1()
        {
            return "Hello World! My name is Kaustav Chaudhuri";
        }
        public static void Main(string[] args)
        {
            MyClass2 obj2 = new MyClass2();
            string result2 = obj2.Method1();
            Console.WriteLine(result2);
            MyClass obj = new MyClass();
            string result = obj.Method1();
            Console.WriteLine(result);
            MainClass main = new MainClass();
            string result3 = main.Method1();
            Console.WriteLine(result3);
        }
    }
}