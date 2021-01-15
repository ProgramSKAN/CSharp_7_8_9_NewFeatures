using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharp_7_8_9.New_in_7._2
{
    public class Span_T_Demo
    {
        public static void Run()
        {
            unsafe
            {
                //pointers *
                //MANAGED MEMORY
                byte* ptr = stackalloc byte[100];
                Span<byte> memory = new Span<byte>(ptr,100);

                //UNMANAGED MEMORY
                IntPtr unmanagedPtr = Marshal.AllocHGlobal(123);
                Span<byte> unmanagedMemory = new Span<byte>(unmanagedPtr.ToPointer(),123);
                Marshal.FreeHGlobal(unmanagedPtr);
            }

            char[] stuff = "hello".ToCharArray();
            Span<char> arrayMemory = stuff;
            Console.WriteLine(stuff);

            //strings are immutable
            ReadOnlySpan<char> more = "hi there!".AsSpan();
            Console.WriteLine($"Out span has {more.Length} elements");

            arrayMemory.Fill('x');
            Console.WriteLine(stuff);
            arrayMemory.Clear();
            Console.WriteLine(stuff);
        }
    }
}
