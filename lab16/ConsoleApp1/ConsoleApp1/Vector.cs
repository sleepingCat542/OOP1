﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Vector
    {
        Random random = new Random();
        public List<int> vector = new List<int>();
        public Vector(int n)
        {
            for (int i = 0; i < n; i++)
            {
                vector.Add(random.Next(n));
            }
        }
        public int Length { get => vector.Count; }
        public int this[int num]
        {
            get => vector[num];
            set => vector[num] = value;
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 1; i < vector.Count; i++)
            {
                sum += vector[i];
            }
            return sum;
        }
        public void Sort()
        {
            vector.Sort();
        }
        public static Vector operator *(Vector vec, int n)
        {
            for (int i = 0; i < vec.vector.Count; i++)
            {
                vec.vector[i] *= n;
            }
            return vec;
        }
    }
}
